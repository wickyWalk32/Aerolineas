namespace WindowsForms
{
    partial class ServicioAdminMenuForm
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
            btnNuevoServicio = new Button();
            lblTituloAdminServicios = new Label();
            btnVolver = new Button();
            panelListaServicios = new FlowLayoutPanel();
            SuspendLayout();
            // 
            // btnNuevoServicio
            // 
            btnNuevoServicio.Location = new Point(999, 40);
            btnNuevoServicio.Name = "btnNuevoServicio";
            btnNuevoServicio.Size = new Size(171, 29);
            btnNuevoServicio.TabIndex = 0;
            btnNuevoServicio.Text = "Nuevo Servicio";
            btnNuevoServicio.UseVisualStyleBackColor = true;
            btnNuevoServicio.Click += btnNuevoServicio_Click;
            // 
            // lblTituloAdminServicios
            // 
            lblTituloAdminServicios.AutoSize = true;
            lblTituloAdminServicios.Font = new Font("Segoe UI", 16F);
            lblTituloAdminServicios.Location = new Point(70, 30);
            lblTituloAdminServicios.Name = "lblTituloAdminServicios";
            lblTituloAdminServicios.Size = new Size(264, 37);
            lblTituloAdminServicios.TabIndex = 1;
            lblTituloAdminServicios.Text = "Administrar Servicios";
            // 
            // btnVolver
            // 
            btnVolver.Location = new Point(70, 430);
            btnVolver.Name = "btnVolver";
            btnVolver.Size = new Size(180, 30);
            btnVolver.TabIndex = 2;
            btnVolver.Text = "Volver al menú principal";
            btnVolver.UseVisualStyleBackColor = true;
            btnVolver.Click += btnVolver_Click;
            // 
            // panelListaServicios
            // 
            panelListaServicios.AutoScroll = true;
            panelListaServicios.BorderStyle = BorderStyle.FixedSingle;
            panelListaServicios.FlowDirection = FlowDirection.TopDown;
            panelListaServicios.Location = new Point(70, 100);
            panelListaServicios.Name = "panelListaServicios";
            panelListaServicios.Size = new Size(1100, 300);
            panelListaServicios.TabIndex = 3;
            panelListaServicios.WrapContents = false;
            // 
            // ServicioAdminMenuForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1242, 503);
            Controls.Add(panelListaServicios);
            Controls.Add(btnVolver);
            Controls.Add(lblTituloAdminServicios);
            Controls.Add(btnNuevoServicio);
            Name = "ServicioAdminMenuForm";
            Text = "Administrador";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnNuevoServicio;
        private Label lblTituloAdminServicios;
        private Button btnVolver;
        private FlowLayoutPanel panelListaServicios;
    }
}