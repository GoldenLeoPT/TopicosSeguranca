using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Net.Sockets;
using EI.SI;
using System.Net;

namespace Cliente
{
    public partial class FormLogin : Form
    {

        bool isLogin = true; // Variável para verificar se é Login ou Registo quando o utilizador clicar no botão

        private const int PORT = 2000; // Variável que define a PORTA do cliente, tem de ser igual á do servidor

        FormCliente formCliente;
        NetworkStream networkStream;
        ProtocolSI protocolSI;
        TcpClient tcpClient;

        public FormLogin()
        {
            InitializeComponent();

            IPEndPoint endPoint = new IPEndPoint(IPAddress.Loopback, PORT); // Instancia o endPoint com a PORT

            tcpClient = new TcpClient(); // Instancia o cliente TCP
            tcpClient.Connect(endPoint); // Conecta o cliente pelo EndPoint

            networkStream = tcpClient.GetStream();
            protocolSI = new ProtocolSI();
        }

        // Funções criadas manualmente (não são eventos gerados pelos controlos do Form)
        #region Funcoes

        /* 
         * Função fechaPrograma:
         * Função com o objetivo de confirmar com o utilizador se este quer sair do programa
         * e caso confirme que sim, enviar a mensagem de EOT ao servidor, fechar os serviços
         * e fechar o formulário.
         */
        private bool fechaPrograma()
        {
            var response = MessageBox.Show("Quer mesmo sair?", "Cliente", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (response == DialogResult.Yes)
            {
                byte[] eot = protocolSI.Make(ProtocolSICmdType.EOT); // Cria uma mensagem tipo EOT(End Of Transmission)

                networkStream.Write(eot, 0, eot.Length); // Envia a mensagem pela Stream

                networkStream.Close(); // Fecha o servico da Stream
                tcpClient.Close(); // Encerra o cliente TCP
                Environment.Exit(Environment.ExitCode);// Limpa a memória

                return false; // Retorna false para o formulario continuar a fechar
            }
            else
            {
                return true; // Retorna true para cancelar o fecho do formulario
            }
        }

        #endregion

        // Eventos que não aplicam funcionalidades
        #region MiscEvents

        private void radioButtonLogin_CheckedChanged(object sender, EventArgs e)
        {
            this.Text = "Login";
            buttonLoginRegister.Text = "Login";
            isLogin = true;
        }

        private void radioButtonRegister_CheckedChanged(object sender, EventArgs e)
        {
            this.Text = "Register";
            buttonLoginRegister.Text = "Register";
            isLogin = false;
        }

        private void FormLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = fechaPrograma();
        }

        // 'Enter' faz login/registo (aplicado na TextBox de username)
        private void textBoxUsername_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                buttonLoginRegister.PerformClick();
            }
        }

        // 'Enter' faz login/registo (aplicado na TextBox de password)
        private void textBoxPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                buttonLoginRegister.PerformClick();
            }
        }

        #endregion

        private void buttonLoginRegister_Click(object sender, EventArgs e)
        {
            string msg = ""; // Cria a variável que recebe a resposta do Servidor            

            if (!String.IsNullOrWhiteSpace(textBoxUsername.Text) || !String.IsNullOrWhiteSpace(textBoxPassword.Text)) // Verifica se os campos de Username e Password estão preenchidos
            {
                byte[] option1 = protocolSI.Make(ProtocolSICmdType.USER_OPTION_1, textBoxUsername.Text); // Cria a mensagem que envia o Username do utilizador

                networkStream.Write(option1, 0, option1.Length); // Envia a mensagem através da Stream

                while (protocolSI.GetCmdType() == ProtocolSICmdType.ACK) // Espera pela confirmação (Acknowledge) do Servidor
                {
                    networkStream.Read(protocolSI.Buffer, 0, protocolSI.Buffer.Length);
                }

                /* Verifica se é para realizar Login ou Registo */

                if (isLogin == true) // Caso seja Login
                {
                    byte[] option3 = protocolSI.Make(ProtocolSICmdType.USER_OPTION_3, textBoxPassword.Text); // Cria a mensagem que envia a Password do utilizador

                    networkStream.Write(option3, 0, option3.Length); // Envia a mensagem através da Stream                    

                    while (true)
                    {
                        networkStream.Read(protocolSI.Buffer, 0, protocolSI.Buffer.Length); // Lê o buffer

                        if (protocolSI.GetCmdType() == ProtocolSICmdType.ACK) // Se for ACK (Acknowledge) sai fora do ciclo While
                        {
                            break;
                        }
                        else if (protocolSI.GetCmdType() == ProtocolSICmdType.DATA) // Se for DATA apanha a resposta do Servidor
                        {
                            msg += protocolSI.GetStringFromData();
                        }
                    }
                }
                else // Caso seja Registo
                {
                    byte[] option2 = protocolSI.Make(ProtocolSICmdType.USER_OPTION_2, textBoxPassword.Text); // Cria a mensagem que envia a Password do utilizador

                    networkStream.Write(option2, 0, option2.Length); // Envia a mensagem através da Stream

                    while (true)
                    {
                        networkStream.Read(protocolSI.Buffer, 0, protocolSI.Buffer.Length); // Lê o buffer

                        if (protocolSI.GetCmdType() == ProtocolSICmdType.ACK) // Se for ACK (Acknowledge) sai fora do ciclo While
                        {
                            break;
                        }
                        else if (protocolSI.GetCmdType() == ProtocolSICmdType.DATA) // Se for DATA apanha a resposta do Servidor
                        {
                            msg += protocolSI.GetStringFromData();
                        }
                    }
                }

                if (!String.IsNullOrWhiteSpace(msg)) // Verifica se a resposta do Servidor é vazia ou null
                {
                    MessageBox.Show(msg, "Login/Registo."); // Apresenta a resposta ao utilizador
                }

                formCliente = new FormCliente(networkStream, protocolSI, tcpClient); // Instancia o Form do CLiente (janela de Chat) com as informações de conexão
                this.Hide(); // Esconde a janela de Login (não dá para fechar a janela pois fecharia também a janela de Chat)
                formCliente.ShowDialog(); // Abre a janela de Chat
            }
            else
            {
                MessageBox.Show("Tem de preencher os campos todos.", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
