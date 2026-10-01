namespace WindowsForms
{
    partial class VueloAdminMenuForm
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
            btnNuevoVuelo = new Button();
            btnVolver = new Button();
            label1 = new Label();
            panelListaVuelos = new FlowLayoutPanel();
            SuspendLayout();
            // 
            // btnNuevoVuelo
            // 
            btnNuevoVuelo.Location = new Point(1030, 40);
            btnNuevoVuelo.Name = "btnNuevoVuelo";
            btnNuevoVuelo.Size = new Size(140, 30);
            btnNuevoVuelo.TabIndex = 0;
            btnNuevoVuelo.Text = "Nuevo Vuelo";
            btnNuevoVuelo.UseVisualStyleBackColor = true;
            btnNuevoVuelo.Click += btnNuevoVuelo_Click;
            // 
            // btnVolver
            // 
            btnVolver.Location = new Point(70, 616);
            btnVolver.Name = "btnVolver";
            btnVolver.Size = new Size(180, 30);
            btnVolver.TabIndex = 1;
            btnVolver.Text = "Volver al menú principal";
            btnVolver.UseVisualStyleBackColor = true;
            btnVolver.Click += btnVolver_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 16F);
            label1.Location = new Point(70, 30);
            label1.Name = "label1";
            label1.Size = new Size(240, 37);
            label1.TabIndex = 2;
            label1.Text = "Administrar Vuelos";
            // 
            // panelListaVuelos
            // 
            panelListaVuelos.AutoScroll = true;
            panelListaVuelos.FlowDirection = FlowDirection.TopDown;
            panelListaVuelos.Location = new Point(70, 100);
            panelListaVuelos.Name = "panelListaVuelos";
            panelListaVuelos.Size = new Size(1100, 477);
            panelListaVuelos.TabIndex = 3;
            panelListaVuelos.WrapContents = false;
            // 
            // VueloAdminMenuForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1242, 688);
            Controls.Add(panelListaVuelos);
            Controls.Add(label1);
            Controls.Add(btnVolver);
            Controls.Add(btnNuevoVuelo);
            Name = "VueloAdminMenuForm";
            Text = "VueloAdminMenuForm";
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