namespace WindowsForms
{
    partial class LoginForm
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
            lblTituloLogin = new Label();
            panel1 = new Panel();
            btnIngresar = new Button();
            textBoxPassword = new TextBox();
            textBoxEmail = new TextBox();
            label2 = new Label();
            label1 = new Label();
            btnSalirSistema = new Button();
            label3 = new Label();
            label4 = new Label();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // lblTituloLogin
            // 
            lblTituloLogin.AutoSize = true;
            lblTituloLogin.Font = new Font("Segoe UI", 22F);
            lblTituloLogin.Location = new Point(153, 19);
            lblTituloLogin.Name = "lblTituloLogin";
            lblTituloLogin.Size = new Size(92, 41);
            lblTituloLogin.TabIndex = 5;
            lblTituloLogin.Text = "Login";
            // 
            // panel1
            // 
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(btnIngresar);
            panel1.Controls.Add(textBoxPassword);
            panel1.Controls.Add(textBoxEmail);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(lblTituloLogin);
            panel1.Location = new Point(142, 43);
            panel1.Margin = new Padding(3, 2, 3, 2);
            panel1.Name = "panel1";
            panel1.Size = new Size(426, 223);
            panel1.TabIndex = 7;
            // 
            // btnIngresar
            // 
            btnIngresar.Location = new Point(153, 170);
            btnIngresar.Margin = new Padding(3, 2, 3, 2);
            btnIngresar.Name = "btnIngresar";
            btnIngresar.Size = new Size(116, 22);
            btnIngresar.TabIndex = 10;
            btnIngresar.Text = "Ingresar";
            btnIngresar.UseVisualStyleBackColor = true;
            btnIngresar.Click += btnIngresar_Click;
            // 
            // textBoxPassword
            // 
            textBoxPassword.Location = new Point(213, 127);
            textBoxPassword.Margin = new Padding(3, 2, 3, 2);
            textBoxPassword.Name = "textBoxPassword";
            textBoxPassword.PasswordChar = '*';
            textBoxPassword.Size = new Size(147, 23);
            textBoxPassword.TabIndex = 9;
            // 
            // textBoxEmail
            // 
            textBoxEmail.AccessibleName = "";
            textBoxEmail.BackColor = SystemColors.Window;
            textBoxEmail.Location = new Point(213, 91);
            textBoxEmail.Margin = new Padding(3, 2, 3, 2);
            textBoxEmail.Name = "textBoxEmail";
            textBoxEmail.Size = new Size(147, 23);
            textBoxEmail.TabIndex = 8;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(67, 129);
            label2.Name = "label2";
            label2.Size = new Size(121, 15);
            label2.TabIndex = 7;
            label2.Text = "Ingrese su contraseña";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(67, 93);
            label1.Name = "label1";
            label1.Size = new Size(92, 15);
            label1.TabIndex = 6;
            label1.Text = "Ingrese su email";
            // 
            // btnSalirSistema
            // 
            btnSalirSistema.Location = new Point(47, 302);
            btnSalirSistema.Margin = new Padding(3, 2, 3, 2);
            btnSalirSistema.Name = "btnSalirSistema";
            btnSalirSistema.Size = new Size(124, 22);
            btnSalirSistema.TabIndex = 8;
            btnSalirSistema.Text = "Salir del sistema";
            btnSalirSistema.UseVisualStyleBackColor = true;
            btnSalirSistema.Click += btnSalirSistema_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(331, 302);
            label3.Name = "label3";
            label3.Size = new Size(311, 15);
            label3.TabIndex = 9;
            label3.Text = "admin valido: email = alum@email.com , contra = net123";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(331, 316);
            label4.Name = "label4";
            label4.Size = new Size(314, 15);
            label4.TabIndex = 10;
            label4.Text = "usuario comun: email = usu@email.com , contra = net321";
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(700, 360);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(btnSalirSistema);
            Controls.Add(panel1);
            Margin = new Padding(3, 2, 3, 2);
            Name = "LoginForm";
            Text = "Login";
            Load += LoginForm_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label lblTituloLogin;
        private Panel panel1;
        private Button btnIngresar;
        private TextBox textBoxPassword;
        private TextBox textBoxEmail;
        private Label label2;
        private Label label1;
        private Button btnSalirSistema;
        private Label label3;
        private Label label4;
    }
}