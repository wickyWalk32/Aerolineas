using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsForms
{
    partial class MenuAdminForm
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
            button1 = new Button();
            btnAdministrarServicios = new Button();
            btnAdministrarCiudades = new Button();
            lblTituloPanelAcciones = new Label();
            btnAdministrarUsuarios = new Button();
            btnAdministrarPasajeros = new Button();
            btnSalirDelSistema = new Button();
            lblNombreApellido = new Label();
            lblAdmin = new Label();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // lblTituloMenuAdmin
            // 
            lblTituloMenuAdmin.AutoSize = true;
            lblTituloMenuAdmin.Font = new Font("Segoe UI", 16F);
            lblTituloMenuAdmin.Location = new Point(27, 20);
            lblTituloMenuAdmin.Name = "lblTituloMenuAdmin";
            lblTituloMenuAdmin.Size = new Size(243, 30);
            lblTituloMenuAdmin.TabIndex = 0;
            lblTituloMenuAdmin.Text = "Menú de Administrador";
            // 
            // panel1
            // 
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(button1);
            panel1.Controls.Add(btnAdministrarServicios);
            panel1.Controls.Add(btnAdministrarCiudades);
            panel1.Controls.Add(lblTituloPanelAcciones);
            panel1.Controls.Add(btnAdministrarUsuarios);
            panel1.Controls.Add(btnAdministrarPasajeros);
            panel1.Location = new Point(214, 100);
            panel1.Margin = new Padding(3, 2, 3, 2);
            panel1.Name = "panel1";
            panel1.Size = new Size(261, 251);
            panel1.TabIndex = 1;
            // 
            // button1
            // 
            button1.Location = new Point(57, 162);
            button1.Margin = new Padding(3, 2, 3, 2);
            button1.Name = "button1";
            button1.Size = new Size(144, 22);
            button1.TabIndex = 6;
            button1.Text = "Administrar Aviones";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // btnAdministrarServicios
            // 
            btnAdministrarServicios.Location = new Point(57, 136);
            btnAdministrarServicios.Margin = new Padding(3, 2, 3, 2);
            btnAdministrarServicios.Name = "btnAdministrarServicios";
            btnAdministrarServicios.Size = new Size(144, 22);
            btnAdministrarServicios.TabIndex = 5;
            btnAdministrarServicios.Text = "Administrar Servicios";
            btnAdministrarServicios.UseVisualStyleBackColor = true;
            btnAdministrarServicios.Click += btnAdministrarServicios_Click;
            // 
            // btnAdministrarCiudades
            // 
            btnAdministrarCiudades.Location = new Point(57, 83);
            btnAdministrarCiudades.Margin = new Padding(3, 2, 3, 2);
            btnAdministrarCiudades.Name = "btnAdministrarCiudades";
            btnAdministrarCiudades.Size = new Size(144, 22);
            btnAdministrarCiudades.TabIndex = 2;
            btnAdministrarCiudades.Text = "Administrar Ciudades";
            btnAdministrarCiudades.UseVisualStyleBackColor = true;
            btnAdministrarCiudades.Click += btnAdministrarCiudades_Click;
            // 
            // lblTituloPanelAcciones
            // 
            lblTituloPanelAcciones.AutoSize = true;
            lblTituloPanelAcciones.Font = new Font("Segoe UI", 12F);
            lblTituloPanelAcciones.Location = new Point(90, 20);
            lblTituloPanelAcciones.Name = "lblTituloPanelAcciones";
            lblTituloPanelAcciones.Size = new Size(71, 21);
            lblTituloPanelAcciones.TabIndex = 3;
            lblTituloPanelAcciones.Text = "Acciones";
            // 
            // btnAdministrarUsuarios
            // 
            btnAdministrarUsuarios.Location = new Point(57, 57);
            btnAdministrarUsuarios.Margin = new Padding(3, 2, 3, 2);
            btnAdministrarUsuarios.Name = "btnAdministrarUsuarios";
            btnAdministrarUsuarios.Size = new Size(144, 22);
            btnAdministrarUsuarios.TabIndex = 0;
            btnAdministrarUsuarios.Text = "Administrar Usuarios";
            btnAdministrarUsuarios.UseVisualStyleBackColor = true;
            btnAdministrarUsuarios.Click += btnAdministrarUsuarios_Click;
            // 
            // btnAdministrarPasajeros
            // 
            btnAdministrarPasajeros.Location = new Point(57, 110);
            btnAdministrarPasajeros.Margin = new Padding(3, 2, 3, 2);
            btnAdministrarPasajeros.Name = "btnAdministrarPasajeros";
            btnAdministrarPasajeros.Size = new Size(144, 22);
            btnAdministrarPasajeros.TabIndex = 4;
            btnAdministrarPasajeros.Text = "Administrar Pasajeros";
            btnAdministrarPasajeros.UseVisualStyleBackColor = true;
            btnAdministrarPasajeros.Click += btnAdministrarPasajeros_Click;
            // 
            // btnSalirDelSistema
            // 
            btnSalirDelSistema.Location = new Point(519, 26);
            btnSalirDelSistema.Margin = new Padding(3, 2, 3, 2);
            btnSalirDelSistema.Name = "btnSalirDelSistema";
            btnSalirDelSistema.Size = new Size(130, 22);
            btnSalirDelSistema.TabIndex = 2;
            btnSalirDelSistema.Text = "Salir del sistema";
            btnSalirDelSistema.UseVisualStyleBackColor = true;
            btnSalirDelSistema.Click += btnSalirDelSistema_Click;
            // 
            // lblNombreApellido
            // 
            lblNombreApellido.AutoSize = true;
            lblNombreApellido.Location = new Point(77, 60);
            lblNombreApellido.Name = "lblNombreApellido";
            lblNombreApellido.Size = new Size(98, 15);
            lblNombreApellido.TabIndex = 3;
            lblNombreApellido.Text = "Nombre Apellido";
            // 
            // lblAdmin
            // 
            lblAdmin.AutoSize = true;
            lblAdmin.Location = new Point(32, 60);
            lblAdmin.Name = "lblAdmin";
            lblAdmin.Size = new Size(46, 15);
            lblAdmin.TabIndex = 4;
            lblAdmin.Text = "Admin:";
            // 
            // MenuAdminForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(690, 406);
            Controls.Add(lblAdmin);
            Controls.Add(lblNombreApellido);
            Controls.Add(btnSalirDelSistema);
            Controls.Add(panel1);
            Controls.Add(lblTituloMenuAdmin);
            Margin = new Padding(3, 2, 3, 2);
            Name = "MenuAdminForm";
            Text = "Administrador";
            Load += MenuAdminForm_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTituloMenuAdmin;
        private Panel panel1;
        private Button btnSalirDelSistema;
        private Label lblNombreApellido;
        private Label lblTituloPanelAcciones;
        private Button btnAdministrarUsuarios;
        private Label lblAdmin;
        private Button btnAdministrarCiudades;

        // Botón para abrir formulario de Pasajeros
        private Button btnAdministrarPasajeros;
        private Button btnAdministrarServicios;
        private Button button1;
    }
}