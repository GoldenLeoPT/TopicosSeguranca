using EI.SI;
using System;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;
using System.Threading;

namespace Servidor
{
    class Program
    {
        private const int PORT = 2000; // Variavel que defina a PORTA do servidor

        static void Main(string[] args)
        {
            IPEndPoint endPoint = new IPEndPoint(IPAddress.Loopback, PORT); // Instancia o endPoint com a PORT
            TcpListener tcpListener = new TcpListener(endPoint); // Instancia um TCP Listener com o endPoint

            tcpListener.Start(); // Liga o servico do Listener

            Console.WriteLine("Server READY\n* * * * * * *");
            int clientCounter = 0;

            while (true)
            {
                TcpClient tcpClient = tcpListener.AcceptTcpClient(); // Aceita e liga os clientes "apanhados" pelo Listener

                clientCounter++;

                Console.WriteLine($"Client {clientCounter} connected");

                ClientHandler clientHandler = new ClientHandler(tcpClient, clientCounter);
                clientHandler.Handle();
            }
        }

        public class ClientHandler
        {
            string pathBD = "CaminhoDaBaseDados";

            private TcpClient tcpClient;
            private int clientID;

            private const int SALTSIZE = 8; // Tamanho do SALT
            private const int NUMBER_OF_ITERATIONS = 1000; // Numero de iteracoes

            string username;
            byte[] pass;
            byte[] salt;
            byte[] saltedHash;

            public ClientHandler(TcpClient tcpClient, int clientID)
            {
                this.tcpClient = tcpClient;
                this.clientID = clientID;
            }

            public void Handle()
            {
                Thread thread1 = new Thread(threadHandler1);
                thread1.Start();
            }

            public void threadHandler1()
            {
                ProtocolSI protocolSI = new ProtocolSI();
                NetworkStream networkStream = this.tcpClient.GetStream();

                while (protocolSI.GetCmdType() != ProtocolSICmdType.EOT)
                {
                    byte[] ack = protocolSI.Make(ProtocolSICmdType.ACK); // Guarda uma mensagem tipo ACK(Acknowlodge) no array de bytes

                    try
                    {
                        int bytesRead = networkStream.Read(protocolSI.Buffer, 0, protocolSI.Buffer.Length); // Guarda o numero de bytes lidos

                        switch (protocolSI.GetCmdType())
                        {
                            case ProtocolSICmdType.DATA:
                                byte[] packetData;
                                string userMsg = protocolSI.GetStringFromData();
                                string response = "";

                                Console.WriteLine($"Client {clientID}: " + userMsg);

                                if (userMsg.StartsWith("!"))
                                {
                                    userMsg = userMsg.ToLower();

                                    switch (userMsg)
                                    {
                                        case "!horas":
                                            response = DateTime.Now.ToString("HH:mm");
                                            break;

                                        case "!data":
                                            response = DateTime.Now.ToString("dd/MM/yyyy");
                                            break;

                                        case "!piada":
                                            response = "\nComo se chama a neta do Super Mario?\nMarioneta";
                                            break;

                                        default:
                                            response = "Comando Invalido";
                                            break;
                                    }

                                    packetData = protocolSI.Make(ProtocolSICmdType.DATA, response);
                                    networkStream.Write(packetData, 0, packetData.Length);
                                }
                                break;

                            case ProtocolSICmdType.PUBLIC_KEY:
                                break;

                            case ProtocolSICmdType.SECRET_KEY:
                                break;

                            case ProtocolSICmdType.USER_OPTION_1: // USERNAME
                                username = protocolSI.GetStringFromData();
                                break;

                            case ProtocolSICmdType.USER_OPTION_2: // PASSWORD e Registo
                                byte[] packetRegister;

                                try
                                {
                                    pass = protocolSI.GetData();

                                    salt = GenerateSalt(SALTSIZE);

                                    saltedHash = GenerateSaltedHash(pass, salt);

                                    Console.WriteLine("\nA Fazer Registo ...");

                                    Register(username, saltedHash, salt);

                                    packetRegister = protocolSI.Make(ProtocolSICmdType.DATA, "Sucesso!");
                                    Console.WriteLine("Regiso com Sucesso");
                                }
                                catch (Exception)
                                {
                                    packetRegister = protocolSI.Make(ProtocolSICmdType.DATA, "Erro no Registo!");
                                    Console.WriteLine("Erro no Registo");
                                }

                                networkStream.Write(packetRegister, 0, packetRegister.Length);
                                break;

                            case ProtocolSICmdType.USER_OPTION_3: // PASSWORD e Login
                                byte[] packetLogin;

                                try
                                {
                                    Console.WriteLine("\nA Fazer Login ...");

                                    if (VerifyLogin(username, protocolSI.GetStringFromData()))
                                    {
                                        packetLogin = protocolSI.Make(ProtocolSICmdType.DATA, "Sucesso!");
                                        Console.WriteLine("Login com Sucesso");
                                    }
                                    else
                                    {
                                        packetLogin = protocolSI.Make(ProtocolSICmdType.DATA, "Login Incorreto!");
                                        Console.WriteLine("Login Incorreto");
                                    }
                                }
                                catch (Exception)
                                {
                                    packetLogin = protocolSI.Make(ProtocolSICmdType.DATA, $"Erro no Login!");
                                }

                                networkStream.Write(packetLogin, 0, packetLogin.Length);
                                break;

                            case ProtocolSICmdType.EOT:
                                Console.WriteLine($"Client {clientID} has disconnected");
                                break;
                        }

                        networkStream.Write(ack, 0, ack.Length); // Insere o ack na Stream

                    }
                    catch (Exception err)
                    {
                        Console.WriteLine($"Cliente {clientID} perdeu a ligação ao servidor!\n*Erro - {err.Message}");
                    }
                }

                networkStream.Close(); // Fecha o servico da Stream
                tcpClient.Close(); // Encerra o cliente TCP
            }

