using EI.SI;
using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace Client
{
    public partial class FormClient : Form
    {
        private const int PORT = 2000; // Uma Variavel que define a PORTA do client, tem de ser igual ao do servidor que esta ligado !!!

        NetworkStream networkStream;
        ProtocolSI protocolSI;  //Trata-se do ficheiro DLL que o foi definido na aula para acesso a uma biblioteca
        TcpClient tcpClient;
        private object aes;
        private byte[] txtDecifrado;

        public int NUMBER_OF_ITERATIONS { get; private set; }
        public object ProtocolSICmdType { get; private set; }

        public FormClient()
        {
            InitializeComponent();

            IPEndPoint endPoint = new IPEndPoint(IPAddress.Loopback, PORT); // Instancia o endPoint com a PORT

            tcpClient = new TcpClient(); // Instancia o cliente TCP
            tcpClient.Connect(endPoint); // Conecta o cliente pelo EndPoint

            networkStream = tcpClient.GetStream();

            protocolSI = new ProtocolSI();
        }

        private void Enviar_Click(object sender, EventArgs e)
        {
            string msg = textBoxMensagem.Text;

            if (String.IsNullOrWhiteSpace(msg)) // Verificar se a mensagem está vazia
            {
                // Dá informação ao utilizador de que a mensagem está vazia
                MessageBox.Show("Porfavor introduz uma mensagem", "Mensagem Necessária!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                textBoxMensagem.Clear(); // Limpa a caixa de texto
                listBoxChat.Items.Add($"You: {msg}"); // Apresenta a mensagem no chat

                byte[] packet = protocolSI.Make(ProtocolSICmdType.DATA, msg); // Guarda a mensagem e o tipo do protocolo num array de bytes

                networkStream.Write(packet, 0, packet.Length); // Insere o packet na Stream

                while (protocolSI.GetCmdType() != ProtocolSICmdType.ACK)
                {
                    networkStream.Read(protocolSI.Buffer, 0, protocolSI.Buffer.Length); // Ler o buffer enquanto espera pelo ack(acknowledge)
                }
            }
        }

        private void buttonSair_Click(object sender, EventArgs e)
        {
            this.Close(); // Fecha o formulario, iniciando o evento formClosing para sair
        }

        private void FormCliente_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = fechaPrograma(); // Recebe verdadeiro(true) ou falso(false) dependendo da resposta do utilizador na funcao
        }
        /* 
         * Funçao fechaprograma:
         * Funçao com o objetivo de confirmar com o utilizador se este quer sair do programa
         * e caso confirme que sim, enviar a mensagem de EOT ao servidor, fechar os servicos
         * e fechar o formulario. 
         */
        private bool fechaPrograma()
        {
            var response = MessageBox.Show("Queres mesmo sair ?", "Cliente", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (response == DialogResult.Yes)
            {
                byte[] eot = protocolSI.Make(ProtocolSICmdType.EOT); // Guarda uma mensagem tipo EOT(End Of Transmission) no array de bytes

                networkStream.Write(eot, 0, eot.Length); // Insere o eot na Stream
                networkStream.Read(protocolSI.Buffer, 0, protocolSI.Buffer.Length);

                networkStream.Close(); // Fecha o servico da Stream
                tcpClient.Close(); // Encerra o cliente TCP

                return false; // Retorna false para o formulario continuar a fechar
            }
            else
            {
                return true; // Retorna true para cancelar o fecho do formulario
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            //openFileDialog1.Filter = "TXT files|*.txt"; 
            openFileDialog1.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            openFileDialog1.ShowDialog();
        }

        private void textBoxMensagens_KeyPress(object sender, KeyPressEventArgs e)
        {        
            if(e.KeyChar == 13)
            {
                buttonEnviar.PerformClick();
            }
        }

        private void openFileDialog1_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }

        //Em seguida esta a criação de uma chave simétrica
        private string GerarChavePrivada(string pass, byte[] salt)
        {
            Rfc2898DeriveBytes pwdGen = new Rfc2898DeriveBytes(pass, salt, NUMBER_OF_ITERATIONS);
            byte[] key = pwdGen.GetBytes(16);//gera uma chave privada de 16 bytes
            string passB64 = Convert.ToBase64String(key);

            return passB64;
        }

        private string Generator(string pass, byte[] salt)
        {
            Rfc2898DeriveBytes pwdGen = new Rfc2898DeriveBytes(pass, salt, NUMBER_OF_ITERATIONS);
            byte[] iv = pwdGen.GetBytes(16);//Criar um array
            string ivB64 = Convert.ToBase64String(iv);

            return ivB64;
        }
            private string crypting(string txt)
            {
                byte[] txtvisivel = Encoding.UTF8.GetBytes(txt);
                byte[] txtCifrado;
                MemoryStream ms = new MemoryStream(); //Alocação de memoria da mensagem criptografada
                CryptoStream cs = new(ms, aes.CreateDecryptor(), CryptoStreamMode.Write); //Ligar o sistema
                cs.Write(txtDecifrado, 0, txtDecifrado.Length);               
                txtCifrado = ms.ToArray();//Guardar dados no Array               
                string txtCifradoB64 = Convert.ToBase64String(txtCifrado);//converter os dados para texto legível

                return txtCifradoB64;
            }


    }
}