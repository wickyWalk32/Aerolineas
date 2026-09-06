namespace WindowsForms
{
    partial class MenuPrincipalForm
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
            lblTituloMenuAdmin = new Label();
            panel1 = new Panel();
            lblTituloPanelAcciones = new Label();
            btnAdministrarCiudades = new Button();
            btnAdministrarPaises = new Button();
            btnAdministrarUsuarios = new Button();
            btnSalir = new Button();
            lblNombreApellido = new Label();
            lblAdmin = new Label();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // lblTituloMenuAdmin
            // 
            lblTituloMenuAdmin.AutoSize = true;
            lblTituloMenuAdmin.Font = new Font("Segoe UI", 16F);
            lblTituloMenuAdmin.Location = new Point(30, 27);
            lblTituloMenuAdmin.Name = "lblTituloMenuAdmin";
            lblTituloMenuAdmin.Size = new Size(298, 37);
            lblTituloMenuAdmin.TabIndex = 0;
            lblTituloMenuAdmin.Text = "Menú de Administrador";
            // 
            // panel1
            // 
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(lblTituloPanelAcciones);
            panel1.Controls.Add(btnAdministrarCiudades);
            panel1.Controls.Add(btnAdministrarPaises);
            panel1.Controls.Add(btnAdministrarUsuarios);
            panel1.Location = new Point(245, 111);
            panel1.Name = "panel1";
            panel1.Size = new Size(298, 274);
            panel1.TabIndex = 1;
            // 
            // lblTituloPanelAcciones
            // 
            lblTituloPanelAcciones.AutoSize = true;
            lblTituloPanelAcciones.Font = new Font("Segoe UI", 12F);
            lblTituloPanelAcciones.Location = new Point(107, 24);
            lblTituloPanelAcciones.Name = "lblTituloPanelAcciones";
            lblTituloPanelAcciones.Size = new Size(89, 28);
            lblTituloPanelAcciones.TabIndex = 3;
            lblTituloPanelAcciones.Text = "Acciones";
            // 
            // btnAdministrarCiudades
            // 
            btnAdministrarCiudades.Location = new Point(68, 182);
            btnAdministrarCiudades.Name = "btnAdministrarCiudades";
            btnAdministrarCiudades.Size = new Size(165, 29);
            btnAdministrarCiudades.TabIndex = 2;
            btnAdministrarCiudades.Text = "Administrar Ciudades";
            btnAdministrarCiudades.UseVisualStyleBackColor = true;
            btnAdministrarCiudades.Click += btnAdministrarCiudades_Click;
            // 
            // btnAdministrarPaises
            // 
            btnAdministrarPaises.Location = new Point(68, 137);
            btnAdministrarPaises.Name = "btnAdministrarPaises";
            btnAdministrarPaises.Size = new Size(165, 29);
            btnAdministrarPaises.TabIndex = 1;
            btnAdministrarPaises.Text = "Administrar Paises";
            btnAdministrarPaises.UseVisualStyleBackColor = true;
            btnAdministrarPaises.Click += btnAdministrarPaises_Click;
            // 
            // btnAdministrarUsuarios
            // 
            btnAdministrarUsuarios.Location = new Point(68, 91);
            btnAdministrarUsuarios.Name = "btnAdministrarUsuarios";
            btnAdministrarUsuarios.Size = new Size(165, 29);
            btnAdministrarUsuarios.TabIndex = 0;
            btnAdministrarUsuarios.Text = "Administrar Usuarios";
            btnAdministrarUsuarios.UseVisualStyleBackColor = true;
            btnAdministrarUsuarios.Click += btnAdministrarUsuarios_Click;
            // 
            // btnSalir
            // 
            btnSalir.Location = new Point(646, 35);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(94, 29);
            btnSalir.TabIndex = 2;
            btnSalir.Text = "Salir";
            btnSalir.UseVisualStyleBackColor = true;
            btnSalir.Click += btnSalir_Click;
            // 
            // lblNombreApellido
            // 
            lblNombreApellido.AutoSize = true;
            lblNombreApellido.Location = new Point(515, 39);
            lblNombreApellido.Name = "lblNombreApellido";
            lblNombreApellido.Size = new Size(125, 20);
            lblNombreApellido.TabIndex = 3;
            lblNombreApellido.Text = "Nombre Apellido";
            // 
            // lblAdmin
            // 
            lblAdmin.AutoSize = true;
            lblAdmin.Location = new Point(462, 39);
            lblAdmin.Name = "lblAdmin";
            lblAdmin.Size = new Size(56, 20);
            lblAdmin.TabIndex = 4;
            lblAdmin.Text = "Admin:";
            // 
            // MenuPrincipalForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(lblAdmin);
            Controls.Add(lblNombreApellido);
            Controls.Add(btnSalir);
            Controls.Add(panel1);
            Controls.Add(lblTituloMenuAdmin);
            Name = "MenuPrincipalForm";
            Text = "Administrador";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTituloMenuAdmin;
        private Panel panel1;
        private Button btnSalir;
        private Label lblNombreApellido;
        private Label lblTituloPanelAcciones;
        private Button btnAdministrarCiudades;
        private Button btnAdministrarPaises;
        private Button btnAdministrarUsuarios;
        private Label lblAdmin;
    }
}