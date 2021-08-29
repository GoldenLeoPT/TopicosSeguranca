
namespace Cliente
{
    partial class FormCliente
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.textBoxMensagem = new System.Windows.Forms.TextBox();
            this.buttonEnviar = new System.Windows.Forms.Button();
            this.buttonSair = new System.Windows.Forms.Button();
            this.listBoxChat = new System.Windows.Forms.ListBox();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.panelFicheiros = new System.Windows.Forms.Panel();
            this._labelComandos = new System.Windows.Forms.Label();
            this._labelComandoHoras = new System.Windows.Forms.Label();
            this._labelComandoData = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBoxMensagem
            // 
            this.textBoxMensagem.Location = new System.Drawing.Point(17, 442);
            this.textBoxMensagem.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.textBoxMensagem.Name = "textBoxMensagem";
            this.textBoxMensagem.PlaceholderText = "Escrever Mensagem";
            this.textBoxMensagem.Size = new System.Drawing.Size(603, 29);
            this.textBoxMensagem.TabIndex = 1;
            this.textBoxMensagem.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxMensagens_KeyPress);
            // 
            // buttonEnviar
            // 
            this.buttonEnviar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(129)))), ((int)(((byte)(190)))), ((int)(((byte)(65)))));
            this.buttonEnviar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonEnviar.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonEnviar.ForeColor = System.Drawing.Color.White;
            this.buttonEnviar.Location = new System.Drawing.Point(64, 483);
            this.buttonEnviar.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.buttonEnviar.Name = "buttonEnviar";
            this.buttonEnviar.Size = new System.Drawing.Size(231, 42);
            this.buttonEnviar.TabIndex = 2;
            this.buttonEnviar.Text = "Enviar";
            this.buttonEnviar.UseVisualStyleBackColor = false;
            this.buttonEnviar.Click += new System.EventHandler(this.Enviar_Click);
            // 
            // buttonSair
            // 
            this.buttonSair.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(131)))), ((int)(((byte)(11)))), ((int)(((byte)(18)))));
            this.buttonSair.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonSair.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonSair.ForeColor = System.Drawing.Color.White;
            this.buttonSair.Location = new System.Drawing.Point(390, 483);
            this.buttonSair.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.buttonSair.Name = "buttonSair";
            this.buttonSair.Size = new System.Drawing.Size(231, 42);
            this.buttonSair.TabIndex = 4;
            this.buttonSair.Text = "Sair";
            this.buttonSair.UseVisualStyleBackColor = false;
            this.buttonSair.Click += new System.EventHandler(this.buttonSair_Click);
            // 
            // listBoxChat
            // 
            this.listBoxChat.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.listBoxChat.FormattingEnabled = true;
            this.listBoxChat.ItemHeight = 28;
            this.listBoxChat.Location = new System.Drawing.Point(17, 17);
            this.listBoxChat.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.listBoxChat.Name = "listBoxChat";
            this.listBoxChat.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.listBoxChat.Size = new System.Drawing.Size(603, 396);
            this.listBoxChat.TabIndex = 5;
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "Ficheiro";
            this.openFileDialog.Filter = "Text Files | *.txt";
            // 
            // panelFicheiros
            // 
            this.panelFicheiros.BackColor = System.Drawing.Color.Silver;
            this.panelFicheiros.BackgroundImage = global::Cliente.Properties.Resources.outline_attach_file_black_24dp;
            this.panelFicheiros.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panelFicheiros.Cursor = System.Windows.Forms.Cursors.Hand;
            this.panelFicheiros.Location = new System.Drawing.Point(17, 483);
            this.panelFicheiros.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panelFicheiros.Name = "panelFicheiros";
            this.panelFicheiros.Size = new System.Drawing.Size(39, 42);
            this.panelFicheiros.TabIndex = 6;
            this.panelFicheiros.Click += new System.EventHandler(this.panelFicheiros_Click);
            // 
            // _labelComandos
            // 
            this._labelComandos.AutoSize = true;
            this._labelComandos.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this._labelComandos.Location = new System.Drawing.Point(624, 13);
            this._labelComandos.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this._labelComandos.Name = "_labelComandos";
            this._labelComandos.Size = new System.Drawing.Size(112, 25);
            this._labelComandos.TabIndex = 7;
            this._labelComandos.Text = "Comandos:";
            // 
            // _labelComandoHoras
            // 
            this._labelComandoHoras.AutoSize = true;
            this._labelComandoHoras.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this._labelComandoHoras.Location = new System.Drawing.Point(624, 41);
            this._labelComandoHoras.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this._labelComandoHoras.Name = "_labelComandoHoras";
            this._labelComandoHoras.Size = new System.Drawing.Size(59, 23);
            this._labelComandoHoras.TabIndex = 8;
            this._labelComandoHoras.Text = "!Horas";
            // 
            // _labelComandoData
            // 
            this._labelComandoData.AutoSize = true;
            this._labelComandoData.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this._labelComandoData.Location = new System.Drawing.Point(624, 67);
            this._labelComandoData.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this._labelComandoData.Name = "_labelComandoData";
            this._labelComandoData.Size = new System.Drawing.Size(51, 23);
            this._labelComandoData.TabIndex = 9;
            this._labelComandoData.Text = "!Data";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(624, 90);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 23);
            this.label1.TabIndex = 10;
            this.label1.Text = "!Piada";
            // 
            // FormCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ClientSize = new System.Drawing.Size(751, 547);
            this.Controls.Add(this.label1);
            this.Controls.Add(this._labelComandoData);
            this.Controls.Add(this._labelComandoHoras);
            this.Controls.Add(this._labelComandos);
            this.Controls.Add(this.panelFicheiros);
            this.Controls.Add(this.listBoxChat);
            this.Controls.Add(this.buttonSair);
            this.Controls.Add(this.buttonEnviar);
            this.Controls.Add(this.textBoxMensagem);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormCliente";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cliente";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormCliente_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox textBoxMensagem;
        private System.Windows.Forms.Button buttonEnviar;
        private System.Windows.Forms.Button buttonSair;
        private System.Windows.Forms.ListBox listBoxChat;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Panel panelFicheiros;
        private System.Windows.Forms.Label _labelComandos;
        private System.Windows.Forms.Label _labelComandoHoras;
        private System.Windows.Forms.Label _labelComandoData;
        private System.Windows.Forms.Label label1;
    }
}
