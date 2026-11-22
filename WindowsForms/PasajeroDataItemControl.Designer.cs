namespace WindowsForms
{
    partial class PasajeroDataItemControl
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
            labelPasajero = new Label();
            SuspendLayout();
            // 
            // labelPasajero
            // 
            labelPasajero.AutoSize = true;
            labelPasajero.Location = new Point(15, 18);
            labelPasajero.Name = "labelPasajero";
            labelPasajero.Size = new Size(19, 15);
            labelPasajero.TabIndex = 0;
            labelPasajero.Text = "00";
            // 
            // PasajeroDataItemControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BorderStyle = BorderStyle.FixedSingle;
            Controls.Add(labelPasajero);
            Name = "PasajeroDataItemControl";
            Size = new Size(48, 44);
            Load += PasajeroDataItemControl_Load;
            Click += PasajeroDataItemControl_Click;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelPasajero;
    }
}
