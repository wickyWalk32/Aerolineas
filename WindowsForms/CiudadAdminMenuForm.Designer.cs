namespace WindowsForms
{
    partial class CiudadAdminMenuForm
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
            lblTituloAdminCiudades = new Label();
            btnNuevaCiudad = new Button();
            btnVolver = new Button();
            panelListaCiudades = new FlowLayoutPanel();
            SuspendLayout();
            // 
            // lblTituloAdminCiudades
            // 
            lblTituloAdminCiudades.AutoSize = true;
            lblTituloAdminCiudades.Font = new Font("Segoe UI", 16F);
            lblTituloAdminCiudades.Location = new Point(70, 30);
            lblTituloAdminCiudades.Name = "lblTituloAdminCiudades";
            lblTituloAdminCiudades.Size = new Size(271, 37);
            lblTituloAdminCiudades.TabIndex = 0;
            lblTituloAdminCiudades.Text = "Administrar Ciudades";
            // 
            // btnNuevaCiudad
            // 
            btnNuevaCiudad.Location = new Point(1030, 40);
            btnNuevaCiudad.Name = "btnNuevaCiudad";
            btnNuevaCiudad.Size = new Size(140, 30);
            btnNuevaCiudad.TabIndex = 1;
            btnNuevaCiudad.Text = "Nueva Ciudad";
            btnNuevaCiudad.UseVisualStyleBackColor = true;
            btnNuevaCiudad.Click += btnNuevaCiudad_Click;
            // 
            // btnVolver
            // 
            btnVolver.Location = new Point(70, 430);
            btnVolver.Name = "btnVolver";
            btnVolver.Size = new Size(180, 30);
            btnVolver.TabIndex = 2;
            btnVolver.Text = "Volver a menú principal";
            btnVolver.UseVisualStyleBackColor = true;
            btnVolver.Click += btnVolver_Click;
            // 
            // panelListaCiudades
            // 
            panelListaCiudades.AutoScroll = true;
            panelListaCiudades.FlowDirection = FlowDirection.TopDown;
            panelListaCiudades.Location = new Point(70, 100);
            panelListaCiudades.Name = "panelListaCiudades";
            panelListaCiudades.Size = new Size(1100, 300);
            panelListaCiudades.TabIndex = 3;
            panelListaCiudades.WrapContents = false;
            // 
            // CiudadAdminMenuForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1242, 503);
            Controls.Add(panelListaCiudades);
            Controls.Add(btnVolver);
            Controls.Add(btnNuevaCiudad);
            Controls.Add(lblTituloAdminCiudades);
            Name = "CiudadAdminMenuForm";
            Text = "CiudadAdminMenu";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTituloAdminCiudades;
        private Button btnNuevaCiudad;
        private Button btnVolver;
        private FlowLayoutPanel panelListaCiudades;
    }
}