namespace WindowsForms
{
    partial class UsuarioDetalle
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
            panel1 = new Panel();
            textBoxContrasenia = new TextBox();
            lblContrasenia = new Label();
            lblId = new Label();
            lblIdUsuario = new Label();
            comboBoxRol = new ComboBox();
            btnGuardar = new Button();
            textBoxEmail = new TextBox();
            textBoxApellido = new TextBox();
            textBoxNombre = new TextBox();
            lblRol = new Label();
            lblEmail = new Label();
            lblApellido = new Label();
            lblNombre = new Label();
            lblTituloNuevoEditarUsuario = new Label();
            btnVolver = new Button();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(textBoxContrasenia);
            panel1.Controls.Add(lblContrasenia);
            panel1.Controls.Add(lblId);
            panel1.Controls.Add(lblIdUsuario);
            panel1.Controls.Add(comboBoxRol);
            panel1.Controls.Add(btnGuardar);
            panel1.Controls.Add(textBoxEmail);
            panel1.Controls.Add(textBoxApellido);
            panel1.Controls.Add(textBoxNombre);
            panel1.Controls.Add(lblRol);
            panel1.Controls.Add(lblEmail);
            panel1.Controls.Add(lblApellido);
            panel1.Controls.Add(lblNombre);
            panel1.Location = new Point(201, 72);
            panel1.Margin = new Padding(3, 2, 3, 2);
            panel1.Name = "panel1";
            panel1.Size = new Size(302, 242);
            panel1.TabIndex = 0;
            // 
            // textBoxContrasenia
            // 
            textBoxContrasenia.Location = new Point(94, 134);
            textBoxContrasenia.Margin = new Padding(3, 2, 3, 2);
            textBoxContrasenia.Name = "textBoxContrasenia";
            textBoxContrasenia.Size = new Size(182, 23);
            textBoxContrasenia.TabIndex = 11;
            textBoxContrasenia.UseSystemPasswordChar = true;
            // 
            // lblContrasenia
            // 
            lblContrasenia.AutoSize = true;
            lblContrasenia.Location = new Point(22, 137);
            lblContrasenia.Name = "lblContrasenia";
            lblContrasenia.Size = new Size(67, 15);
            lblContrasenia.TabIndex = 10;
            lblContrasenia.Text = "Contraseña";
            // 
            // lblId
            // 
            lblId.AutoSize = true;
            lblId.Location = new Point(24, 20);
            lblId.Name = "lblId";
            lblId.Size = new Size(18, 15);
            lblId.TabIndex = 9;
            lblId.Text = "ID";
            // 
            // lblIdUsuario
            // 
            lblIdUsuario.AutoSize = true;
            lblIdUsuario.Location = new Point(94, 20);
            lblIdUsuario.Name = "lblIdUsuario";
            lblIdUsuario.Size = new Size(17, 15);
            lblIdUsuario.TabIndex = 3;
            lblIdUsuario.Text = "id";
            // 
            // comboBoxRol
            // 
            comboBoxRol.FormattingEnabled = true;
            comboBoxRol.Items.AddRange(new object[] { "admin", "usuario" });
            comboBoxRol.Location = new Point(94, 164);
            comboBoxRol.Margin = new Padding(3, 2, 3, 2);
            comboBoxRol.Name = "comboBoxRol";
            comboBoxRol.Size = new Size(182, 23);
            comboBoxRol.TabIndex = 3;
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(105, 208);
            btnGuardar.Margin = new Padding(3, 2, 3, 2);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(82, 22);
            btnGuardar.TabIndex = 8;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // textBoxEmail
            // 
            textBoxEmail.Location = new Point(94, 104);
            textBoxEmail.Margin = new Padding(3, 2, 3, 2);
            textBoxEmail.Name = "textBoxEmail";
            textBoxEmail.Size = new Size(182, 23);
            textBoxEmail.TabIndex = 6;
            // 
            // textBoxApellido
            // 
            textBoxApellido.Location = new Point(94, 74);
            textBoxApellido.Margin = new Padding(3, 2, 3, 2);
            textBoxApellido.Name = "textBoxApellido";
            textBoxApellido.Size = new Size(182, 23);
            textBoxApellido.TabIndex = 5;
            // 
            // textBoxNombre
            // 
            textBoxNombre.Location = new Point(94, 44);
            textBoxNombre.Margin = new Padding(3, 2, 3, 2);
            textBoxNombre.Name = "textBoxNombre";
            textBoxNombre.Size = new Size(182, 23);
            textBoxNombre.TabIndex = 4;
            // 
            // lblRol
            // 
            lblRol.AutoSize = true;
            lblRol.Location = new Point(24, 167);
            lblRol.Name = "lblRol";
            lblRol.Size = new Size(24, 15);
            lblRol.TabIndex = 3;
            lblRol.Text = "Rol";
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Location = new Point(22, 109);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(36, 15);
            lblEmail.TabIndex = 2;
            lblEmail.Text = "Email";
            // 
            // lblApellido
            // 
            lblApellido.AutoSize = true;
            lblApellido.Location = new Point(22, 79);
            lblApellido.Name = "lblApellido";
            lblApellido.Size = new Size(51, 15);
            lblApellido.TabIndex = 1;
            lblApellido.Text = "Apellido";
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Location = new Point(22, 50);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(51, 15);
            lblNombre.TabIndex = 0;
            lblNombre.Text = "Nombre";
            // 
            // lblTituloNuevoEditarUsuario
            // 
            lblTituloNuevoEditarUsuario.AutoSize = true;
            lblTituloNuevoEditarUsuario.Font = new Font("Segoe UI", 16F);
            lblTituloNuevoEditarUsuario.Location = new Point(122, 22);
            lblTituloNuevoEditarUsuario.Name = "lblTituloNuevoEditarUsuario";
            lblTituloNuevoEditarUsuario.Size = new Size(211, 30);
            lblTituloNuevoEditarUsuario.TabIndex = 1;
            lblTituloNuevoEditarUsuario.Text = "NuevoEditar Usuario";
            // 
            // btnVolver
            // 
            btnVolver.Location = new Point(122, 328);
            btnVolver.Margin = new Padding(3, 2, 3, 2);
            btnVolver.Name = "btnVolver";
            btnVolver.Size = new Size(82, 22);
            btnVolver.TabIndex = 2;
            btnVolver.Text = "Volver";
            btnVolver.UseVisualStyleBackColor = true;
            btnVolver.Click += btnVolver_Click;
            // 
            // UsuarioDetalle
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(700, 392);
            Controls.Add(btnVolver);
            Controls.Add(lblTituloNuevoEditarUsuario);
            Controls.Add(panel1);
            Margin = new Padding(3, 2, 3, 2);
            Name = "UsuarioDetalle";
            Text = "Administrador";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Button btnGuardar;
        private TextBox textBoxEmail;
        private TextBox textBoxApellido;
        private TextBox textBoxNombre;
        private Label lblRol;
        private Label lblEmail;
        private Label lblApellido;
        private Label lblNombre;
        private Label lblTituloNuevoEditarUsuario;
        private Button btnVolver;
        private ComboBox comboBoxRol;
        private Label lblIdUsuario;
        private Label lblId;
        private TextBox textBoxContrasenia;
        private Label lblContrasenia;
    }
}