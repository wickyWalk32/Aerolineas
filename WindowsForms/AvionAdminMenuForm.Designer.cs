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
            lblTitulo.Location = new Point(251, 9);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(181, 25);
            lblTitulo.TabIndex = 6;
            lblTitulo.Text = "Administrar Aviones";
            // 
            // btnNuevoAvion
            // 
            btnNuevoAvion.Location = new Point(210, 50);
            btnNuevoAvion.Name = "btnNuevoAvion";
            btnNuevoAvion.Size = new Size(260, 36);
            btnNuevoAvion.TabIndex = 7;
            btnNuevoAvion.Text = "Crear Aviones";
            btnNuevoAvion.UseVisualStyleBackColor = true;
            btnNuevoAvion.Click += btnNuevoAvion_Click;
            // 
            // btnVolver
            // 
            btnVolver.Location = new Point(112, 488);
            btnVolver.Name = "btnVolver";
            btnVolver.Size = new Size(88, 22);
            btnVolver.TabIndex = 11;
            btnVolver.Text = "Volver";
            btnVolver.UseVisualStyleBackColor = true;
            btnVolver.Click += btnVolver_Click;
            // 
            // flowLayoutPanelAviones
            // 
            flowLayoutPanelAviones.AutoScroll = true;
            flowLayoutPanelAviones.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanelAviones.Location = new Point(12, 92);
            flowLayoutPanelAviones.Name = "flowLayoutPanelAviones";
            flowLayoutPanelAviones.Size = new Size(669, 345);
            flowLayoutPanelAviones.TabIndex = 15;
            flowLayoutPanelAviones.WrapContents = false;
            // 
            // AvionAdminMenuForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(692, 578);
            Controls.Add(flowLayoutPanelAviones);
            Controls.Add(lblTitulo);
            Controls.Add(btnNuevoAvion);
            Controls.Add(btnVolver);
            Name = "AvionAdminMenuForm";
            Text = "Administrador";
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