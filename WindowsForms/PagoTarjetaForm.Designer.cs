namespace WindowsForms
{
    partial class PagoTarjetaForm
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
            lblTipoTarjeta = new Label();
            comboBoxTipoTarjeta = new ComboBox();
            lblTitular = new Label();
            textBoxTitular = new TextBox();
            lblNumeroTarjeta = new Label();
            textBoxNumeroTarjeta = new TextBox();
            lblVencimiento = new Label();
            textBoxVencimiento = new TextBox();
            lblCvv = new Label();
            textBoxCvv = new TextBox();
            panelResumen = new Panel();
            lblResumenTitulo = new Label();
            lblResumenVuelo = new Label();
            richTextBoxDetallePasajeros = new RichTextBox();
            lblTotalPagar = new Label();
            btnAtras = new Button();
            btnConfirmarPago = new Button();
            panelResumen.SuspendLayout();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new System.Drawing.Font("Segoe UI", 16F, FontStyle.Bold);
            lblTitulo.Location = new Point(40, 25);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Text = "Pago con Tarjeta";
            // 
            // lblTipoTarjeta
            // 
            lblTipoTarjeta.AutoSize = true;
            lblTipoTarjeta.Font = new System.Drawing.Font("Segoe UI", 10F, FontStyle.Bold);
            lblTipoTarjeta.Location = new Point(40, 85);
            lblTipoTarjeta.Name = "lblTipoTarjeta";
            lblTipoTarjeta.Text = "Tipo de Tarjeta";
            // 
            // comboBoxTipoTarjeta
            // 
            comboBoxTipoTarjeta.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxTipoTarjeta.Font = new System.Drawing.Font("Segoe UI", 10F);
            comboBoxTipoTarjeta.FormattingEnabled = true;
            comboBoxTipoTarjeta.Items.AddRange(new object[] { "Crédito", "Débito" });
            comboBoxTipoTarjeta.Location = new Point(40, 112);
            comboBoxTipoTarjeta.Name = "comboBoxTipoTarjeta";
            comboBoxTipoTarjeta.Size = new Size(210, 28);
            comboBoxTipoTarjeta.TabIndex = 0;
            // 
            // lblTitular
            // 
            lblTitular.AutoSize = true;
            lblTitular.Font = new System.Drawing.Font("Segoe UI", 10F, FontStyle.Bold);
            lblTitular.Location = new Point(275, 85);
            lblTitular.Name = "lblTitular";
            lblTitular.Text = "Nombre del Titular *";
            // 
            // textBoxTitular
            // 
            textBoxTitular.Font = new System.Drawing.Font("Segoe UI", 10F);
            textBoxTitular.Location = new Point(275, 112);
            textBoxTitular.Name = "textBoxTitular";
            textBoxTitular.Size = new Size(255, 27);
            textBoxTitular.TabIndex = 1;
            // 
            // lblNumeroTarjeta
            // 
            lblNumeroTarjeta.AutoSize = true;
            lblNumeroTarjeta.Font = new System.Drawing.Font("Segoe UI", 10F, FontStyle.Bold);
            lblNumeroTarjeta.Location = new Point(40, 160);
            lblNumeroTarjeta.Name = "lblNumeroTarjeta";
            lblNumeroTarjeta.Text = "Número de Tarjeta *";
            // 
            // textBoxNumeroTarjeta
            // 
            textBoxNumeroTarjeta.Font = new System.Drawing.Font("Segoe UI", 10F);
            textBoxNumeroTarjeta.Location = new Point(40, 187);
            textBoxNumeroTarjeta.MaxLength = 19;
            textBoxNumeroTarjeta.Name = "textBoxNumeroTarjeta";
            textBoxNumeroTarjeta.Size = new Size(490, 27);
            textBoxNumeroTarjeta.TabIndex = 2;
            // 
            // lblVencimiento
            // 
            lblVencimiento.AutoSize = true;
            lblVencimiento.Font = new System.Drawing.Font("Segoe UI", 10F, FontStyle.Bold);
            lblVencimiento.Location = new Point(40, 235);
            lblVencimiento.Name = "lblVencimiento";
            lblVencimiento.Text = "Vencimiento (MM/AA) *";
            // 
            // textBoxVencimiento
            // 
            textBoxVencimiento.Font = new System.Drawing.Font("Segoe UI", 10F);
            textBoxVencimiento.Location = new Point(40, 262);
            textBoxVencimiento.MaxLength = 5;
            textBoxVencimiento.Name = "textBoxVencimiento";
            textBoxVencimiento.Size = new Size(220, 27);
            textBoxVencimiento.TabIndex = 3;
            // 
            // lblCvv
            // 
            lblCvv.AutoSize = true;
            lblCvv.Font = new System.Drawing.Font("Segoe UI", 10F, FontStyle.Bold);
            lblCvv.Location = new Point(290, 235);
            lblCvv.Name = "lblCvv";
            lblCvv.Text = "Código de Seguridad (CVV) *";
            // 
            // textBoxCvv
            // 
            textBoxCvv.Font = new System.Drawing.Font("Segoe UI", 10F);
            textBoxCvv.Location = new Point(290, 262);
            textBoxCvv.MaxLength = 4;
            textBoxCvv.Name = "textBoxCvv";
            textBoxCvv.PasswordChar = '*';
            textBoxCvv.Size = new Size(240, 27);
            textBoxCvv.TabIndex = 4;
            // 
            // btnAtras
            // 
            btnAtras.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnAtras.Font = new System.Drawing.Font("Segoe UI", 10F);
            btnAtras.Location = new Point(40, 565);
            btnAtras.Name = "btnAtras";
            btnAtras.Size = new Size(120, 38);
            btnAtras.TabIndex = 5;
            btnAtras.Text = "Atrás";
            btnAtras.UseVisualStyleBackColor = true;
            btnAtras.Click += btnAtras_Click;
            // 
            // btnConfirmarPago
            // 
            btnConfirmarPago.Font = new System.Drawing.Font("Segoe UI", 10.5F, FontStyle.Bold);
            btnConfirmarPago.Location = new Point(40, 330);
            btnConfirmarPago.Name = "btnConfirmarPago";
            btnConfirmarPago.Size = new Size(490, 42);
            btnConfirmarPago.TabIndex = 6;
            btnConfirmarPago.Text = "Confirmar Pago";
            btnConfirmarPago.UseVisualStyleBackColor = true;
            btnConfirmarPago.Click += btnConfirmarPago_Click;
            // 
            // panelResumen
            // 
            panelResumen.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            panelResumen.BorderStyle = BorderStyle.FixedSingle;
            panelResumen.Controls.Add(lblTotalPagar);
            panelResumen.Controls.Add(richTextBoxDetallePasajeros);
            panelResumen.Controls.Add(lblResumenVuelo);
            panelResumen.Controls.Add(lblResumenTitulo);
            panelResumen.Location = new Point(575, 85);
            panelResumen.Name = "panelResumen";
            panelResumen.Size = new Size(420, 440);
            panelResumen.TabIndex = 7;
            // 
            // lblResumenTitulo
            // 
            lblResumenTitulo.AutoSize = true;
            lblResumenTitulo.Font = new System.Drawing.Font("Segoe UI", 12F, FontStyle.Bold);
            lblResumenTitulo.Location = new Point(16, 14);
            lblResumenTitulo.Name = "lblResumenTitulo";
            lblResumenTitulo.Text = "Detalle a abonar";
            // 
            // lblResumenVuelo
            // 
            lblResumenVuelo.AutoSize = true;
            lblResumenVuelo.Font = new System.Drawing.Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblResumenVuelo.Location = new Point(16, 52);
            lblResumenVuelo.Name = "lblResumenVuelo";
            lblResumenVuelo.Text = "Vuelo:";
            // 
            // richTextBoxDetallePasajeros
            // 
            richTextBoxDetallePasajeros.BackColor = SystemColors.Window;
            richTextBoxDetallePasajeros.BorderStyle = BorderStyle.FixedSingle;
            richTextBoxDetallePasajeros.Font = new System.Drawing.Font("Segoe UI", 9F);
            richTextBoxDetallePasajeros.Location = new Point(16, 95);
            richTextBoxDetallePasajeros.Name = "richTextBoxDetallePasajeros";
            richTextBoxDetallePasajeros.ReadOnly = true;
            richTextBoxDetallePasajeros.Size = new Size(386, 275);
            richTextBoxDetallePasajeros.TabIndex = 2;
            richTextBoxDetallePasajeros.Text = "";
            // 
            // lblTotalPagar
            // 
            lblTotalPagar.AutoSize = true;
            lblTotalPagar.Font = new System.Drawing.Font("Segoe UI", 12.5F, FontStyle.Bold);
            lblTotalPagar.ForeColor = Color.FromArgb(25, 135, 84);
            lblTotalPagar.Location = new Point(16, 388);
            lblTotalPagar.Name = "lblTotalPagar";
            lblTotalPagar.Text = "Total a pagar: $ 0,00";
            // 
            // PagoTarjetaForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1040, 640);
            WindowState = FormWindowState.Maximized;
            Controls.Add(panelResumen);
            Controls.Add(btnConfirmarPago);
            Controls.Add(btnAtras);
            Controls.Add(textBoxCvv);
            Controls.Add(lblCvv);
            Controls.Add(textBoxVencimiento);
            Controls.Add(lblVencimiento);
            Controls.Add(textBoxNumeroTarjeta);
            Controls.Add(lblNumeroTarjeta);
            Controls.Add(textBoxTitular);
            Controls.Add(lblTitular);
            Controls.Add(comboBoxTipoTarjeta);
            Controls.Add(lblTipoTarjeta);
            Controls.Add(lblTitulo);
            Name = "PagoTarjetaForm";
            Text = "AeroReservas - Pago con Tarjeta";
            panelResumen.ResumeLayout(false);
            panelResumen.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitulo;
        private Label lblTipoTarjeta;
        private ComboBox comboBoxTipoTarjeta;
        private Label lblTitular;
        private TextBox textBoxTitular;
        private Label lblNumeroTarjeta;
        private TextBox textBoxNumeroTarjeta;
        private Label lblVencimiento;
        private TextBox textBoxVencimiento;
        private Label lblCvv;
        private TextBox textBoxCvv;
        private Panel panelResumen;
        private Label lblResumenTitulo;
        private Label lblResumenVuelo;
        private RichTextBox richTextBoxDetallePasajeros;
        private Label lblTotalPagar;
        private Button btnAtras;
        private Button btnConfirmarPago;
    }
}

/*
 * namespace WindowsForms
{
    partial class PagoTarjetaForm
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
            this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Text = "PagoTarjetaForm";
        }

        #endregion
    }
}*/