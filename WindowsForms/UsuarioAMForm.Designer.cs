namespace WindowsForms
{
    partial class UsuarioAMForm
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
            panel1.Location = new Point(230, 96);
            panel1.Name = "panel1";
            panel1.Size = new Size(345, 303);
            panel1.TabIndex = 0;
            // 
            // lblId
            // 
            lblId.AutoSize = true;
            lblId.Location = new Point(28, 26);
            lblId.Name = "lblId";
            lblId.Size = new Size(24, 20);
            lblId.TabIndex = 9;
            lblId.Text = "ID";
            // 
            // lblIdUsuario
            // 
            lblIdUsuario.AutoSize = true;
            lblIdUsuario.Location = new Point(108, 26);
            lblIdUsuario.Name = "lblIdUsuario";
            lblIdUsuario.Size = new Size(22, 20);
            lblIdUsuario.TabIndex = 3;
            lblIdUsuario.Text = "id";
            lblIdUsuario.Click += label1_Click;
            // 
            // comboBoxRol
            // 
            comboBoxRol.FormattingEnabled = true;
            comboBoxRol.Location = new Point(108, 181);
            comboBoxRol.Name = "comboBoxRol";
            comboBoxRol.Size = new Size(208, 28);
            comboBoxRol.TabIndex = 3;
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(120, 236);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(94, 29);
            btnGuardar.TabIndex = 8;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // textBoxEmail
            // 
            textBoxEmail.Location = new Point(108, 138);
            textBoxEmail.Name = "textBoxEmail";
            textBoxEmail.Size = new Size(208, 27);
            textBoxEmail.TabIndex = 6;
            // 
            // textBoxApellido
            // 
            textBoxApellido.Location = new Point(108, 98);
            textBoxApellido.Name = "textBoxApellido";
            textBoxApellido.Size = new Size(208, 27);
            textBoxApellido.TabIndex = 5;
            // 
            // textBoxNombre
            // 
            textBoxNombre.Location = new Point(108, 59);
            textBoxNombre.Name = "textBoxNombre";
            textBoxNombre.Size = new Size(208, 27);
            textBoxNombre.TabIndex = 4;
            // 
            // lblRol
            // 
            lblRol.AutoSize = true;
            lblRol.Location = new Point(25, 184);
            lblRol.Name = "lblRol";
            lblRol.Size = new Size(31, 20);
            lblRol.TabIndex = 3;
            lblRol.Text = "Rol";
            lblRol.Click += lblRol_Click;
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Location = new Point(25, 145);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(46, 20);
            lblEmail.TabIndex = 2;
            lblEmail.Text = "Email";
            // 
            // lblApellido
            // 
            lblApellido.AutoSize = true;
            lblApellido.Location = new Point(25, 105);
            lblApellido.Name = "lblApellido";
            lblApellido.Size = new Size(66, 20);
            lblApellido.TabIndex = 1;
            lblApellido.Text = "Apellido";
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Location = new Point(25, 66);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(64, 20);
            lblNombre.TabIndex = 0;
            lblNombre.Text = "Nombre";
            // 
            // lblTituloNuevoEditarUsuario
            // 
            lblTituloNuevoEditarUsuario.AutoSize = true;
            lblTituloNuevoEditarUsuario.Font = new Font("Segoe UI", 16F);
            lblTituloNuevoEditarUsuario.Location = new Point(140, 30);
            lblTituloNuevoEditarUsuario.Name = "lblTituloNuevoEditarUsuario";
            lblTituloNuevoEditarUsuario.Size = new Size(262, 37);
            lblTituloNuevoEditarUsuario.TabIndex = 1;
            lblTituloNuevoEditarUsuario.Text = "NuevoEditar Usuario";
            // 
            // btnVolver
            // 
            btnVolver.Location = new Point(140, 438);
            btnVolver.Name = "btnVolver";
            btnVolver.Size = new Size(94, 29);
            btnVolver.TabIndex = 2;
            btnVolver.Text = "Volver";
            btnVolver.UseVisualStyleBackColor = true;
            btnVolver.Click += btnVolver_Click;
            // 
            // UsuarioAMForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 523);
            Controls.Add(btnVolver);
            Controls.Add(lblTituloNuevoEditarUsuario);
            Controls.Add(panel1);
            Name = "UsuarioAMForm";
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
    }
}