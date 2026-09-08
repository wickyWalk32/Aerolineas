using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

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
            btnAdministrarPasajeros = new Button();
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
            lblTituloMenuAdmin.Location = new Point(38, 34);
            lblTituloMenuAdmin.Margin = new Padding(4, 0, 4, 0);
            lblTituloMenuAdmin.Name = "lblTituloMenuAdmin";
            lblTituloMenuAdmin.Size = new Size(359, 45);
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
            panel1.Controls.Add(btnAdministrarPasajeros);
            panel1.Location = new Point(306, 139);
            panel1.Margin = new Padding(4, 4, 4, 4);
            panel1.Name = "panel1";
            panel1.Size = new Size(372, 300);
            panel1.TabIndex = 1;
            // 
            // lblTituloPanelAcciones
            // 
            lblTituloPanelAcciones.AutoSize = true;
            lblTituloPanelAcciones.Font = new Font("Segoe UI", 12F);
            lblTituloPanelAcciones.Location = new Point(134, 30);
            lblTituloPanelAcciones.Margin = new Padding(4, 0, 4, 0);
            lblTituloPanelAcciones.Name = "lblTituloPanelAcciones";
            lblTituloPanelAcciones.Size = new Size(108, 32);
            lblTituloPanelAcciones.TabIndex = 3;
            lblTituloPanelAcciones.Text = "Acciones";
            // 
            // btnAdministrarCiudades
            // 
            btnAdministrarCiudades.Location = new Point(85, 188);
            btnAdministrarCiudades.Margin = new Padding(4, 4, 4, 4);
            btnAdministrarCiudades.Name = "btnAdministrarCiudades";
            btnAdministrarCiudades.Size = new Size(206, 36);
            btnAdministrarCiudades.TabIndex = 2;
            btnAdministrarCiudades.Text = "Administrar Ciudades";
            btnAdministrarCiudades.UseVisualStyleBackColor = true;
            btnAdministrarCiudades.Click += btnAdministrarCiudades_Click;
            // 
            // btnAdministrarPaises
            // 
            btnAdministrarPaises.Location = new Point(85, 131);
            btnAdministrarPaises.Margin = new Padding(4, 4, 4, 4);
            btnAdministrarPaises.Name = "btnAdministrarPaises";
            btnAdministrarPaises.Size = new Size(206, 36);
            btnAdministrarPaises.TabIndex = 1;
            btnAdministrarPaises.Text = "Administrar Paises";
            btnAdministrarPaises.UseVisualStyleBackColor = true;
            btnAdministrarPaises.Click += btnAdministrarPaises_Click;
            // 
            // btnAdministrarUsuarios
            // 
            btnAdministrarUsuarios.Location = new Point(85, 75);
            btnAdministrarUsuarios.Margin = new Padding(4, 4, 4, 4);
            btnAdministrarUsuarios.Name = "btnAdministrarUsuarios";
            btnAdministrarUsuarios.Size = new Size(206, 36);
            btnAdministrarUsuarios.TabIndex = 0;
            btnAdministrarUsuarios.Text = "Administrar Usuarios";
            btnAdministrarUsuarios.UseVisualStyleBackColor = true;
            btnAdministrarUsuarios.Click += btnAdministrarUsuarios_Click;
            // 
            // btnAdministrarPasajeros
            // 
            btnAdministrarPasajeros.Location = new Point(85, 244);
            btnAdministrarPasajeros.Margin = new Padding(4, 4, 4, 4);
            btnAdministrarPasajeros.Name = "btnAdministrarPasajeros";
            btnAdministrarPasajeros.Size = new Size(206, 36);
            btnAdministrarPasajeros.TabIndex = 4;
            btnAdministrarPasajeros.Text = "Administrar Pasajeros";
            btnAdministrarPasajeros.UseVisualStyleBackColor = true;
            btnAdministrarPasajeros.Click += btnAdministrarPasajeros_Click;
            // 
            // btnSalir
            // 
            btnSalir.Location = new Point(808, 44);
            btnSalir.Margin = new Padding(4, 4, 4, 4);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(118, 36);
            btnSalir.TabIndex = 2;
            btnSalir.Text = "Salir";
            btnSalir.UseVisualStyleBackColor = true;
            btnSalir.Click += btnSalir_Click;
            // 
            // lblNombreApellido
            // 
            lblNombreApellido.AutoSize = true;
            lblNombreApellido.Location = new Point(644, 49);
            lblNombreApellido.Margin = new Padding(4, 0, 4, 0);
            lblNombreApellido.Name = "lblNombreApellido";
            lblNombreApellido.Size = new Size(149, 25);
            lblNombreApellido.TabIndex = 3;
            lblNombreApellido.Text = "Nombre Apellido";
            // 
            // lblAdmin
            // 
            lblAdmin.AutoSize = true;
            lblAdmin.Location = new Point(578, 49);
            lblAdmin.Margin = new Padding(4, 0, 4, 0);
            lblAdmin.Name = "lblAdmin";
            lblAdmin.Size = new Size(69, 25);
            lblAdmin.TabIndex = 4;
            lblAdmin.Text = "Admin:";
            // 
            // MenuPrincipalForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1000, 562);
            Controls.Add(lblAdmin);
            Controls.Add(lblNombreApellido);
            Controls.Add(btnSalir);
            Controls.Add(panel1);
            Controls.Add(lblTituloMenuAdmin);
            Margin = new Padding(4, 4, 4, 4);
            Name = "MenuPrincipalForm";
            Text = "Administrador";
            Load += MenuPrincipalForm_Load;
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

        // Botón para abrir formulario de Pasajeros
        private Button btnAdministrarPasajeros;
    }
}