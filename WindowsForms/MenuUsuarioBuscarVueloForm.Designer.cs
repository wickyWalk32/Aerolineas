namespace WindowsForms
{
    partial class MenuUsuarioBuscarVueloForm
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
            buttonMisReservas = new Button();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // lblTituloAeroReservas
            // 
            lblTituloAeroReservas.AutoSize = true;
            lblTituloAeroReservas.Font = new Font("Segoe UI", 20F, FontStyle.Italic);
            lblTituloAeroReservas.Location = new Point(28, 13);
            lblTituloAeroReservas.Name = "lblTituloAeroReservas";
            lblTituloAeroReservas.Text = "AeroReservas.com";
            // 
            // lblNombreApellido
            // 
            lblNombreApellido.AutoSize = true;
            lblNombreApellido.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblNombreApellido.Location = new Point(340, 26);
            lblNombreApellido.Name = "lblNombreApellido";
            lblNombreApellido.Text = "Bienvenido Nombre Apellido !";
            // 
            // btnSalirDelSistema
            // 
            btnSalirDelSistema.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnSalirDelSistema.Location = new Point(960, 22);
            btnSalirDelSistema.Name = "btnSalirDelSistema";
            btnSalirDelSistema.Size = new Size(125, 28);
            btnSalirDelSistema.TabIndex = 2;
            btnSalirDelSistema.Text = "Salir del sistema";
            btnSalirDelSistema.UseVisualStyleBackColor = true;
            btnSalirDelSistema.Click += btnSalirDelSistema_Click;
            // 
            // panelLineaDivisoria
            // 
            panelLineaDivisoria.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panelLineaDivisoria.BackColor = SystemColors.Desktop;
            panelLineaDivisoria.Location = new Point(0, 62);
            panelLineaDivisoria.Name = "panelLineaDivisoria";
            panelLineaDivisoria.Size = new Size(1118, 2);
            panelLineaDivisoria.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F);
            label1.Location = new Point(44, 82);
            label1.Name = "label1";
            label1.Text = "Ingrese datos de búsqueda para su vuelo!";
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(comboBoxCantidadPasajeros);
            panel1.Controls.Add(comboBoxCiudadDestino);
            panel1.Controls.Add(comboBoxCiudadOrigen);
            panel1.Controls.Add(lblCantidadPasajeros);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(lblCiudadOrigen);
            panel1.Location = new Point(44, 115);
            panel1.Name = "panel1";
            panel1.Size = new Size(1040, 70);
            panel1.TabIndex = 5;
            // 
            // lblCiudadOrigen
            // 
            lblCiudadOrigen.AutoSize = true;
            lblCiudadOrigen.Location = new Point(15, 25);
            lblCiudadOrigen.Name = "lblCiudadOrigen";
            lblCiudadOrigen.Text = "Origen";
            // 
            // comboBoxCiudadOrigen
            // 
            comboBoxCiudadOrigen.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxCiudadOrigen.FormattingEnabled = true;
            comboBoxCiudadOrigen.Location = new Point(65, 22);
            comboBoxCiudadOrigen.Name = "comboBoxCiudadOrigen";
            comboBoxCiudadOrigen.Size = new Size(220, 23);
            comboBoxCiudadOrigen.TabIndex = 1;
            comboBoxCiudadOrigen.SelectedIndexChanged += FiltrarVuelos;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(305, 25);
            label3.Name = "label3";
            label3.Text = "Destino";
            // 
            // comboBoxCiudadDestino
            // 
            comboBoxCiudadDestino.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxCiudadDestino.FormattingEnabled = true;
            comboBoxCiudadDestino.Location = new Point(360, 22);
            comboBoxCiudadDestino.Name = "comboBoxCiudadDestino";
            comboBoxCiudadDestino.Size = new Size(220, 23);
            comboBoxCiudadDestino.TabIndex = 2;
            comboBoxCiudadDestino.SelectedIndexChanged += FiltrarVuelos;
            // 
            // lblCantidadPasajeros
            // 
            lblCantidadPasajeros.AutoSize = true;
            lblCantidadPasajeros.Location = new Point(600, 25);
            lblCantidadPasajeros.Name = "lblCantidadPasajeros";
            lblCantidadPasajeros.Text = "Pasajeros";
            // 
            // comboBoxCantidadPasajeros
            // 
            comboBoxCantidadPasajeros.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxCantidadPasajeros.FormattingEnabled = true;
            comboBoxCantidadPasajeros.Location = new Point(665, 22);
            comboBoxCantidadPasajeros.Name = "comboBoxCantidadPasajeros";
            comboBoxCantidadPasajeros.Size = new Size(220, 23);
            comboBoxCantidadPasajeros.TabIndex = 3;
            comboBoxCantidadPasajeros.SelectedIndexChanged += FiltrarVuelos;
            // 
            // labelSinVuelos
            // 
            labelSinVuelos.AutoSize = true;
            labelSinVuelos.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            labelSinVuelos.Location = new Point(44, 205);
            labelSinVuelos.Name = "labelSinVuelos";
            labelSinVuelos.Text = "No se encontraron vuelos";
            labelSinVuelos.Visible = false;
            // 
            // flowLayoutPanelVuelos
            // 
            flowLayoutPanelVuelos.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            flowLayoutPanelVuelos.AutoScroll = true;
            flowLayoutPanelVuelos.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanelVuelos.WrapContents = false;
            flowLayoutPanelVuelos.Location = new Point(44, 240);
            flowLayoutPanelVuelos.Name = "flowLayoutPanelVuelos";
            flowLayoutPanelVuelos.Size = new Size(1040, 450);
            flowLayoutPanelVuelos.TabIndex = 6;
            // 
            // buttonMisReservas
            // 
            buttonMisReservas.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            buttonMisReservas.Location = new Point(825, 22);
            buttonMisReservas.Name = "buttonMisReservas";
            buttonMisReservas.Size = new Size(120, 28);
            buttonMisReservas.TabIndex = 8;
            buttonMisReservas.Text = "Mis Reservas";
            buttonMisReservas.UseVisualStyleBackColor = true;
            buttonMisReservas.Click += buttonMisReservas_Click;
            // 
            // MenuUsuarioBuscarVueloForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1118, 720);
            WindowState = FormWindowState.Maximized;
            Controls.Add(buttonMisReservas);
            Controls.Add(labelSinVuelos);
            Controls.Add(flowLayoutPanelVuelos);
            Controls.Add(panel1);
            Controls.Add(label1);
            Controls.Add(panelLineaDivisoria);
            Controls.Add(btnSalirDelSistema);
            Controls.Add(lblNombreApellido);
            Controls.Add(lblTituloAeroReservas);
            Name = "MenuUsuarioBuscarVueloForm";
            Text = "AeroReservas - Buscar Vuelo";
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
        private Button buttonMisReservas;
    }
}