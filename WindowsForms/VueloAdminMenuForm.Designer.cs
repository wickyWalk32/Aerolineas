using System.Windows.Forms;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace WindowsForms
{
    partial class VueloAdminMenuForm
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

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            btnNuevoVuelo = new Button();
            btnVolver = new Button();
            label1 = new Label();
            panelListaVuelos = new FlowLayoutPanel();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Segoe UI", 16F);
            label1.Location = new Point(70, 30);
            label1.Name = "label1";
            label1.Size = new Size(240, 37);
            label1.TabIndex = 2;
            label1.Text = "Administrar Vuelos";
            // 
            // btnNuevoVuelo
            // 
            btnNuevoVuelo.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnNuevoVuelo.Location = new Point(1030, 36);
            btnNuevoVuelo.Name = "btnNuevoVuelo";
            btnNuevoVuelo.Size = new Size(140, 32);
            btnNuevoVuelo.TabIndex = 0;
            btnNuevoVuelo.Text = "Nuevo Vuelo";
            btnNuevoVuelo.UseVisualStyleBackColor = true;
            btnNuevoVuelo.Click += btnNuevoVuelo_Click;
            // 
            // panelListaVuelos
            // 
            panelListaVuelos.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panelListaVuelos.AutoScroll = true;
            panelListaVuelos.FlowDirection = FlowDirection.TopDown;
            panelListaVuelos.Location = new Point(70, 95);
            panelListaVuelos.Name = "panelListaVuelos";
            panelListaVuelos.Size = new Size(1100, 495);
            panelListaVuelos.TabIndex = 3;
            panelListaVuelos.WrapContents = false;
            // 
            // btnVolver
            // 
            btnVolver.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnVolver.Location = new Point(70, 616);
            btnVolver.Name = "btnVolver";
            btnVolver.Size = new Size(180, 32);
            btnVolver.TabIndex = 1;
            btnVolver.Text = "Volver al menú principal";
            btnVolver.UseVisualStyleBackColor = true;
            btnVolver.Click += btnVolver_Click;
            // 
            // VueloAdminMenuForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1242, 688);
            WindowState = FormWindowState.Maximized;
            Controls.Add(panelListaVuelos);
            Controls.Add(label1);
            Controls.Add(btnVolver);
            Controls.Add(btnNuevoVuelo);
            Name = "VueloAdminMenuForm";
            Text = "AeroReservas - Administrar Vuelos";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnNuevoVuelo;
        private Button btnVolver;
        private Label label1;
        private FlowLayoutPanel panelListaVuelos;
    }
}