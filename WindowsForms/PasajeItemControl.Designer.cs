namespace WindowsForms
{
    partial class PasajeItemControl
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
            labelNombreYTipo = new Label();
            labelServicios = new Label();
            labelDNI = new Label();
            labelAsiento = new Label();
            SuspendLayout();
            // 
            // labelNombreYTipo
            // 
            labelNombreYTipo.AutoSize = true;
            labelNombreYTipo.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            labelNombreYTipo.Location = new Point(13, 10);
            labelNombreYTipo.Name = "labelNombreYTipo";
            labelNombreYTipo.Size = new Size(107, 20);
            labelNombreYTipo.TabIndex = 0;
            labelNombreYTipo.Text = "NombreYTipo";
            // 
            // labelServicios
            // 
            labelServicios.AutoSize = true;
            labelServicios.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            labelServicios.Location = new Point(13, 65);
            labelServicios.Name = "labelServicios";
            labelServicios.Size = new Size(57, 15);
            labelServicios.TabIndex = 1;
            labelServicios.Text = "Servicios";
            // 
            // labelDNI
            // 
            labelDNI.AutoSize = true;
            labelDNI.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            labelDNI.Location = new Point(13, 40);
            labelDNI.Name = "labelDNI";
            labelDNI.Size = new Size(29, 15);
            labelDNI.TabIndex = 2;
            labelDNI.Text = "DNI";
            // 
            // labelAsiento
            // 
            labelAsiento.AutoSize = true;
            labelAsiento.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            labelAsiento.Location = new Point(243, 12);
            labelAsiento.Name = "labelAsiento";
            labelAsiento.Size = new Size(59, 19);
            labelAsiento.TabIndex = 3;
            labelAsiento.Text = "Asiento";
            // 
            // PasajeItemControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            BorderStyle = BorderStyle.FixedSingle;
            Controls.Add(labelAsiento);
            Controls.Add(labelDNI);
            Controls.Add(labelServicios);
            Controls.Add(labelNombreYTipo);
            Name = "PasajeItemControl";
            Size = new Size(339, 83);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelNombreYTipo;
        private Label labelServicios;
        private Label labelDNI;
        private Label labelAsiento;
    }
}
