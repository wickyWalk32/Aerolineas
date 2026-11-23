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
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            SuspendLayout();
            // 
            // btnEditarVuelo
            // 
            btnEditarVuelo.Location = new Point(774, 8);
            btnEditarVuelo.Margin = new Padding(3, 2, 3, 2);
            btnEditarVuelo.Name = "btnEditarVuelo";
            btnEditarVuelo.Size = new Size(79, 22);
            btnEditarVuelo.TabIndex = 0;
            btnEditarVuelo.Text = "Editar";
            btnEditarVuelo.UseVisualStyleBackColor = true;
            btnEditarVuelo.Click += btnEditarVuelo_Click;
            // 
            // btnEliminarVuelo
            // 
            btnEliminarVuelo.Location = new Point(858, 8);
            btnEliminarVuelo.Margin = new Padding(3, 2, 3, 2);
            btnEliminarVuelo.Name = "btnEliminarVuelo";
            btnEliminarVuelo.Size = new Size(79, 22);
            btnEliminarVuelo.TabIndex = 1;
            btnEliminarVuelo.Text = "Eliminar";
            btnEliminarVuelo.UseVisualStyleBackColor = true;
            btnEliminarVuelo.Click += btnEliminarVuelo_Click;
            // 
            // lblId
            // 
            lblId.AutoSize = true;
            lblId.Location = new Point(21, 11);
            lblId.Name = "lblId";
            lblId.Size = new Size(17, 15);
            lblId.TabIndex = 2;
            lblId.Text = "Id";
            lblId.Visible = false;
            // 
            // lblCiudadOrigen
            // 
            lblCiudadOrigen.AutoSize = true;
            lblCiudadOrigen.Font = new Font("Yu Gothic UI Semilight", 11F, FontStyle.Bold);
            lblCiudadOrigen.Location = new Point(105, 11);
            lblCiudadOrigen.Name = "lblCiudadOrigen";
            lblCiudadOrigen.Size = new Size(111, 20);
            lblCiudadOrigen.TabIndex = 3;
            lblCiudadOrigen.Text = "CiudadOrigen";
            // 
            // lblCiudadDestino
            // 
            lblCiudadDestino.AutoSize = true;
            lblCiudadDestino.Font = new Font("Yu Gothic UI Semilight", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblCiudadDestino.Location = new Point(105, 39);
            lblCiudadDestino.Name = "lblCiudadDestino";
            lblCiudadDestino.Size = new Size(117, 20);
            lblCiudadDestino.TabIndex = 4;
            lblCiudadDestino.Text = "CiudadDestino";
            // 
            // lblFecha
            // 
            lblFecha.AutoSize = true;
            lblFecha.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblFecha.Location = new Point(620, 10);
            lblFecha.Name = "lblFecha";
            lblFecha.Size = new Size(49, 20);
            lblFecha.TabIndex = 5;
            lblFecha.Text = "Fecha";
            // 
            // lblHora
            // 
            lblHora.AutoSize = true;
            lblHora.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblHora.Location = new Point(632, 35);
            lblHora.Name = "lblHora";
            lblHora.Size = new Size(47, 21);
            lblHora.TabIndex = 6;
            lblHora.Text = "Hora";
            // 
            // lblPrecio
            // 
            lblPrecio.AutoSize = true;
            lblPrecio.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            lblPrecio.Location = new Point(379, 12);
            lblPrecio.Name = "lblPrecio";
            lblPrecio.Size = new Size(71, 28);
            lblPrecio.TabIndex = 7;
            lblPrecio.Text = "Precio";
            // 
            // lblAerolinea
            // 
            lblAerolinea.AutoSize = true;
            lblAerolinea.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblAerolinea.Location = new Point(774, 34);
            lblAerolinea.Name = "lblAerolinea";
            lblAerolinea.Size = new Size(74, 19);
            lblAerolinea.TabIndex = 8;
            lblAerolinea.Text = "Aerolínea";
            // 
            // lblAvionDescripcion
            // 
            lblAvionDescripcion.AutoSize = true;
            lblAvionDescripcion.Location = new Point(21, 39);
            lblAvionDescripcion.Name = "lblAvionDescripcion";
            lblAvionDescripcion.Size = new Size(38, 15);
            lblAvionDescripcion.TabIndex = 9;
            lblAvionDescripcion.Text = "Avión";
            lblAvionDescripcion.Visible = false;
            // 
            // lblAvionCapacidad
            // 
            lblAvionCapacidad.AutoSize = true;
            lblAvionCapacidad.Location = new Point(279, 38);
            lblAvionCapacidad.Name = "lblAvionCapacidad";
            lblAvionCapacidad.Size = new Size(94, 15);
            lblAvionCapacidad.TabIndex = 10;
            lblAvionCapacidad.Text = "AviónCapacidad";
            lblAvionCapacidad.Visible = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Yu Gothic UI Semilight", 10F, FontStyle.Bold);
            label2.Location = new Point(87, 12);
            label2.Name = "label2";
            label2.Size = new Size(0, 19);
            label2.TabIndex = 12;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            label3.Location = new Point(392, 12);
            label3.Name = "label3";
            label3.Size = new Size(0, 28);
            label3.TabIndex = 14;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label4.Location = new Point(676, 35);
            label4.Name = "label4";
            label4.Size = new Size(33, 21);
            label4.TabIndex = 15;
            label4.Text = "Hs.";
            // 
            // VueloItemControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BorderStyle = BorderStyle.FixedSingle;
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
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
            Margin = new Padding(3, 2, 3, 2);
            Name = "VueloItemControl";
            Size = new Size(950, 66);
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
        private Label label2;
        private Label label1;
        private Label label3;
        private Label label4;
    }
}
