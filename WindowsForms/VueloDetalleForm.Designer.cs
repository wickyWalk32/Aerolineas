namespace WindowsForms
{
    partial class VueloDetalleForm
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
            lblTituloNuevoEditarVuelo = new Label();
            panel1 = new Panel();
            textBoxAerolinea = new TextBox();
            dateTimePickerHoraVuelo = new DateTimePicker();
            textBoxPrecioVuelo = new TextBox();
            lblTituloPrecioVuelo = new Label();
            comboBoxAvion = new ComboBox();
            dateTimePickerFechaVuelo = new DateTimePicker();
            comboBoxCiudadDestino = new ComboBox();
            comboBoxCiudadOrigen = new ComboBox();
            lblIdVuelo = new Label();
            lblTituloAvion = new Label();
            lblTituloAerolinea = new Label();
            lblTituloHora = new Label();
            lblTituloFecha = new Label();
            lblTituloCiudadDestino = new Label();
            lblTituloCiudadOrIgen = new Label();
            lblTituloId = new Label();
            btnGuardarVuelo = new Button();
            btnVolver = new Button();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // lblTituloNuevoEditarVuelo
            // 
            lblTituloNuevoEditarVuelo.AutoSize = true;
            lblTituloNuevoEditarVuelo.Font = new Font("Segoe UI", 16F);
            lblTituloNuevoEditarVuelo.Location = new Point(81, 41);
            lblTituloNuevoEditarVuelo.Name = "lblTituloNuevoEditarVuelo";
            lblTituloNuevoEditarVuelo.Size = new Size(232, 37);
            lblTituloNuevoEditarVuelo.TabIndex = 0;
            lblTituloNuevoEditarVuelo.Text = "NuevoEditarVuelo";
            // 
            // panel1
            // 
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(textBoxAerolinea);
            panel1.Controls.Add(dateTimePickerHoraVuelo);
            panel1.Controls.Add(textBoxPrecioVuelo);
            panel1.Controls.Add(lblTituloPrecioVuelo);
            panel1.Controls.Add(comboBoxAvion);
            panel1.Controls.Add(dateTimePickerFechaVuelo);
            panel1.Controls.Add(comboBoxCiudadDestino);
            panel1.Controls.Add(comboBoxCiudadOrigen);
            panel1.Controls.Add(lblIdVuelo);
            panel1.Controls.Add(lblTituloAvion);
            panel1.Controls.Add(lblTituloAerolinea);
            panel1.Controls.Add(lblTituloHora);
            panel1.Controls.Add(lblTituloFecha);
            panel1.Controls.Add(lblTituloCiudadDestino);
            panel1.Controls.Add(lblTituloCiudadOrIgen);
            panel1.Controls.Add(lblTituloId);
            panel1.Controls.Add(btnGuardarVuelo);
            panel1.Location = new Point(134, 106);
            panel1.Name = "panel1";
            panel1.Size = new Size(544, 422);
            panel1.TabIndex = 1;
            // 
            // textBoxAerolinea
            // 
            textBoxAerolinea.Location = new Point(190, 271);
            textBoxAerolinea.Name = "textBoxAerolinea";
            textBoxAerolinea.Size = new Size(302, 27);
            textBoxAerolinea.TabIndex = 15;
            // 
            // dateTimePickerHoraVuelo
            // 
            dateTimePickerHoraVuelo.Format = DateTimePickerFormat.Time;
            dateTimePickerHoraVuelo.Location = new Point(189, 187);
            dateTimePickerHoraVuelo.Name = "dateTimePickerHoraVuelo";
            dateTimePickerHoraVuelo.ShowUpDown = true;
            dateTimePickerHoraVuelo.Size = new Size(303, 27);
            dateTimePickerHoraVuelo.TabIndex = 14;
            // 
            // textBoxPrecioVuelo
            // 
            textBoxPrecioVuelo.Location = new Point(189, 226);
            textBoxPrecioVuelo.Name = "textBoxPrecioVuelo";
            textBoxPrecioVuelo.Size = new Size(304, 27);
            textBoxPrecioVuelo.TabIndex = 4;
            // 
            // lblTituloPrecioVuelo
            // 
            lblTituloPrecioVuelo.AutoSize = true;
            lblTituloPrecioVuelo.Location = new Point(39, 229);
            lblTituloPrecioVuelo.Name = "lblTituloPrecioVuelo";
            lblTituloPrecioVuelo.Size = new Size(50, 20);
            lblTituloPrecioVuelo.TabIndex = 3;
            lblTituloPrecioVuelo.Text = "Precio";
            // 
            // comboBoxAvion
            // 
            comboBoxAvion.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxAvion.FormattingEnabled = true;
            comboBoxAvion.Location = new Point(190, 312);
            comboBoxAvion.Name = "comboBoxAvion";
            comboBoxAvion.Size = new Size(303, 28);
            comboBoxAvion.TabIndex = 13;
            // 
            // dateTimePickerFechaVuelo
            // 
            dateTimePickerFechaVuelo.Format = DateTimePickerFormat.Short;
            dateTimePickerFechaVuelo.Location = new Point(190, 146);
            dateTimePickerFechaVuelo.Name = "dateTimePickerFechaVuelo";
            dateTimePickerFechaVuelo.Size = new Size(303, 27);
            dateTimePickerFechaVuelo.TabIndex = 11;
            // 
            // comboBoxCiudadDestino
            // 
            comboBoxCiudadDestino.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxCiudadDestino.FormattingEnabled = true;
            comboBoxCiudadDestino.Location = new Point(190, 106);
            comboBoxCiudadDestino.Name = "comboBoxCiudadDestino";
            comboBoxCiudadDestino.Size = new Size(303, 28);
            comboBoxCiudadDestino.TabIndex = 10;
            // 
            // comboBoxCiudadOrigen
            // 
            comboBoxCiudadOrigen.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxCiudadOrigen.FormattingEnabled = true;
            comboBoxCiudadOrigen.Location = new Point(190, 66);
            comboBoxCiudadOrigen.Name = "comboBoxCiudadOrigen";
            comboBoxCiudadOrigen.Size = new Size(303, 28);
            comboBoxCiudadOrigen.TabIndex = 9;
            // 
            // lblIdVuelo
            // 
            lblIdVuelo.AutoSize = true;
            lblIdVuelo.Location = new Point(190, 33);
            lblIdVuelo.Name = "lblIdVuelo";
            lblIdVuelo.Size = new Size(22, 20);
            lblIdVuelo.TabIndex = 8;
            lblIdVuelo.Text = "id";
            // 
            // lblTituloAvion
            // 
            lblTituloAvion.AutoSize = true;
            lblTituloAvion.Location = new Point(39, 315);
            lblTituloAvion.Name = "lblTituloAvion";
            lblTituloAvion.Size = new Size(47, 20);
            lblTituloAvion.TabIndex = 7;
            lblTituloAvion.Text = "Avión";
            // 
            // lblTituloAerolinea
            // 
            lblTituloAerolinea.AutoSize = true;
            lblTituloAerolinea.Location = new Point(39, 271);
            lblTituloAerolinea.Name = "lblTituloAerolinea";
            lblTituloAerolinea.Size = new Size(73, 20);
            lblTituloAerolinea.TabIndex = 6;
            lblTituloAerolinea.Text = "Aerolínea";
            // 
            // lblTituloHora
            // 
            lblTituloHora.AutoSize = true;
            lblTituloHora.Location = new Point(39, 187);
            lblTituloHora.Name = "lblTituloHora";
            lblTituloHora.Size = new Size(42, 20);
            lblTituloHora.TabIndex = 5;
            lblTituloHora.Text = "Hora";
            // 
            // lblTituloFecha
            // 
            lblTituloFecha.AutoSize = true;
            lblTituloFecha.Location = new Point(39, 151);
            lblTituloFecha.Name = "lblTituloFecha";
            lblTituloFecha.Size = new Size(47, 20);
            lblTituloFecha.TabIndex = 4;
            lblTituloFecha.Text = "Fecha";
            // 
            // lblTituloCiudadDestino
            // 
            lblTituloCiudadDestino.AutoSize = true;
            lblTituloCiudadDestino.Location = new Point(39, 109);
            lblTituloCiudadDestino.Name = "lblTituloCiudadDestino";
            lblTituloCiudadDestino.Size = new Size(111, 20);
            lblTituloCiudadDestino.TabIndex = 3;
            lblTituloCiudadDestino.Text = "Ciudad Destino";
            // 
            // lblTituloCiudadOrIgen
            // 
            lblTituloCiudadOrIgen.AutoSize = true;
            lblTituloCiudadOrIgen.Location = new Point(39, 69);
            lblTituloCiudadOrIgen.Name = "lblTituloCiudadOrIgen";
            lblTituloCiudadOrIgen.Size = new Size(105, 20);
            lblTituloCiudadOrIgen.TabIndex = 2;
            lblTituloCiudadOrIgen.Text = "Ciudad Origen";
            // 
            // lblTituloId
            // 
            lblTituloId.AutoSize = true;
            lblTituloId.Location = new Point(39, 33);
            lblTituloId.Name = "lblTituloId";
            lblTituloId.Size = new Size(22, 20);
            lblTituloId.TabIndex = 1;
            lblTituloId.Text = "Id";
            // 
            // btnGuardarVuelo
            // 
            btnGuardarVuelo.Location = new Point(220, 372);
            btnGuardarVuelo.Name = "btnGuardarVuelo";
            btnGuardarVuelo.Size = new Size(94, 29);
            btnGuardarVuelo.TabIndex = 0;
            btnGuardarVuelo.Text = "Guardar";
            btnGuardarVuelo.UseVisualStyleBackColor = true;
            btnGuardarVuelo.Click += btnGuardarVuelo_Click;
            // 
            // btnVolver
            // 
            btnVolver.Location = new Point(81, 574);
            btnVolver.Name = "btnVolver";
            btnVolver.Size = new Size(94, 29);
            btnVolver.TabIndex = 2;
            btnVolver.Text = "Volver";
            btnVolver.UseVisualStyleBackColor = true;
            btnVolver.Click += btnVolver_Click;
            // 
            // VueloDetalleForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 639);
            Controls.Add(btnVolver);
            Controls.Add(panel1);
            Controls.Add(lblTituloNuevoEditarVuelo);
            Name = "VueloDetalleForm";
            Text = "VueloDetalleForm";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTituloNuevoEditarVuelo;
        private Panel panel1;
        private Button btnGuardarVuelo;
        private Button btnVolver;
        private Label lblTituloAvion;
        private Label lblTituloAerolinea;
        private Label lblTituloHora;
        private Label lblTituloFecha;
        private Label lblTituloCiudadDestino;
        private Label lblTituloCiudadOrIgen;
        private Label lblTituloId;
        private ComboBox comboBoxCiudadDestino;
        private ComboBox comboBoxCiudadOrigen;
        private Label lblIdVuelo;
        private ComboBox comboBoxAvion;
        private DateTimePicker dateTimePickerFechaVuelo;
        private TextBox textBoxPrecioVuelo;
        private Label lblTituloPrecioVuelo;
        private DateTimePicker dateTimePickerHoraVuelo;
        private TextBox textBoxAerolinea;
    }
}