namespace WindowsForms
{
    partial class MenuAvionesForm
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
            lblTitulo.Location = new Point(275, 85);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(181, 25);
            lblTitulo.TabIndex = 6;
            lblTitulo.Text = "Administrar Aviones";
            // 
            // btnCrearPasajero
            // 
            btnCrearPasajero.Location = new Point(272, 137);
            btnCrearPasajero.Name = "btnCrearPasajero";
            btnCrearPasajero.Size = new Size(260, 36);
            btnCrearPasajero.TabIndex = 7;
            btnCrearPasajero.Text = "Crear Aviones";
            btnCrearPasajero.UseVisualStyleBackColor = true;
            // 
            // btnModificarPasajero
            // 
            btnModificarPasajero.Location = new Point(272, 185);
            btnModificarPasajero.Name = "btnModificarPasajero";
            btnModificarPasajero.Size = new Size(260, 36);
            btnModificarPasajero.TabIndex = 8;
            btnModificarPasajero.Text = "Modificar Aviones";
            btnModificarPasajero.UseVisualStyleBackColor = true;
            btnModificarPasajero.Click += btnModificarPasajero_Click;
            // 
            // btnMostrarPasajeros
            // 
            btnMostrarPasajeros.Location = new Point(272, 233);
            btnMostrarPasajeros.Name = "btnMostrarPasajeros";
            btnMostrarPasajeros.Size = new Size(260, 36);
            btnMostrarPasajeros.TabIndex = 9;
            btnMostrarPasajeros.Text = "Mostrar Aviones";
            btnMostrarPasajeros.UseVisualStyleBackColor = true;
            // 
            // btnEliminarPasajero
            // 
            btnEliminarPasajero.Location = new Point(272, 281);
            btnEliminarPasajero.Name = "btnEliminarPasajero";
            btnEliminarPasajero.Size = new Size(260, 36);
            btnEliminarPasajero.TabIndex = 10;
            btnEliminarPasajero.Text = "Eliminar Aviones";
            btnEliminarPasajero.UseVisualStyleBackColor = true;
            // 
            // btnVolver
            // 
            btnVolver.Location = new Point(272, 335);
            btnVolver.Name = "btnVolver";
            btnVolver.Size = new Size(100, 30);
            btnVolver.TabIndex = 11;
            btnVolver.Text = "Volver";
            btnVolver.UseVisualStyleBackColor = true;
            // 
            // MenuAvionesForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(lblTitulo);
            Controls.Add(btnCrearPasajero);
            Controls.Add(btnModificarPasajero);
            Controls.Add(btnMostrarPasajeros);
            Controls.Add(btnEliminarPasajero);
            Controls.Add(btnVolver);
            Name = "MenuAvionesForm";
            Text = "Form1";
            Load += MenuAvionesForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitulo;
        private Button btnCrearPasajero;
        private Button btnModificarPasajero;
        private Button btnMostrarPasajeros;
        private Button btnEliminarPasajero;
        private Button btnVolver;
    }
}