using System.Windows.Forms;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace WindowsForms
{
    partial class PaisAdminMenuForm
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
            btnNuevoPais = new Button();
            lblTituloAdminPaises = new Label();
            btnVolver = new Button();
            panelListaPaises = new FlowLayoutPanel();
            SuspendLayout();
            // 
            // btnNuevoPais
            // 
            btnNuevoPais.Location = new Point(999, 40);
            btnNuevoPais.Name = "btnNuevoPais";
            btnNuevoPais.Size = new Size(171, 29);
            btnNuevoPais.TabIndex = 0;
            btnNuevoPais.Text = "Nuevo País";
            btnNuevoPais.UseVisualStyleBackColor = true;
            btnNuevoPais.Click += btnNuevoPais_Click;
            // 
            // lblTituloAdminPaises
            // 
            lblTituloAdminPaises.AutoSize = true;
            lblTituloAdminPaises.Font = new System.Drawing.Font("Segoe UI", 16F);
            lblTituloAdminPaises.Location = new Point(70, 30);
            lblTituloAdminPaises.Name = "lblTituloAdminPaises";
            lblTituloAdminPaises.Size = new Size(264, 37);
            lblTituloAdminPaises.TabIndex = 1;
            lblTituloAdminPaises.Text = "Administrar Países";
            // 
            // btnVolver
            // 
            btnVolver.Location = new Point(70, 620);
            btnVolver.Name = "btnVolver";
            btnVolver.Size = new Size(180, 30);
            btnVolver.TabIndex = 2;
            btnVolver.Text = "Volver al menú principal";
            btnVolver.UseVisualStyleBackColor = true;
            btnVolver.Click += btnVolver_Click;
            // 
            // panelListaPaises
            // 
            panelListaPaises.AutoScroll = true;
            panelListaPaises.FlowDirection = FlowDirection.TopDown;
            panelListaPaises.Location = new Point(70, 100);
            panelListaPaises.Name = "panelListaPaises";
            panelListaPaises.Size = new Size(1100, 487);
            panelListaPaises.TabIndex = 3;
            panelListaPaises.WrapContents = false;
            // 
            // PaisAdminMenuForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1242, 688);
            WindowState = FormWindowState.Maximized;
            Controls.Add(panelListaPaises);
            Controls.Add(btnVolver);
            Controls.Add(lblTituloAdminPaises);
            Controls.Add(btnNuevoPais);
            Name = "PaisAdminMenuForm";
            Text = "Administrador - Países";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnNuevoPais;
        private Label lblTituloAdminPaises;
        private Button btnVolver;
        private FlowLayoutPanel panelListaPaises;
    }
}