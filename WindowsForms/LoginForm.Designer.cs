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
            textBoxContrasenia = new TextBox();
            textBoxEmail = new TextBox();
            label2 = new Label();
            label1 = new Label();
            btnSalirSistema = new Button();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            btnAutoregistroUsuario = new Button();
            panel2 = new Panel();
            lblInformacion = new Label();
            btnCargarDatosAdmin = new Button();
            btnCargarDatosUsuario = new Button();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // lblTituloLogin
            // 
            lblTituloLogin.AutoSize = true;
            lblTituloLogin.Font = new Font("Segoe UI", 22F);
            lblTituloLogin.Location = new Point(175, 25);
            lblTituloLogin.Name = "lblTituloLogin";
            lblTituloLogin.Size = new Size(113, 50);
            lblTituloLogin.TabIndex = 5;
            lblTituloLogin.Text = "Login";
            // 
            // panel1
            // 
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(btnIngresar);
            panel1.Controls.Add(textBoxContrasenia);
            panel1.Controls.Add(textBoxEmail);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(lblTituloLogin);
            panel1.Location = new Point(90, 66);
            panel1.Name = "panel1";
            panel1.Size = new Size(487, 297);
            panel1.TabIndex = 7;
            // 
            // btnIngresar
            // 
            btnIngresar.Location = new Point(175, 227);
            btnIngresar.Name = "btnIngresar";
            btnIngresar.Size = new Size(142, 29);
            btnIngresar.TabIndex = 10;
            btnIngresar.Text = "Ingresar";
            btnIngresar.UseVisualStyleBackColor = true;
            btnIngresar.Click += btnIngresar_Click;
            // 
            // textBoxContrasenia
            // 
            textBoxContrasenia.Location = new Point(243, 169);
            textBoxContrasenia.Name = "textBoxContrasenia";
            textBoxContrasenia.PasswordChar = '*';
            textBoxContrasenia.Size = new Size(167, 27);
            textBoxContrasenia.TabIndex = 9;
            // 
            // textBoxEmail
            // 
            textBoxEmail.AccessibleName = "";
            textBoxEmail.BackColor = SystemColors.Window;
            textBoxEmail.Location = new Point(243, 121);
            textBoxEmail.Name = "textBoxEmail";
            textBoxEmail.Size = new Size(167, 27);
            textBoxEmail.TabIndex = 8;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(77, 172);
            label2.Name = "label2";
            label2.Size = new Size(151, 20);
            label2.TabIndex = 7;
            label2.Text = "Ingrese su contraseña";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(77, 124);
            label1.Name = "label1";
            label1.Size = new Size(116, 20);
            label1.TabIndex = 6;
            label1.Text = "Ingrese su email";
            // 
            // btnSalirSistema
            // 
            btnSalirSistema.Location = new Point(90, 416);
            btnSalirSistema.Name = "btnSalirSistema";
            btnSalirSistema.Size = new Size(142, 29);
            btnSalirSistema.TabIndex = 8;
            btnSalirSistema.Text = "Salir del sistema";
            btnSalirSistema.UseVisualStyleBackColor = true;
            btnSalirSistema.Click += btnSalirSistema_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(51, 117);
            label3.Name = "label3";
            label3.Size = new Size(391, 20);
            label3.TabIndex = 9;
            label3.Text = "admin   => email: admin@email.com - contraseña: admin";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(51, 172);
            label4.Name = "label4";
            label4.Size = new Size(373, 20);
            label4.TabIndex = 10;
            label4.Text = "usuario => email: usu@email.com       - contraseña: usu";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label5.Location = new Point(51, 88);
            label5.Name = "label5";
            label5.Size = new Size(128, 20);
            label5.TabIndex = 11;
            label5.Text = "Datos de prueba:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label6.Location = new Point(51, 237);
            label6.Name = "label6";
            label6.Size = new Size(284, 20);
            label6.TabIndex = 12;
            label6.Text = "Tecla \"Enter\" acciona botón de Ingresar";
            // 
            // btnAutoregistroUsuario
            // 
            btnAutoregistroUsuario.Location = new Point(1006, 416);
            btnAutoregistroUsuario.Name = "btnAutoregistroUsuario";
            btnAutoregistroUsuario.Size = new Size(142, 29);
            btnAutoregistroUsuario.TabIndex = 13;
            btnAutoregistroUsuario.Text = "Registrarse";
            btnAutoregistroUsuario.UseVisualStyleBackColor = true;
            btnAutoregistroUsuario.Click += btnAutoregistroUsuario_Click;
            // 
            // panel2
            // 
            panel2.BorderStyle = BorderStyle.FixedSingle;
            panel2.Controls.Add(btnCargarDatosUsuario);
            panel2.Controls.Add(lblInformacion);
            panel2.Controls.Add(label4);
            panel2.Controls.Add(btnCargarDatosAdmin);
            panel2.Controls.Add(label6);
            panel2.Controls.Add(label3);
            panel2.Controls.Add(label5);
            panel2.Location = new Point(661, 66);
            panel2.Name = "panel2";
            panel2.Size = new Size(487, 297);
            panel2.TabIndex = 14;
            // 
            // lblInformacion
            // 
            lblInformacion.AutoSize = true;
            lblInformacion.Font = new Font("Segoe UI", 22F);
            lblInformacion.Location = new Point(132, 25);
            lblInformacion.Name = "lblInformacion";
            lblInformacion.Size = new Size(220, 50);
            lblInformacion.TabIndex = 13;
            lblInformacion.Text = "Información";
            // 
            // btnCargarDatosAdmin
            // 
            btnCargarDatosAdmin.Location = new Point(51, 140);
            btnCargarDatosAdmin.Name = "btnCargarDatosAdmin";
            btnCargarDatosAdmin.Size = new Size(128, 29);
            btnCargarDatosAdmin.TabIndex = 14;
            btnCargarDatosAdmin.Text = "Cargar en Login";
            btnCargarDatosAdmin.UseVisualStyleBackColor = true;
            btnCargarDatosAdmin.Click += btnCargarDatosAdmin_Click;
            // 
            // btnCargarDatosUsuario
            // 
            btnCargarDatosUsuario.Location = new Point(51, 195);
            btnCargarDatosUsuario.Name = "btnCargarDatosUsuario";
            btnCargarDatosUsuario.Size = new Size(128, 29);
            btnCargarDatosUsuario.TabIndex = 15;
            btnCargarDatosUsuario.Text = "Cargar en Login";
            btnCargarDatosUsuario.UseVisualStyleBackColor = true;
            btnCargarDatosUsuario.Click += btnCargarDatosUsuario_Click;
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1242, 503);
            Controls.Add(panel2);
            Controls.Add(btnAutoregistroUsuario);
            Controls.Add(btnSalirSistema);
            Controls.Add(panel1);
            Name = "LoginForm";
            Text = "Login";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private Label lblTituloLogin;
        private Panel panel1;
        private Button btnIngresar;
        private TextBox textBoxContrasenia;
        private TextBox textBoxEmail;
        private Label label2;
        private Label label1;
        private Button btnSalirSistema;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Button btnAutoregistroUsuario;
        private Panel panel2;
        private Label lblInformacion;
        private Button btnCargarDatosUsuario;
        private Button btnCargarDatosAdmin;
    }
}