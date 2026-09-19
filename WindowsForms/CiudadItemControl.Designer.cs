namespace WindowsForms
{
    partial class CiudadItemControl
    {
        /// <summary> 
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            lblIdCiudad = new Label();
            lblNombreCiudad = new Label();
            btnEditarCiudad = new Button();
            btnEliminarCiudad = new Button();
            lblCodigoPostal = new Label();
            lblCodigoAeropuerto = new Label();
            lblPais = new Label();
            SuspendLayout();
            // 
            // lblIdCiudad
            // 
            lblIdCiudad.AutoSize = true;
            lblIdCiudad.Location = new Point(23, 14);
            lblIdCiudad.Name = "lblIdCiudad";
            lblIdCiudad.Size = new Size(22, 20);
            lblIdCiudad.TabIndex = 0;
            lblIdCiudad.Text = "Id";
            // 
            // lblNombreCiudad
            // 
            lblNombreCiudad.AutoSize = true;
            lblNombreCiudad.Location = new Point(73, 14);
            lblNombreCiudad.Name = "lblNombreCiudad";
            lblNombreCiudad.Size = new Size(64, 20);
            lblNombreCiudad.TabIndex = 1;
            lblNombreCiudad.Text = "Nombre";
            // 
            // btnEditarCiudad
            // 
            btnEditarCiudad.Location = new Point(624, 10);
            btnEditarCiudad.Name = "btnEditarCiudad";
            btnEditarCiudad.Size = new Size(85, 29);
            btnEditarCiudad.TabIndex = 2;
            btnEditarCiudad.Text = "Editar";
            btnEditarCiudad.UseVisualStyleBackColor = true;
            btnEditarCiudad.Click += btnEditar_Click;
            // 
            // btnEliminarCiudad
            // 
            btnEliminarCiudad.Location = new Point(715, 10);
            btnEliminarCiudad.Name = "btnEliminarCiudad";
            btnEliminarCiudad.Size = new Size(85, 29);
            btnEliminarCiudad.TabIndex = 3;
            btnEliminarCiudad.Text = "Eliminar";
            btnEliminarCiudad.UseVisualStyleBackColor = true;
            btnEliminarCiudad.Click += btnEliminarCiudad_Click;
            // 
            // lblCodigoPostal
            // 
            lblCodigoPostal.AutoSize = true;
            lblCodigoPostal.Location = new Point(260, 14);
            lblCodigoPostal.Name = "lblCodigoPostal";
            lblCodigoPostal.Size = new Size(103, 20);
            lblCodigoPostal.TabIndex = 4;
            lblCodigoPostal.Text = "Codigo postal";
            // 
            // lblCodigoAeropuerto
            // 
            lblCodigoAeropuerto.AutoSize = true;
            lblCodigoAeropuerto.Location = new Point(369, 14);
            lblCodigoAeropuerto.Name = "lblCodigoAeropuerto";
            lblCodigoAeropuerto.Size = new Size(90, 20);
            lblCodigoAeropuerto.TabIndex = 5;
            lblCodigoAeropuerto.Text = "CodigoAero";
            // 
            // lblPais
            // 
            lblPais.AutoSize = true;
            lblPais.Location = new Point(512, 14);
            lblPais.Name = "lblPais";
            lblPais.Size = new Size(34, 20);
            lblPais.TabIndex = 6;
            lblPais.Text = "País";
            // 
            // CiudadItemControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BorderStyle = BorderStyle.FixedSingle;
            Controls.Add(lblPais);
            Controls.Add(lblCodigoAeropuerto);
            Controls.Add(lblCodigoPostal);
            Controls.Add(btnEliminarCiudad);
            Controls.Add(btnEditarCiudad);
            Controls.Add(lblNombreCiudad);
            Controls.Add(lblIdCiudad);
            Name = "CiudadItemControl";
            Size = new Size(818, 46);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblIdCiudad;
        private Label lblNombreCiudad;
        private Button btnEditarCiudad;
        private Button btnEliminarCiudad;
        private Label lblCodigoPostal;
        private Label lblCodigoAeropuerto;
        private Label lblPais;
    }
}
