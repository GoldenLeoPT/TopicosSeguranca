
namespace Client
{
    partial class FormEntrada
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.l_label1 = new System.Windows.Forms.Label();
            this.l_label2 = new System.Windows.Forms.Label();
            this.textBoxUsername = new System.Windows.Forms.TextBox();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.buttonLoginRegister = new System.Windows.Forms.Button();
            this.radioButtonLogin = new System.Windows.Forms.RadioButton();
            this.radioButtonRegister = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // l_label1
            // 
            this.l_label1.AutoSize = true;
            this.l_label1.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.l_label1.Location = new System.Drawing.Point(145, 11);
            this.l_label1.Name = "l_label1";
            this.l_label1.Size = new System.Drawing.Size(102, 32);
            this.l_label1.TabIndex = 1;
            this.l_label1.Text = "Usuário";
            // 
            // l_label2
            // 
            this.l_label2.AutoSize = true;
            this.l_label2.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.l_label2.Location = new System.Drawing.Point(114, 93);
            this.l_label2.Name = "l_label2";
            this.l_label2.Size = new System.Drawing.Size(170, 32);
            this.l_label2.TabIndex = 2;
            this.l_label2.Text = "Palavra-passe";
            // 
            // textBoxUsername
            // 
            this.textBoxUsername.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.textBoxUsername.Location = new System.Drawing.Point(70, 46);
            this.textBoxUsername.Name = "textBoxUsername";
            this.textBoxUsername.Size = new System.Drawing.Size(255, 34);
            this.textBoxUsername.TabIndex = 3;
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.textBoxPassword.Location = new System.Drawing.Point(70, 129);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.PasswordChar = '*';
            this.textBoxPassword.Size = new System.Drawing.Size(255, 34);
            this.textBoxPassword.TabIndex = 4;
            this.textBoxPassword.TextChanged += new System.EventHandler(this.textBoxPassword_TextChanged);
            // 
            // buttonLoginRegister
            // 
            this.buttonLoginRegister.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(221)))), ((int)(((byte)(221)))));
            this.buttonLoginRegister.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonLoginRegister.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.buttonLoginRegister.ForeColor = System.Drawing.SystemColors.ControlText;
            this.buttonLoginRegister.Location = new System.Drawing.Point(149, 282);
            this.buttonLoginRegister.Name = "buttonLoginRegister";
            this.buttonLoginRegister.Size = new System.Drawing.Size(105, 35);
            this.buttonLoginRegister.TabIndex = 8;
            this.buttonLoginRegister.Text = "Entrar";
            this.buttonLoginRegister.UseVisualStyleBackColor = false;
            this.buttonLoginRegister.Click += new System.EventHandler(this.buttonLoginRegister_Click);
            // 
            // radioButtonLogin
            // 
            this.radioButtonLogin.AutoSize = true;
            this.radioButtonLogin.Checked = true;
            this.radioButtonLogin.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.radioButtonLogin.Location = new System.Drawing.Point(8, 4);
            this.radioButtonLogin.Name = "radioButtonLogin";
            this.radioButtonLogin.Size = new System.Drawing.Size(85, 29);
            this.radioButtonLogin.TabIndex = 5;
            this.radioButtonLogin.TabStop = true;
            this.radioButtonLogin.Text = "Entrar";
            this.radioButtonLogin.UseVisualStyleBackColor = true;
            this.radioButtonLogin.CheckedChanged += new System.EventHandler(this.radioButtonLogin_CheckedChanged);
            // 
            // radioButtonRegister
            // 
            this.radioButtonRegister.AutoSize = true;
            this.radioButtonRegister.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.radioButtonRegister.Location = new System.Drawing.Point(8, 40);
            this.radioButtonRegister.Name = "radioButtonRegister";
            this.radioButtonRegister.Size = new System.Drawing.Size(102, 29);
            this.radioButtonRegister.TabIndex = 6;
            this.radioButtonRegister.Text = "Register";
            this.radioButtonRegister.UseVisualStyleBackColor = true;
            this.radioButtonRegister.CheckedChanged += new System.EventHandler(this.radioButtonRegister_CheckedChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.radioButtonRegister);
            this.panel1.Controls.Add(this.radioButtonLogin);
            this.panel1.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.panel1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.panel1.Location = new System.Drawing.Point(70, 184);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 78);
            this.panel1.TabIndex = 7;
            // 
            // FormEntrada
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(247)))), ((int)(((byte)(249)))));
            this.ClientSize = new System.Drawing.Size(384, 370);
            this.Controls.Add(this.buttonLoginRegister);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.textBoxPassword);
            this.Controls.Add(this.textBoxUsername);
            this.Controls.Add(this.l_label2);
            this.Controls.Add(this.l_label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.Name = "FormEntrada";
            this.Text = "Login";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label l_label1;
        private System.Windows.Forms.Label l_label2;
        private System.Windows.Forms.TextBox textBoxUsername;
        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.Button buttonLoginRegister;
        private System.Windows.Forms.RadioButton radioButtonLogin;
        private System.Windows.Forms.RadioButton radioButtonRegister;
        private System.Windows.Forms.Panel panel1;
    }
}

