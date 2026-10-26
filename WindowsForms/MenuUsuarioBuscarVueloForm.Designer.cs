namespace WindowsForms
{
    partial class MenuUsuarioBuscarVueloForm
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
            lblTituloAeroReservas = new Label();
            lblNombreApellido = new Label();
            btnSalirDelSistema = new Button();
            panelLineaDivisoria = new Panel();
            label1 = new Label();
            panel1 = new Panel();
            comboBoxCantidadPasajeros = new ComboBox();
            comboBoxCiudadDestino = new ComboBox();
            comboBoxCiudadOrigen = new ComboBox();
            lblCantidadPasajeros = new Label();
            label3 = new Label();
            lblCiudadOrigen = new Label();
            flowLayoutPanelVuelos = new FlowLayoutPanel();
            labelSinVuelos = new Label();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // lblTituloAeroReservas
            // 
            lblTituloAeroReservas.AutoSize = true;
            lblTituloAeroReservas.Font = new Font("Segoe UI", 20F, FontStyle.Italic);
            lblTituloAeroReservas.Location = new Point(28, 13);
            lblTituloAeroReservas.Name = "lblTituloAeroReservas";
            lblTituloAeroReservas.Size = new Size(228, 37);
            lblTituloAeroReservas.TabIndex = 0;
            lblTituloAeroReservas.Text = "AeroReservas.com";
            // 
            // lblNombreApellido
            // 
            lblNombreApellido.AutoSize = true;
            lblNombreApellido.Location = new Point(482, 28);
            lblNombreApellido.Name = "lblNombreApellido";
            lblNombreApellido.Size = new Size(166, 15);
            lblNombreApellido.TabIndex = 1;
            lblNombreApellido.Text = "Bienvenido Nombre Apellido !";
            // 
            // btnSalirDelSistema
            // 
            btnSalirDelSistema.Location = new Point(945, 25);
            btnSalirDelSistema.Margin = new Padding(3, 2, 3, 2);
            btnSalirDelSistema.Name = "btnSalirDelSistema";
            btnSalirDelSistema.Size = new Size(118, 22);
            btnSalirDelSistema.TabIndex = 2;
            btnSalirDelSistema.Text = "Salir del sistema";
            btnSalirDelSistema.UseVisualStyleBackColor = true;
            btnSalirDelSistema.Click += btnSalirDelSistema_Click;
            // 
            // panelLineaDivisoria
            // 
            panelLineaDivisoria.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panelLineaDivisoria.BackColor = SystemColors.Desktop;
            panelLineaDivisoria.Location = new Point(-9, 58);
            panelLineaDivisoria.Margin = new Padding(3, 2, 3, 2);
            panelLineaDivisoria.Name = "panelLineaDivisoria";
            panelLineaDivisoria.Size = new Size(1124, 1);
            panelLineaDivisoria.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F);
            label1.Location = new Point(58, 98);
            label1.Name = "label1";
            label1.Size = new Size(298, 21);
            label1.TabIndex = 4;
            label1.Text = "Ingrese datos de búsqueda para su vuelo!";
            // 
            // panel1
            // 
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(comboBoxCantidadPasajeros);
            panel1.Controls.Add(comboBoxCiudadDestino);
            panel1.Controls.Add(comboBoxCiudadOrigen);
            panel1.Controls.Add(lblCantidadPasajeros);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(lblCiudadOrigen);
            panel1.Location = new Point(44, 137);
            panel1.Margin = new Padding(3, 2, 3, 2);
            panel1.Name = "panel1";
            panel1.Size = new Size(908, 67);
            panel1.TabIndex = 5;
            // 
            // comboBoxCantidadPasajeros
            // 
            comboBoxCantidadPasajeros.FormattingEnabled = true;
            comboBoxCantidadPasajeros.Items.AddRange(new object[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10" });
            comboBoxCantidadPasajeros.Location = new Point(771, 23);
            comboBoxCantidadPasajeros.Name = "comboBoxCantidadPasajeros";
            comboBoxCantidadPasajeros.Size = new Size(41, 23);
            comboBoxCantidadPasajeros.TabIndex = 9;
            comboBoxCantidadPasajeros.SelectedIndexChanged += FiltrarVuelos;
            // 
            // comboBoxCiudadDestino
            // 
            comboBoxCiudadDestino.FormattingEnabled = true;
            comboBoxCiudadDestino.Location = new Point(437, 23);
            comboBoxCiudadDestino.Margin = new Padding(3, 2, 3, 2);
            comboBoxCiudadDestino.Name = "comboBoxCiudadDestino";
            comboBoxCiudadDestino.Size = new Size(183, 23);
            comboBoxCiudadDestino.TabIndex = 8;
            comboBoxCiudadDestino.SelectedIndexChanged += FiltrarVuelos;
            // 
            // comboBoxCiudadOrigen
            // 
            comboBoxCiudadOrigen.FormattingEnabled = true;
            comboBoxCiudadOrigen.Location = new Point(117, 23);
            comboBoxCiudadOrigen.Margin = new Padding(3, 2, 3, 2);
            comboBoxCiudadOrigen.Name = "comboBoxCiudadOrigen";
            comboBoxCiudadOrigen.Size = new Size(183, 23);
            comboBoxCiudadOrigen.TabIndex = 7;
            comboBoxCiudadOrigen.SelectedIndexChanged += FiltrarVuelos;
            // 
            // lblCantidadPasajeros
            // 
            lblCantidadPasajeros.AutoSize = true;
            lblCantidadPasajeros.Location = new Point(642, 26);
            lblCantidadPasajeros.Name = "lblCantidadPasajeros";
            lblCantidadPasajeros.Size = new Size(123, 15);
            lblCantidadPasajeros.TabIndex = 2;
            lblCantidadPasajeros.Text = "Cantidad de pasajeros";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(330, 26);
            label3.Name = "label3";
            label3.Size = new Size(103, 15);
            label3.TabIndex = 1;
            label3.Text = "Ciudad de destino";
            // 
            // lblCiudadOrigen
            // 
            lblCiudadOrigen.AutoSize = true;
            lblCiudadOrigen.Location = new Point(13, 26);
            lblCiudadOrigen.Name = "lblCiudadOrigen";
            lblCiudadOrigen.Size = new Size(98, 15);
            lblCiudadOrigen.TabIndex = 0;
            lblCiudadOrigen.Text = "Ciudad de origen";
            // 
            // flowLayoutPanelVuelos
            // 
            flowLayoutPanelVuelos.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanelVuelos.Location = new Point(44, 288);
            flowLayoutPanelVuelos.Name = "flowLayoutPanelVuelos";
            flowLayoutPanelVuelos.Size = new Size(989, 398);
            flowLayoutPanelVuelos.TabIndex = 6;
            // 
            // labelSinVuelos
            // 
            labelSinVuelos.AutoSize = true;
            labelSinVuelos.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            labelSinVuelos.Location = new Point(344, 237);
            labelSinVuelos.Name = "labelSinVuelos";
            labelSinVuelos.Size = new Size(255, 28);
            labelSinVuelos.TabIndex = 7;
            labelSinVuelos.Text = "No se encontraron vuelos";
            labelSinVuelos.Visible = false;
            // 
            // MenuUsuarioBuscarVueloForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1118, 720);
            Controls.Add(labelSinVuelos);
            Controls.Add(flowLayoutPanelVuelos);
            Controls.Add(panel1);
            Controls.Add(label1);
            Controls.Add(panelLineaDivisoria);
            Controls.Add(btnSalirDelSistema);
            Controls.Add(lblNombreApellido);
            Controls.Add(lblTituloAeroReservas);
            Margin = new Padding(3, 2, 3, 2);
            Name = "MenuUsuarioBuscarVueloForm";
            Text = "MenuUsuarioBuscarVueloForm";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTituloAeroReservas;
        private Label lblNombreApellido;
        private Button btnSalirDelSistema;
        private Panel panelLineaDivisoria;
        private Label label1;
        private Panel panel1;
        private Label lblCantidadPasajeros;
        private Label label3;
        private Label lblCiudadOrigen;
        private ComboBox comboBoxCiudadDestino;
        private ComboBox comboBoxCiudadOrigen;
        private ComboBox comboBoxCantidadPasajeros;
        private FlowLayoutPanel flowLayoutPanelVuelos;
        private Label labelSinVuelos;
    }
}