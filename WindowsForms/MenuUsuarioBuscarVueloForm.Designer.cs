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
            comboBoxCiudadDestino = new ComboBox();
            comboBoxCiudadOrigen = new ComboBox();
            btnBuscarVuelos = new Button();
            textBoxCantidadPasajeros = new TextBox();
            lblCantidadPasajeros = new Label();
            label3 = new Label();
            lblCiudadOrigen = new Label();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // lblTituloAeroReservas
            // 
            lblTituloAeroReservas.AutoSize = true;
            lblTituloAeroReservas.Font = new Font("Segoe UI", 20F, FontStyle.Italic);
            lblTituloAeroReservas.Location = new Point(32, 17);
            lblTituloAeroReservas.Name = "lblTituloAeroReservas";
            lblTituloAeroReservas.Size = new Size(283, 46);
            lblTituloAeroReservas.TabIndex = 0;
            lblTituloAeroReservas.Text = "AeroReservas.com";
            // 
            // lblNombreApellido
            // 
            lblNombreApellido.AutoSize = true;
            lblNombreApellido.Location = new Point(551, 37);
            lblNombreApellido.Name = "lblNombreApellido";
            lblNombreApellido.Size = new Size(211, 20);
            lblNombreApellido.TabIndex = 1;
            lblNombreApellido.Text = "Bienvenido Nombre Apellido !";
            // 
            // btnSalirDelSistema
            // 
            btnSalirDelSistema.Location = new Point(1080, 33);
            btnSalirDelSistema.Name = "btnSalirDelSistema";
            btnSalirDelSistema.Size = new Size(135, 29);
            btnSalirDelSistema.TabIndex = 2;
            btnSalirDelSistema.Text = "Salir del sistema";
            btnSalirDelSistema.UseVisualStyleBackColor = true;
            btnSalirDelSistema.Click += btnSalirDelSistema_Click;
            // 
            // panelLineaDivisoria
            // 
            panelLineaDivisoria.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panelLineaDivisoria.BackColor = SystemColors.Desktop;
            panelLineaDivisoria.Location = new Point(-10, 78);
            panelLineaDivisoria.Name = "panelLineaDivisoria";
            panelLineaDivisoria.Size = new Size(1285, 1);
            panelLineaDivisoria.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F);
            label1.Location = new Point(66, 131);
            label1.Name = "label1";
            label1.Size = new Size(374, 28);
            label1.TabIndex = 4;
            label1.Text = "Ingrese datos de búsqueda para su vuelo!";
            // 
            // panel1
            // 
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(comboBoxCiudadDestino);
            panel1.Controls.Add(comboBoxCiudadOrigen);
            panel1.Controls.Add(btnBuscarVuelos);
            panel1.Controls.Add(textBoxCantidadPasajeros);
            panel1.Controls.Add(lblCantidadPasajeros);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(lblCiudadOrigen);
            panel1.Location = new Point(66, 174);
            panel1.Name = "panel1";
            panel1.Size = new Size(1130, 314);
            panel1.TabIndex = 5;
            // 
            // comboBoxCiudadDestino
            // 
            comboBoxCiudadDestino.FormattingEnabled = true;
            comboBoxCiudadDestino.Location = new Point(201, 110);
            comboBoxCiudadDestino.Name = "comboBoxCiudadDestino";
            comboBoxCiudadDestino.Size = new Size(298, 28);
            comboBoxCiudadDestino.TabIndex = 8;
            // 
            // comboBoxCiudadOrigen
            // 
            comboBoxCiudadOrigen.FormattingEnabled = true;
            comboBoxCiudadOrigen.Location = new Point(201, 53);
            comboBoxCiudadOrigen.Name = "comboBoxCiudadOrigen";
            comboBoxCiudadOrigen.Size = new Size(298, 28);
            comboBoxCiudadOrigen.TabIndex = 7;
            // 
            // btnBuscarVuelos
            // 
            btnBuscarVuelos.Location = new Point(439, 227);
            btnBuscarVuelos.Name = "btnBuscarVuelos";
            btnBuscarVuelos.Size = new Size(268, 43);
            btnBuscarVuelos.TabIndex = 6;
            btnBuscarVuelos.Text = "Buscar vuelos";
            btnBuscarVuelos.UseVisualStyleBackColor = true;
            btnBuscarVuelos.Click += btnBuscarVuelos_Click;
            // 
            // textBoxCantidadPasajeros
            // 
            textBoxCantidadPasajeros.Location = new Point(808, 54);
            textBoxCantidadPasajeros.Name = "textBoxCantidadPasajeros";
            textBoxCantidadPasajeros.Size = new Size(244, 27);
            textBoxCantidadPasajeros.TabIndex = 5;
            // 
            // lblCantidadPasajeros
            // 
            lblCantidadPasajeros.AutoSize = true;
            lblCantidadPasajeros.Location = new Point(635, 56);
            lblCantidadPasajeros.Name = "lblCantidadPasajeros";
            lblCantidadPasajeros.Size = new Size(157, 20);
            lblCantidadPasajeros.TabIndex = 2;
            lblCantidadPasajeros.Text = "Cantidad de pasajeros";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(61, 110);
            label3.Name = "label3";
            label3.Size = new Size(130, 20);
            label3.TabIndex = 1;
            label3.Text = "Ciudad de destino";
            // 
            // lblCiudadOrigen
            // 
            lblCiudadOrigen.AutoSize = true;
            lblCiudadOrigen.Location = new Point(61, 57);
            lblCiudadOrigen.Name = "lblCiudadOrigen";
            lblCiudadOrigen.Size = new Size(124, 20);
            lblCiudadOrigen.TabIndex = 0;
            lblCiudadOrigen.Text = "Ciudad de origen";
            // 
            // MenuUsuarioBuscarVueloForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1278, 565);
            Controls.Add(panel1);
            Controls.Add(label1);
            Controls.Add(panelLineaDivisoria);
            Controls.Add(btnSalirDelSistema);
            Controls.Add(lblNombreApellido);
            Controls.Add(lblTituloAeroReservas);
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
        private Button btnBuscarVuelos;
        private TextBox textBoxCantidadPasajeros;
        private Label lblCantidadPasajeros;
        private Label label3;
        private Label lblCiudadOrigen;
        private ComboBox comboBoxCiudadDestino;
        private ComboBox comboBoxCiudadOrigen;
    }
}