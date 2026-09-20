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
            lblTitulo.Font = new Font("Segoe UI", 14F);
            lblTitulo.Location = new Point(24, 18);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(240, 32);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Administrar Pasajeros";
            // 
            // btnCrearPasajero
            // 
            btnCrearPasajero.Location = new Point(28, 70);
            btnCrearPasajero.Name = "btnCrearPasajero";
            btnCrearPasajero.Size = new Size(260, 36);
            btnCrearPasajero.TabIndex = 1;
            btnCrearPasajero.Text = "Crear pasajero";
            btnCrearPasajero.UseVisualStyleBackColor = true;
            btnCrearPasajero.Click += BtnCrearPasajero_Click;
            // 
            // btnModificarPasajero
            // 
            btnModificarPasajero.Location = new Point(28, 118);
            btnModificarPasajero.Name = "btnModificarPasajero";
            btnModificarPasajero.Size = new Size(260, 36);
            btnModificarPasajero.TabIndex = 2;
            btnModificarPasajero.Text = "Modificar pasajero";
            btnModificarPasajero.UseVisualStyleBackColor = true;
            btnModificarPasajero.Click += BtnModificarPasajero_Click;
            // 
            // btnMostrarPasajeros
            // 
            btnMostrarPasajeros.Location = new Point(28, 166);
            btnMostrarPasajeros.Name = "btnMostrarPasajeros";
            btnMostrarPasajeros.Size = new Size(260, 36);
            btnMostrarPasajeros.TabIndex = 3;
            btnMostrarPasajeros.Text = "Mostrar pasajeros";
            btnMostrarPasajeros.UseVisualStyleBackColor = true;
            btnMostrarPasajeros.Click += BtnMostrarPasajeros_Click;
            // 
            // btnEliminarPasajero
            // 
            btnEliminarPasajero.Location = new Point(28, 214);
            btnEliminarPasajero.Name = "btnEliminarPasajero";
            btnEliminarPasajero.Size = new Size(260, 36);
            btnEliminarPasajero.TabIndex = 4;
            btnEliminarPasajero.Text = "Eliminar pasajero";
            btnEliminarPasajero.UseVisualStyleBackColor = true;
            btnEliminarPasajero.Click += BtnEliminarPasajero_Click;
            // 
            // btnVolver
            // 
            btnVolver.Location = new Point(28, 268);
            btnVolver.Name = "btnVolver";
            btnVolver.Size = new Size(100, 30);
            btnVolver.TabIndex = 5;
            btnVolver.Text = "Volver";
            btnVolver.UseVisualStyleBackColor = true;
            btnVolver.Click += BtnVolver_Click;
            // 
            // PasajeroAdminMenuForm
            // 
            ClientSize = new Size(320, 316);
            Controls.Add(lblTitulo);
            Controls.Add(btnCrearPasajero);
            Controls.Add(btnModificarPasajero);
            Controls.Add(btnMostrarPasajeros);
            Controls.Add(btnEliminarPasajero);
            Controls.Add(btnVolver);
            Name = "PasajeroAdminMenuForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Administrar Pasajeros";
            ResumeLayout(false);
            PerformLayout();
        }
    }
}