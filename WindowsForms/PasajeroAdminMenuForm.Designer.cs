using System;
using System.Windows.Forms;

namespace WindowsForms
{
    partial class PasajeroAdminMenuForm
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblTitulo;
        private Button btnCrearPasajero;
        private Button btnModificarPasajero;
        private Button btnMostrarPasajeros;
        private Button btnEliminarPasajero;
        private Button btnVolver;

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            lblTitulo = new Label();
            btnCrearPasajero = new Button();
            btnModificarPasajero = new Button();
            btnMostrarPasajeros = new Button();
            btnEliminarPasajero = new Button();
            btnVolver = new Button();

            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new System.Drawing.Font("Segoe UI", 14F);
            lblTitulo.Location = new System.Drawing.Point(24, 18);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new System.Drawing.Size(236, 32);
            lblTitulo.Text = "Administrar Pasajeros";
            // 
            // btnCrearPasajero
            // 
            btnCrearPasajero.Location = new System.Drawing.Point(28, 70);
            btnCrearPasajero.Name = "btnCrearPasajero";
            btnCrearPasajero.Size = new System.Drawing.Size(260, 36);
            btnCrearPasajero.Text = "Crear pasajero";
            btnCrearPasajero.UseVisualStyleBackColor = true;
            btnCrearPasajero.Click += BtnCrearPasajero_Click;
            // 
            // btnModificarPasajero
            // 
            btnModificarPasajero.Location = new System.Drawing.Point(28, 118);
            btnModificarPasajero.Name = "btnModificarPasajero";
            btnModificarPasajero.Size = new System.Drawing.Size(260, 36);
            btnModificarPasajero.Text = "Modificar pasajero";
            btnModificarPasajero.UseVisualStyleBackColor = true;
            btnModificarPasajero.Click += BtnModificarPasajero_Click;
            // 
            // btnMostrarPasajeros
            // 
            btnMostrarPasajeros.Location = new System.Drawing.Point(28, 166);
            btnMostrarPasajeros.Name = "btnMostrarPasajeros";
            btnMostrarPasajeros.Size = new System.Drawing.Size(260, 36);
            btnMostrarPasajeros.Text = "Mostrar pasajeros";
            btnMostrarPasajeros.UseVisualStyleBackColor = true;
            btnMostrarPasajeros.Click += BtnMostrarPasajeros_Click;
            // 
            // btnEliminarPasajero
            // 
            btnEliminarPasajero.Location = new System.Drawing.Point(28, 214);
            btnEliminarPasajero.Name = "btnEliminarPasajero";
            btnEliminarPasajero.Size = new System.Drawing.Size(260, 36);
            btnEliminarPasajero.Text = "Eliminar pasajero";
            btnEliminarPasajero.UseVisualStyleBackColor = true;
            btnEliminarPasajero.Click += BtnEliminarPasajero_Click;
            // 
            // btnVolver
            // 
            btnVolver.Location = new System.Drawing.Point(188, 266);
            btnVolver.Name = "btnVolver";
            btnVolver.Size = new System.Drawing.Size(100, 30);
            btnVolver.Text = "Volver";
            btnVolver.UseVisualStyleBackColor = true;
            btnVolver.Click += BtnVolver_Click;
            // 
            // PasajeroAdminMenuForm
            // 
            ClientSize = new System.Drawing.Size(320, 310);
            Controls.Add(lblTitulo);
            Controls.Add(btnCrearPasajero);
            Controls.Add(btnModificarPasajero);
            Controls.Add(btnMostrarPasajeros);
            Controls.Add(btnEliminarPasajero);
            Controls.Add(btnVolver);
            Name = "PasajeroAdminMenuForm";
            Text = "Administrar Pasajeros";
            StartPosition = FormStartPosition.CenterParent;
            ResumeLayout(false);
            PerformLayout();
        }
    }
}