namespace WindowsForms
{
    partial class AvionControl
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        private void InitializeComponent()
        {
            panelAvion = new Panel();
            SuspendLayout();
            // 
            // panelAvion
            // 
            panelAvion.AutoScroll = true;
            panelAvion.Location = new Point(3, 3);
            panelAvion.Name = "panelAvion";
            panelAvion.Size = new Size(230, 639);
            panelAvion.TabIndex = 0;
            panelAvion.Paint += panelAvion_Paint;
            // 
            // AvionControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panelAvion);
            Name = "AvionControl";
            Size = new Size(237, 645);
            ResumeLayout(false);
        }

        #endregion

        private Panel panelAvion;
    }
}