            // Funcao que regista o utilizador
            private void Register(string username, byte[] saltedPasswordHash, byte[] salt)
            {
                SqlConnection conn = null;

                try
                {
                    // Configurar ligação à Base de Dados
                    conn = new SqlConnection();
                    conn.ConnectionString = String.Format(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + pathBD + ";Integrated Security=True");

                    // Abrir ligação à Base de Dados
                    conn.Open();

                    // Declaração dos parâmetros do comando SQL
                    SqlParameter paramUsername = new SqlParameter("@username", username);
                    SqlParameter paramPassHash = new SqlParameter("@saltedPasswordHash", saltedPasswordHash);
                    SqlParameter paramSalt = new SqlParameter("@salt", salt);

                    // Declaração do comando SQL
                    String sql = "INSERT INTO Users (Username, SaltedPasswordHash, Salt) VALUES (@username,@saltedPasswordHash,@salt)";

                    // Prepara comando SQL para ser executado na Base de Dados
                    SqlCommand cmd = new SqlCommand(sql, conn);

                    // Introduzir valores aos parâmentros registados no comando SQL
                    cmd.Parameters.Add(paramUsername);
                    cmd.Parameters.Add(paramPassHash);
                    cmd.Parameters.Add(paramSalt);

                    // Executar comando SQL
                    int lines = cmd.ExecuteNonQuery();

                    // Fechar ligação
                    conn.Close();
                    if (lines == 0)
                    {
                        // Se forem devolvidas 0 linhas alteradas então o não foi executado com sucesso
                        throw new Exception("Error while inserting a user");
                    }
                }
                catch (Exception e)
                {
                    throw new Exception("Error while inserting a user:" + e.Message);
                }
            }

            // Funcao que verifica o login
            private bool VerifyLogin(string username, string password)
            {
                SqlConnection conn = null;
                try
                {
                    // Configurar ligação à Base de Dados
                    conn = new SqlConnection();
                    conn.ConnectionString = String.Format(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + pathBD + ";Integrated Security=True");

                    // Abrir ligação à Base de Dados
                    conn.Open();

                    // Declaração do comando SQL
                    String sql = "SELECT * FROM Users WHERE Username = @username";
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = sql;

                    // Declaração dos parâmetros do comando SQL
                    SqlParameter param = new SqlParameter("@username", username);

                    // Introduzir valor ao parâmentro registado no comando SQL
                    cmd.Parameters.Add(param);

                    // Associar ligação à Base de Dados ao comando a ser executado
                    cmd.Connection = conn;

                    // Executar comando SQL
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (!reader.HasRows)
                    {
                        throw new Exception("Error while trying to access a user");
                    }

                    // Ler resultado da pesquisa
                    reader.Read();

                    // Obter Hash (password + salt)
                    byte[] saltedPasswordHashStored = (byte[])reader["SaltedPasswordHash"];

                    // Obter salt
                    byte[] saltStored = (byte[])reader["Salt"];

                    conn.Close();

                    // Verificar se a password na base de dados
                    pass = Encoding.UTF8.GetBytes(password);
                    saltedHash = GenerateSaltedHash(pass, saltStored);

                    return saltedPasswordHashStored.SequenceEqual(saltedHash);
                }
                catch (Exception e)
                {
                    Console.WriteLine("An error occurred: " + e.Message);
                    return false;
                }
            }

            // Funcao que gera o SALT
            private static byte[] GenerateSalt(int size)
            {
                //Generate a cryptographic random number.
                using (RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider())
                {
                    byte[] buff = new byte[size];
                    rng.GetBytes(buff);
                    return buff;
                }
            }

            // Funcao que gera a Password 'Salteada'
            private static byte[] GenerateSaltedHash(byte[] plainText, byte[] salt)
            {
                using (Rfc2898DeriveBytes rfc2898 = new Rfc2898DeriveBytes(plainText, salt, NUMBER_OF_ITERATIONS))
                {
                    return rfc2898.GetBytes(32);
                }
            }
        }
    }
}
