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
            btnAdministrarCiudades = new Button();
            lblTituloPanelAcciones = new Label();
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
            lblTituloMenuAdmin.Location = new Point(26, 20);
            lblTituloMenuAdmin.Name = "lblTituloMenuAdmin";
            lblTituloMenuAdmin.Size = new Size(243, 30);
            lblTituloMenuAdmin.TabIndex = 0;
            lblTituloMenuAdmin.Text = "Menú de Administrador";
            // 
            // panel1
            // 
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(btnAdministrarCiudades);
            panel1.Controls.Add(lblTituloPanelAcciones);
            panel1.Controls.Add(btnAdministrarUsuarios);
            panel1.Location = new Point(214, 83);
            panel1.Margin = new Padding(3, 2, 3, 2);
            panel1.Name = "panel1";
            panel1.Size = new Size(261, 206);
            panel1.TabIndex = 1;
            // 
            // btnAdministrarCiudades
            // 
            btnAdministrarCiudades.Location = new Point(60, 165);
            btnAdministrarCiudades.Margin = new Padding(3, 2, 3, 2);
            btnAdministrarCiudades.Name = "btnAdministrarCiudades";
            btnAdministrarCiudades.Size = new Size(144, 22);
            btnAdministrarCiudades.TabIndex = 4;
            btnAdministrarCiudades.Text = "Administrar Ciudades";
            btnAdministrarCiudades.UseVisualStyleBackColor = true;
            btnAdministrarCiudades.Click += btnAdministrarCiudades_Click;
            // 
            // lblTituloPanelAcciones
            // 
            lblTituloPanelAcciones.AutoSize = true;
            lblTituloPanelAcciones.Font = new Font("Segoe UI", 12F);
            lblTituloPanelAcciones.Location = new Point(94, 18);
            lblTituloPanelAcciones.Name = "lblTituloPanelAcciones";
            lblTituloPanelAcciones.Size = new Size(71, 21);
            lblTituloPanelAcciones.TabIndex = 3;
            lblTituloPanelAcciones.Text = "Acciones";
            // 
            // btnAdministrarUsuarios
            // 
            btnAdministrarUsuarios.Location = new Point(60, 68);
            btnAdministrarUsuarios.Margin = new Padding(3, 2, 3, 2);
            btnAdministrarUsuarios.Name = "btnAdministrarUsuarios";
            btnAdministrarUsuarios.Size = new Size(144, 22);
            btnAdministrarUsuarios.TabIndex = 0;
            btnAdministrarUsuarios.Text = "Administrar Usuarios";
            btnAdministrarUsuarios.UseVisualStyleBackColor = true;
            btnAdministrarUsuarios.Click += btnAdministrarUsuarios_Click;
            // 
            // btnSalir
            // 
            btnSalir.Location = new Point(565, 26);
            btnSalir.Margin = new Padding(3, 2, 3, 2);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(82, 22);
            btnSalir.TabIndex = 2;
            btnSalir.Text = "Salir";
            btnSalir.UseVisualStyleBackColor = true;
            btnSalir.Click += btnSalir_Click;
            // 
            // lblNombreApellido
            // 
            lblNombreApellido.AutoSize = true;
            lblNombreApellido.Location = new Point(451, 29);
            lblNombreApellido.Name = "lblNombreApellido";
            lblNombreApellido.Size = new Size(98, 15);
            lblNombreApellido.TabIndex = 3;
            lblNombreApellido.Text = "Nombre Apellido";
            // 
            // lblAdmin
            // 
            lblAdmin.AutoSize = true;
            lblAdmin.Location = new Point(404, 29);
            lblAdmin.Name = "lblAdmin";
            lblAdmin.Size = new Size(46, 15);
            lblAdmin.TabIndex = 4;
            lblAdmin.Text = "Admin:";
            // 
            // MenuPrincipalForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(700, 338);
            Controls.Add(lblAdmin);
            Controls.Add(lblNombreApellido);
            Controls.Add(btnSalir);
            Controls.Add(panel1);
            Controls.Add(lblTituloMenuAdmin);
            Margin = new Padding(3, 2, 3, 2);
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
        private Button btnAdministrarUsuarios;
        private Label lblAdmin;
        private Button btnAdministrarCiudades;
    }
}