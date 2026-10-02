namespace WindowsForms
{
    partial class AvionAdminMenuForm
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
            lblTitulo = new Label();
            btnNuevoAvion = new Button();
            btnEditarAvion = new Button();
            btnMostrarAviones = new Button();
            btnEliminarAvion = new Button();
            btnVolver = new Button();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 14F);
            lblTitulo.Location = new Point(346, 109);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(227, 32);
            lblTitulo.TabIndex = 6;
            lblTitulo.Text = "Administrar Aviones";
            // 
            // btnNuevoAvion
            // 
            btnNuevoAvion.Location = new Point(311, 183);
            btnNuevoAvion.Margin = new Padding(3, 4, 3, 4);
            btnNuevoAvion.Name = "btnNuevoAvion";
            btnNuevoAvion.Size = new Size(297, 48);
            btnNuevoAvion.TabIndex = 7;
            btnNuevoAvion.Text = "Crear Aviones";
            btnNuevoAvion.UseVisualStyleBackColor = true;
            btnNuevoAvion.Click += btnNuevoAvion_Click;
            // 
            // btnEditarAvion
            // 
            btnEditarAvion.Location = new Point(311, 247);
            btnEditarAvion.Margin = new Padding(3, 4, 3, 4);
            btnEditarAvion.Name = "btnEditarAvion";
            btnEditarAvion.Size = new Size(297, 48);
            btnEditarAvion.TabIndex = 8;
            btnEditarAvion.Text = "Modificar Aviones";
            btnEditarAvion.UseVisualStyleBackColor = true;
            btnEditarAvion.Click += btnEditarAvion_Click;
            // 
            // btnMostrarAviones
            // 
            btnMostrarAviones.Location = new Point(311, 311);
            btnMostrarAviones.Margin = new Padding(3, 4, 3, 4);
            btnMostrarAviones.Name = "btnMostrarAviones";
            btnMostrarAviones.Size = new Size(297, 48);
            btnMostrarAviones.TabIndex = 9;
            btnMostrarAviones.Text = "Mostrar Aviones";
            btnMostrarAviones.UseVisualStyleBackColor = true;
            btnMostrarAviones.Click += btnMostrarAviones_Click;
            // 
            // btnEliminarAvion
            // 
            btnEliminarAvion.Location = new Point(311, 375);
            btnEliminarAvion.Margin = new Padding(3, 4, 3, 4);
            btnEliminarAvion.Name = "btnEliminarAvion";
            btnEliminarAvion.Size = new Size(297, 48);
            btnEliminarAvion.TabIndex = 10;
            btnEliminarAvion.Text = "Eliminar Aviones";
            btnEliminarAvion.UseVisualStyleBackColor = true;
            btnEliminarAvion.Click += btnEliminarAvion_Click;
            // 
            // btnVolver
            // 
            btnVolver.Location = new Point(311, 484);
            btnVolver.Margin = new Padding(3, 4, 3, 4);
            btnVolver.Name = "btnVolver";
            btnVolver.Size = new Size(100, 30);
            btnVolver.TabIndex = 11;
            btnVolver.Text = "Volver";
            btnVolver.UseVisualStyleBackColor = true;
            btnVolver.Click += btnVolver_Click;
            // 
            // AvionAdminMenuForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(914, 600);
            Controls.Add(lblTitulo);
            Controls.Add(btnNuevoAvion);
            Controls.Add(btnEditarAvion);
            Controls.Add(btnMostrarAviones);
            Controls.Add(btnEliminarAvion);
            Controls.Add(btnVolver);
            Margin = new Padding(3, 4, 3, 4);
            Name = "AvionAdminMenuForm";
            Text = "Administrador";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitulo;
        private Button btnNuevoAvion;
        private Button btnEditarAvion;
        private Button btnMostrarAviones;
        private Button btnEliminarAvion;
        private Button btnVolver;
    }
}