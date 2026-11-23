namespace WindowsForms
{
    partial class SeleccionarServiciosPorPasajeroForm
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
            lblPasajero = new Label();
            comboBoxPasajeros = new ComboBox();
            lblServicios = new Label();
            checkedListBoxServicios = new CheckedListBox();
            panelResumen = new Panel();
            lblResumenTitulo = new Label();
            lblResumenRuta = new Label();
            lblResumenFecha = new Label();
            lblResumenAsientos = new Label();
            lblTotalEstimado = new Label();
            btnAtras = new Button();
            btnSiguiente = new Button();
            panelResumen.SuspendLayout();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new System.Drawing.Font("Segoe UI", 16F, FontStyle.Bold);
            lblTitulo.Location = new Point(40, 25);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Text = "Servicios Adicionales por Pasajero";
            // 
            // lblPasajero
            // 
            lblPasajero.AutoSize = true;
            lblPasajero.Font = new System.Drawing.Font("Segoe UI", 10F, FontStyle.Bold);
            lblPasajero.Location = new Point(40, 85);
            lblPasajero.Name = "lblPasajero";
            lblPasajero.Text = "Seleccionar pasajero:";
            // 
            // comboBoxPasajeros
            // 
            comboBoxPasajeros.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxPasajeros.Font = new System.Drawing.Font("Segoe UI", 10F);
            comboBoxPasajeros.FormattingEnabled = true;
            comboBoxPasajeros.Location = new Point(40, 115);
            comboBoxPasajeros.Name = "comboBoxPasajeros";
            comboBoxPasajeros.Size = new Size(460, 28);
            comboBoxPasajeros.TabIndex = 0;
            comboBoxPasajeros.SelectedIndexChanged += comboBoxPasajeros_SelectedIndexChanged;
            // 
            // lblServicios
            // 
            lblServicios.AutoSize = true;
            lblServicios.Font = new System.Drawing.Font("Segoe UI", 10F, FontStyle.Bold);
            lblServicios.Location = new Point(40, 165);
            lblServicios.Name = "lblServicios";
            lblServicios.Text = "Servicios disponibles para el pasajero seleccionado:";
            // 
            // checkedListBoxServicios
            // 
            checkedListBoxServicios.CheckOnClick = true;
            checkedListBoxServicios.Font = new System.Drawing.Font("Segoe UI", 10F);
            checkedListBoxServicios.FormattingEnabled = true;
            checkedListBoxServicios.Location = new Point(40, 195);
            checkedListBoxServicios.Name = "checkedListBoxServicios";
            checkedListBoxServicios.Size = new Size(460, 330);
            checkedListBoxServicios.TabIndex = 1;
            checkedListBoxServicios.ItemCheck += checkedListBoxServicios_ItemCheck;
            // 
            // panelResumen
            // 
            panelResumen.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            panelResumen.BorderStyle = BorderStyle.FixedSingle;
            panelResumen.Controls.Add(lblResumenTitulo);
            panelResumen.Controls.Add(lblResumenRuta);
            panelResumen.Controls.Add(lblResumenFecha);
            panelResumen.Controls.Add(lblResumenAsientos);
            panelResumen.Controls.Add(lblTotalEstimado);
            panelResumen.Location = new Point(560, 85);
            panelResumen.Name = "panelResumen";
            panelResumen.Size = new Size(380, 260);
            panelResumen.TabIndex = 2;
            // 
            // lblResumenTitulo
            // 
            lblResumenTitulo.AutoSize = true;
            lblResumenTitulo.Font = new System.Drawing.Font("Segoe UI", 12F, FontStyle.Bold);
            lblResumenTitulo.Location = new Point(18, 16);
            lblResumenTitulo.Name = "lblResumenTitulo";
            lblResumenTitulo.Text = "Resumen de la reserva";
            // 
            // lblResumenRuta
            // 
            lblResumenRuta.AutoSize = true;
            lblResumenRuta.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            lblResumenRuta.Location = new Point(18, 60);
            lblResumenRuta.Name = "lblResumenRuta";
            lblResumenRuta.Text = "Ruta:";
            // 
            // lblResumenFecha
            // 
            lblResumenFecha.AutoSize = true;
            lblResumenFecha.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            lblResumenFecha.Location = new Point(18, 95);
            lblResumenFecha.Name = "lblResumenFecha";
            lblResumenFecha.Text = "Fecha y hora:";
            // 
            // lblResumenAsientos
            // 
            lblResumenAsientos.AutoSize = true;
            lblResumenAsientos.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            lblResumenAsientos.Location = new Point(18, 130);
            lblResumenAsientos.Name = "lblResumenAsientos";
            lblResumenAsientos.Text = "Asientos:";
            // 
            // lblTotalEstimado
            // 
            lblTotalEstimado.AutoSize = true;
            lblTotalEstimado.Font = new System.Drawing.Font("Segoe UI", 12F, FontStyle.Bold);
            lblTotalEstimado.ForeColor = Color.FromArgb(25, 135, 84);
            lblTotalEstimado.Location = new Point(18, 195);
            lblTotalEstimado.Name = "lblTotalEstimado";
            lblTotalEstimado.Text = "Total estimado: $ 0,00";
            // 
            // btnAtras
            // 
            btnAtras.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnAtras.Font = new System.Drawing.Font("Segoe UI", 10F);
            btnAtras.Location = new Point(40, 565);
            btnAtras.Name = "btnAtras";
            btnAtras.Size = new Size(120, 36);
            btnAtras.TabIndex = 3;
            btnAtras.Text = "Atrás";
            btnAtras.UseVisualStyleBackColor = true;
            btnAtras.Click += btnAtras_Click;
            // 
            // btnSiguiente
            // 
            btnSiguiente.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnSiguiente.Font = new System.Drawing.Font("Segoe UI", 10F, FontStyle.Bold);
            btnSiguiente.Location = new Point(820, 565);
            btnSiguiente.Name = "btnSiguiente";
            btnSiguiente.Size = new Size(120, 36);
            btnSiguiente.TabIndex = 4;
            btnSiguiente.Text = "Siguiente";
            btnSiguiente.UseVisualStyleBackColor = true;
            btnSiguiente.Click += btnSiguiente_Click;
            // 
            // SeleccionarServiciosPorPasajeroForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1000, 640);
            WindowState = FormWindowState.Maximized;
            Controls.Add(btnSiguiente);
            Controls.Add(btnAtras);
            Controls.Add(panelResumen);
            Controls.Add(checkedListBoxServicios);
            Controls.Add(lblServicios);
            Controls.Add(comboBoxPasajeros);
            Controls.Add(lblPasajero);
            lblTitulo.Location = new Point(40, 25);
            Controls.Add(lblTitulo);
            Name = "SeleccionarServiciosPorPasajeroForm";
            Text = "AeroReservas - Servicios por Pasajero";
            panelResumen.ResumeLayout(false);
            panelResumen.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitulo;
        private Label lblPasajero;
        private ComboBox comboBoxPasajeros;
        private Label lblServicios;
        private CheckedListBox checkedListBoxServicios;
        private Panel panelResumen;
        private Label lblResumenTitulo;
        private Label lblResumenRuta;
        private Label lblResumenFecha;
        private Label lblResumenAsientos;
        private Label lblTotalEstimado;
        private Button btnAtras;
        private Button btnSiguiente;
    }
}
