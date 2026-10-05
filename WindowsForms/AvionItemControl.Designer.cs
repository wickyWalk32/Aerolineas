namespace WindowsForms
{
    partial class AvionItemControl
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
            labelCodigoAsiento = new Label();
            SuspendLayout();
            // 
            // labelCodigoAsiento
            // 
            labelCodigoAsiento.AutoSize = true;
            labelCodigoAsiento.Location = new Point(24, 20);
            labelCodigoAsiento.Name = "labelCodigoAsiento";
            labelCodigoAsiento.Size = new Size(23, 15);
            labelCodigoAsiento.TabIndex = 0;
            labelCodigoAsiento.Text = "AA";
            // 
            // AvionItemControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BorderStyle = BorderStyle.FixedSingle;
            Controls.Add(labelCodigoAsiento);
            Name = "AvionItemControl";
            Size = new Size(69, 54);
            Load += AvionItemControl_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelCodigoAsiento;
    }
}
