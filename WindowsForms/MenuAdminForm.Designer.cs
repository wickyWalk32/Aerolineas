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
            lblTituloMenuAdmin.Location = new Point(31, 27);
            lblTituloMenuAdmin.Name = "lblTituloMenuAdmin";
            lblTituloMenuAdmin.Size = new Size(298, 37);
            lblTituloMenuAdmin.TabIndex = 0;
            lblTituloMenuAdmin.Text = "Menú de Administrador";
            // 
            // panel1
            // 
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(btnAdministrarCiudades);
            panel1.Controls.Add(lblTituloPanelAcciones);
            panel1.Controls.Add(btnAdministrarUsuarios);
            panel1.Controls.Add(btnAdministrarPasajeros);
            panel1.Location = new Point(244, 133);
            panel1.Name = "panel1";
            panel1.Size = new Size(298, 334);
            panel1.TabIndex = 1;
            // 
            // btnAdministrarCiudades
            // 
            btnAdministrarCiudades.Location = new Point(65, 111);
            btnAdministrarCiudades.Name = "btnAdministrarCiudades";
            btnAdministrarCiudades.Size = new Size(165, 29);
            btnAdministrarCiudades.TabIndex = 2;
            btnAdministrarCiudades.Text = "Administrar Ciudades";
            btnAdministrarCiudades.UseVisualStyleBackColor = true;
            btnAdministrarCiudades.Click += btnAdministrarCiudades_Click;
            // 
            // lblTituloPanelAcciones
            // 
            lblTituloPanelAcciones.AutoSize = true;
            lblTituloPanelAcciones.Font = new Font("Segoe UI", 12F);
            lblTituloPanelAcciones.Location = new Point(103, 26);
            lblTituloPanelAcciones.Name = "lblTituloPanelAcciones";
            lblTituloPanelAcciones.Size = new Size(89, 28);
            lblTituloPanelAcciones.TabIndex = 3;
            lblTituloPanelAcciones.Text = "Acciones";
            // 
            // btnAdministrarUsuarios
            // 
            btnAdministrarUsuarios.Location = new Point(65, 76);
            btnAdministrarUsuarios.Name = "btnAdministrarUsuarios";
            btnAdministrarUsuarios.Size = new Size(165, 29);
            btnAdministrarUsuarios.TabIndex = 0;
            btnAdministrarUsuarios.Text = "Administrar Usuarios";
            btnAdministrarUsuarios.UseVisualStyleBackColor = true;
            btnAdministrarUsuarios.Click += btnAdministrarUsuarios_Click;
            // 
            // btnAdministrarPasajeros
            // 
            btnAdministrarPasajeros.Location = new Point(65, 146);
            btnAdministrarPasajeros.Name = "btnAdministrarPasajeros";
            btnAdministrarPasajeros.Size = new Size(165, 29);
            btnAdministrarPasajeros.TabIndex = 4;
            btnAdministrarPasajeros.Text = "Administrar Pasajeros";
            btnAdministrarPasajeros.UseVisualStyleBackColor = true;
            btnAdministrarPasajeros.Click += btnAdministrarPasajeros_Click;
            // 
            // btnSalirDelSistema
            // 
            btnSalirDelSistema.Location = new Point(593, 35);
            btnSalirDelSistema.Name = "btnSalirDelSistema";
            btnSalirDelSistema.Size = new Size(149, 29);
            btnSalirDelSistema.TabIndex = 2;
            btnSalirDelSistema.Text = "Salir del sistema";
            btnSalirDelSistema.UseVisualStyleBackColor = true;
            btnSalirDelSistema.Click += btnSalirDelSistema_Click;
            // 
            // lblNombreApellido
            // 
            lblNombreApellido.AutoSize = true;
            lblNombreApellido.Location = new Point(88, 80);
            lblNombreApellido.Name = "lblNombreApellido";
            lblNombreApellido.Size = new Size(125, 20);
            lblNombreApellido.TabIndex = 3;
            lblNombreApellido.Text = "Nombre Apellido";
            // 
            // lblAdmin
            // 
            lblAdmin.AutoSize = true;
            lblAdmin.Location = new Point(36, 80);
            lblAdmin.Name = "lblAdmin";
            lblAdmin.Size = new Size(56, 20);
            lblAdmin.TabIndex = 4;
            lblAdmin.Text = "Admin:";
            // 
            // MenuAdminForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 542);
            Controls.Add(lblAdmin);
            Controls.Add(lblNombreApellido);
            Controls.Add(btnSalirDelSistema);
            Controls.Add(panel1);
            Controls.Add(lblTituloMenuAdmin);
            Name = "MenuAdminForm";
            Text = "Administrador";
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
    }
}