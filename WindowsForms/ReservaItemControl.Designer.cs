namespace WindowsForms
{
    partial class ReservaItemControl
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
            label1 = new Label();
            labelFechaVuelo = new Label();
            label3 = new Label();
            labelOrigenDestino = new Label();
            labelFechaHora = new Label();
            labelEstado = new Label();
            buttonVer = new Button();
            labelCosto = new Label();
            label4 = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ForeColor = SystemColors.ControlDarkDark;
            label1.Location = new Point(25, 10);
            label1.Name = "label1";
            label1.Size = new Size(135, 15);
            label1.TabIndex = 1;
            label1.Text = "Vuelo (Origen - Destino)";
            // 
            // labelFechaVuelo
            // 
            labelFechaVuelo.AutoSize = true;
            labelFechaVuelo.ForeColor = SystemColors.ControlDarkDark;
            labelFechaVuelo.Location = new Point(233, 10);
            labelFechaVuelo.Name = "labelFechaVuelo";
            labelFechaVuelo.Size = new Size(128, 15);
            labelFechaVuelo.TabIndex = 2;
            labelFechaVuelo.Text = "Fecha y Hora del Vuelo";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.ForeColor = SystemColors.ControlDarkDark;
            label3.Location = new Point(524, 10);
            label3.Name = "label3";
            label3.Size = new Size(42, 15);
            label3.TabIndex = 3;
            label3.Text = "Estado";
            // 
            // labelOrigenDestino
            // 
            labelOrigenDestino.AutoSize = true;
            labelOrigenDestino.Location = new Point(25, 35);
            labelOrigenDestino.Name = "labelOrigenDestino";
            labelOrigenDestino.Size = new Size(83, 15);
            labelOrigenDestino.TabIndex = 4;
            labelOrigenDestino.Text = "OrigenDestino";
            // 
            // labelFechaHora
            // 
            labelFechaHora.AutoSize = true;
            labelFechaHora.Location = new Point(233, 35);
            labelFechaHora.Name = "labelFechaHora";
            labelFechaHora.Size = new Size(64, 15);
            labelFechaHora.TabIndex = 5;
            labelFechaHora.Text = "FechaHora";
            // 
            // labelEstado
            // 
            labelEstado.AutoSize = true;
            labelEstado.Location = new Point(524, 35);
            labelEstado.Name = "labelEstado";
            labelEstado.Size = new Size(42, 15);
            labelEstado.TabIndex = 6;
            labelEstado.Text = "Estado";
            // 
            // buttonVer
            // 
            buttonVer.Location = new Point(593, 10);
            buttonVer.Name = "buttonVer";
            buttonVer.Size = new Size(75, 40);
            buttonVer.TabIndex = 7;
            buttonVer.Text = "Ver";
            buttonVer.UseVisualStyleBackColor = true;
            buttonVer.Click += buttonVer_Click;
            // 
            // labelCosto
            // 
            labelCosto.AutoSize = true;
            labelCosto.Location = new Point(398, 35);
            labelCosto.Name = "labelCosto";
            labelCosto.Size = new Size(38, 15);
            labelCosto.TabIndex = 9;
            labelCosto.Text = "Costo";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.ForeColor = SystemColors.ControlDarkDark;
            label4.Location = new Point(398, 10);
            label4.Name = "label4";
            label4.Size = new Size(38, 15);
            label4.TabIndex = 8;
            label4.Text = "Costo";
            // 
            // ReservaItemControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BorderStyle = BorderStyle.FixedSingle;
            Controls.Add(labelCosto);
            Controls.Add(label4);
            Controls.Add(buttonVer);
            Controls.Add(labelEstado);
            Controls.Add(labelFechaHora);
            Controls.Add(labelOrigenDestino);
            Controls.Add(label3);
            Controls.Add(labelFechaVuelo);
            Controls.Add(label1);
            Name = "ReservaItemControl";
            Size = new Size(682, 64);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label labelFechaVuelo;
        private Label label3;
        private Label labelOrigenDestino;
        private Label labelFechaHora;
        private Label labelEstado;
        private Button buttonVer;
        private Label labelCosto;
        private Label label4;
    }
}
