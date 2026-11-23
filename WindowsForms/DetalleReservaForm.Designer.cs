namespace WindowsForms
{
    partial class DetalleReservaForm
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
            lblTitulo = new Label();
            lblSubtitulo = new Label();
            richTextBoxResumenFinal = new RichTextBox();
            lblTotalFinal = new Label();
            btnDescargarPdf = new Button();
            btnVolverBuscador = new Button();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new System.Drawing.Font("Segoe UI", 16F, FontStyle.Bold);
            lblTitulo.ForeColor = Color.FromArgb(25, 135, 84);
            lblTitulo.Location = new Point(40, 25);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Text = "¡Reserva Confirmada!";
            // 
            // lblSubtitulo
            // 
            lblSubtitulo.AutoSize = true;
            lblSubtitulo.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            lblSubtitulo.Location = new Point(40, 62);
            lblSubtitulo.Name = "lblSubtitulo";
            lblSubtitulo.Text = "Detalle completo de tu reserva:";
            // 
            // richTextBoxResumenFinal
            // 
            richTextBoxResumenFinal.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            richTextBoxResumenFinal.BackColor = SystemColors.Window;
            richTextBoxResumenFinal.Font = new System.Drawing.Font("Segoe UI", 10F);
            richTextBoxResumenFinal.Location = new Point(40, 100);
            richTextBoxResumenFinal.Name = "richTextBoxResumenFinal";
            richTextBoxResumenFinal.ReadOnly = true;
            richTextBoxResumenFinal.Size = new Size(920, 420);
            richTextBoxResumenFinal.TabIndex = 0;
            // 
            // lblTotalFinal
            // 
            lblTotalFinal.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lblTotalFinal.AutoSize = true;
            lblTotalFinal.Font = new System.Drawing.Font("Segoe UI", 13F, FontStyle.Bold);
            lblTotalFinal.ForeColor = Color.FromArgb(25, 135, 84);
            lblTotalFinal.Location = new Point(40, 540);
            lblTotalFinal.Name = "lblTotalFinal";
            lblTotalFinal.Text = "Total abonado: $ 0,00";
            // 
            // btnDescargarPdf
            // 
            btnDescargarPdf.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnDescargarPdf.Font = new System.Drawing.Font("Segoe UI", 10F, FontStyle.Bold);
            btnDescargarPdf.Location = new Point(510, 535);
            btnDescargarPdf.Name = "btnDescargarPdf";
            btnDescargarPdf.Size = new Size(195, 40);
            btnDescargarPdf.TabIndex = 1;
            btnDescargarPdf.Text = "Descargar recibo (PDF)";
            btnDescargarPdf.UseVisualStyleBackColor = true;
            btnDescargarPdf.Click += btnDescargarPdf_Click;
            // 
            // btnVolverBuscador
            // 
            btnVolverBuscador.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnVolverBuscador.Font = new System.Drawing.Font("Segoe UI", 10.5F, FontStyle.Bold);
            btnVolverBuscador.Location = new Point(720, 535);
            btnVolverBuscador.Name = "btnVolverBuscador";
            btnVolverBuscador.Size = new Size(240, 40);
            btnVolverBuscador.TabIndex = 2;
            btnVolverBuscador.Text = "Volver a buscar vuelos";
            btnVolverBuscador.UseVisualStyleBackColor = true;
            btnVolverBuscador.Click += btnVolverBuscador_Click;
            // 
            // DetalleReservaForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1000, 620);
            WindowState = FormWindowState.Maximized;
            Controls.Add(btnVolverBuscador);
            Controls.Add(btnDescargarPdf);
            Controls.Add(lblTotalFinal);
            Controls.Add(richTextBoxResumenFinal);
            Controls.Add(lblSubtitulo);
            Controls.Add(lblTitulo);
            Name = "DetalleReservaForm";
            Text = "AeroReservas - Detalle de Reserva";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitulo;
        private Label lblSubtitulo;
        private RichTextBox richTextBoxResumenFinal;
        private Label lblTotalFinal;
        private Button btnDescargarPdf;
        private Button btnVolverBuscador;
    }
}