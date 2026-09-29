namespace WindowsForms
{
    partial class VueloItemControl
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
            btnEditarVuelo = new Button();
            btnEliminarVuelo = new Button();
            lblId = new Label();
            lblCiudadOrigen = new Label();
            lblCiudadDestino = new Label();
            lblFecha = new Label();
            lblHora = new Label();
            lblPrecio = new Label();
            lblAerolinea = new Label();
            lblAvionDescripcion = new Label();
            lblAvionCapacidad = new Label();
            SuspendLayout();
            // 
            // btnEditarVuelo
            // 
            btnEditarVuelo.Location = new Point(1101, 11);
            btnEditarVuelo.Name = "btnEditarVuelo";
            btnEditarVuelo.Size = new Size(90, 29);
            btnEditarVuelo.TabIndex = 0;
            btnEditarVuelo.Text = "Editar";
            btnEditarVuelo.UseVisualStyleBackColor = true;
            // 
            // btnEliminarVuelo
            // 
            btnEliminarVuelo.Location = new Point(1197, 11);
            btnEliminarVuelo.Name = "btnEliminarVuelo";
            btnEliminarVuelo.Size = new Size(90, 29);
            btnEliminarVuelo.TabIndex = 1;
            btnEliminarVuelo.Text = "Eliminar";
            btnEliminarVuelo.UseVisualStyleBackColor = true;
            // 
            // lblId
            // 
            lblId.AutoSize = true;
            lblId.Location = new Point(24, 15);
            lblId.Name = "lblId";
            lblId.Size = new Size(22, 20);
            lblId.TabIndex = 2;
            lblId.Text = "Id";
            // 
            // lblCiudadOrigen
            // 
            lblCiudadOrigen.AutoSize = true;
            lblCiudadOrigen.Location = new Point(81, 15);
            lblCiudadOrigen.Name = "lblCiudadOrigen";
            lblCiudadOrigen.Size = new Size(101, 20);
            lblCiudadOrigen.TabIndex = 3;
            lblCiudadOrigen.Text = "CiudadOrigen";
            // 
            // lblCiudadDestino
            // 
            lblCiudadDestino.AutoSize = true;
            lblCiudadDestino.Location = new Point(270, 15);
            lblCiudadDestino.Name = "lblCiudadDestino";
            lblCiudadDestino.Size = new Size(107, 20);
            lblCiudadDestino.TabIndex = 4;
            lblCiudadDestino.Text = "CiudadDestino";
            // 
            // lblFecha
            // 
            lblFecha.AutoSize = true;
            lblFecha.Location = new Point(490, 15);
            lblFecha.Name = "lblFecha";
            lblFecha.Size = new Size(47, 20);
            lblFecha.TabIndex = 5;
            lblFecha.Text = "Fecha";
            // 
            // lblHora
            // 
            lblHora.AutoSize = true;
            lblHora.Location = new Point(600, 15);
            lblHora.Name = "lblHora";
            lblHora.Size = new Size(42, 20);
            lblHora.TabIndex = 6;
            lblHora.Text = "Hora";
            // 
            // lblPrecio
            // 
            lblPrecio.AutoSize = true;
            lblPrecio.Location = new Point(697, 15);
            lblPrecio.Name = "lblPrecio";
            lblPrecio.Size = new Size(50, 20);
            lblPrecio.TabIndex = 7;
            lblPrecio.Text = "Precio";
            // 
            // lblAerolinea
            // 
            lblAerolinea.AutoSize = true;
            lblAerolinea.Location = new Point(329, 35);
            lblAerolinea.Name = "lblAerolinea";
            lblAerolinea.Size = new Size(73, 20);
            lblAerolinea.TabIndex = 8;
            lblAerolinea.Text = "Aerolínea";
            // 
            // lblAvionDescripcion
            // 
            lblAvionDescripcion.AutoSize = true;
            lblAvionDescripcion.Location = new Point(24, 50);
            lblAvionDescripcion.Name = "lblAvionDescripcion";
            lblAvionDescripcion.Size = new Size(47, 20);
            lblAvionDescripcion.TabIndex = 9;
            lblAvionDescripcion.Text = "Avión";
            // 
            // lblAvionCapacidad
            // 
            lblAvionCapacidad.AutoSize = true;
            lblAvionCapacidad.Location = new Point(177, 51);
            lblAvionCapacidad.Name = "lblAvionCapacidad";
            lblAvionCapacidad.Size = new Size(118, 20);
            lblAvionCapacidad.TabIndex = 10;
            lblAvionCapacidad.Text = "AviónCapacidad";
            // 
            // VueloItemControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(lblAvionCapacidad);
            Controls.Add(lblAvionDescripcion);
            Controls.Add(lblAerolinea);
            Controls.Add(lblPrecio);
            Controls.Add(lblHora);
            Controls.Add(lblFecha);
            Controls.Add(lblCiudadDestino);
            Controls.Add(lblCiudadOrigen);
            Controls.Add(lblId);
            Controls.Add(btnEliminarVuelo);
            Controls.Add(btnEditarVuelo);
            Name = "VueloItemControl";
            Size = new Size(1310, 90);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnEditarVuelo;
        private Button btnEliminarVuelo;
        private Label lblId;
        private Label lblCiudadOrigen;
        private Label lblCiudadDestino;
        private Label lblFecha;
        private Label lblHora;
        private Label lblPrecio;
        private Label lblAerolinea;
        private Label lblAvionDescripcion;
        private Label lblAvionCapacidad;
    }
}
