namespace WindowsForms
{
    partial class AvionAdminMenuForm
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
            btnNuevoAvion = new Button();
            btnVolver = new Button();
            flowLayoutPanelAviones = new FlowLayoutPanel();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 14F);
            lblTitulo.Location = new Point(287, 12);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(227, 32);
            lblTitulo.TabIndex = 6;
            lblTitulo.Text = "Administrar Aviones";
            // 
            // btnNuevoAvion
            // 
            btnNuevoAvion.Location = new Point(240, 67);
            btnNuevoAvion.Margin = new Padding(3, 4, 3, 4);
            btnNuevoAvion.Name = "btnNuevoAvion";
            btnNuevoAvion.Size = new Size(297, 48);
            btnNuevoAvion.TabIndex = 7;
            btnNuevoAvion.Text = "Crear Aviones";
            btnNuevoAvion.UseVisualStyleBackColor = true;
            btnNuevoAvion.Click += btnNuevoAvion_Click;
            // 
            // btnVolver
            // 
            btnVolver.Location = new Point(128, 651);
            btnVolver.Margin = new Padding(3, 4, 3, 4);
            btnVolver.Name = "btnVolver";
            btnVolver.Size = new Size(101, 29);
            btnVolver.TabIndex = 11;
            btnVolver.Text = "Volver";
            btnVolver.UseVisualStyleBackColor = true;
            btnVolver.Click += btnVolver_Click;
            // 
            // flowLayoutPanelAviones
            // 
            flowLayoutPanelAviones.AutoScroll = true;
            flowLayoutPanelAviones.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanelAviones.Location = new Point(14, 123);
            flowLayoutPanelAviones.Margin = new Padding(3, 4, 3, 4);
            flowLayoutPanelAviones.Name = "flowLayoutPanelAviones";
            flowLayoutPanelAviones.Size = new Size(765, 460);
            flowLayoutPanelAviones.TabIndex = 15;
            flowLayoutPanelAviones.WrapContents = false;
            // 
            // AvionAdminMenuForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(791, 771);
            Controls.Add(flowLayoutPanelAviones);
            Controls.Add(lblTitulo);
            Controls.Add(btnNuevoAvion);
            Controls.Add(btnVolver);
            Margin = new Padding(3, 4, 3, 4);
            Name = "AvionAdminMenuForm";
            Text = "Administrador";
            WindowState = FormWindowState.Maximized;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitulo;
        private Button btnNuevoAvion;
        private Button btnVolver;
        private FlowLayoutPanel flowLayoutPanelAviones;
    }
}