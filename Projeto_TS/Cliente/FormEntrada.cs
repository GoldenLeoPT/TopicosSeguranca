using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class FormEntrada : Form
    {
        string user = "teste";      //Credenciais do usuarío             
        string password = "teste";   //*
        bool isLogin = true;

        public int NUMBER_OF_ITERATIONS { get; private set; }

        public FormEntrada()
        {
            InitializeComponent();
        }

        private void radioButtonLogin_CheckedChanged(object sender, EventArgs e)
        {
            this.Text = "Entrar";
            buttonLoginRegister.Text = "Entrar";
            isLogin = true;
        }

        private void radioButtonRegister_CheckedChanged(object sender, EventArgs e)
        {
            this.Text = "Registo";
            buttonLoginRegister.Text = "Registo";
            isLogin = false;
        }

        private void buttonLoginRegister_Click(object sender, EventArgs e)
        {

            if (isLogin == true)
            {
                if (textBoxUsername.Text == user && textBoxPassword.Text == password)
                {
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Os dados fornecidos não estão corretos ");
                }
            }
            else
            {
                MessageBox.Show("Registo efetuado com sucesso (codigo em teste...)");
            }
        }

        private void textBoxPassword_TextChanged(object sender, EventArgs e)
        {

        }


    }
}
