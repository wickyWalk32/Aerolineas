namespace WindowsForms
{
    partial class CiudadAdminMenu
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
            lblTituloAdminCiudades.Location = new Point(72, 24);
            lblTituloAdminCiudades.Name = "lblTituloAdminCiudades";
            lblTituloAdminCiudades.Size = new Size(271, 37);
            lblTituloAdminCiudades.TabIndex = 0;
            lblTituloAdminCiudades.Text = "Administrar Ciudades";
            // 
            // btnNuevaCiudad
            // 
            btnNuevaCiudad.Location = new Point(786, 34);
            btnNuevaCiudad.Name = "btnNuevaCiudad";
            btnNuevaCiudad.Size = new Size(120, 29);
            btnNuevaCiudad.TabIndex = 1;
            btnNuevaCiudad.Text = "Nueva Ciudad";
            btnNuevaCiudad.UseVisualStyleBackColor = true;
            btnNuevaCiudad.Click += btnNuevaCiudad_Click;
            // 
            // btnVolver
            // 
            btnVolver.Location = new Point(72, 390);
            btnVolver.Name = "btnVolver";
            btnVolver.Size = new Size(101, 29);
            btnVolver.TabIndex = 2;
            btnVolver.Text = "Volver";
            btnVolver.UseVisualStyleBackColor = true;
            btnVolver.Click += btnVolver_Click;
            // 
            // panelListaCiudades
            // 
            panelListaCiudades.AutoScroll = true;
            panelListaCiudades.FlowDirection = FlowDirection.TopDown;
            panelListaCiudades.Location = new Point(72, 81);
            panelListaCiudades.Name = "panelListaCiudades";
            panelListaCiudades.Size = new Size(834, 289);
            panelListaCiudades.TabIndex = 3;
            panelListaCiudades.WrapContents = false;
            // 
            // CiudadAdminMenu
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1013, 450);
            Controls.Add(panelListaCiudades);
            Controls.Add(btnVolver);
            Controls.Add(btnNuevaCiudad);
            Controls.Add(lblTituloAdminCiudades);
            Name = "CiudadAdminMenu";
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