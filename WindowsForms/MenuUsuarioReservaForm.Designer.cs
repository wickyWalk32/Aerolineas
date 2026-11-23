namespace WindowsForms
{
    partial class MenuUsuarioReservaForm
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
            panelReserva = new Panel();
            label5 = new Label();
            labelFechaReserva = new Label();
            buttonImprimirReserva = new Button();
            buttonVolver = new Button();
            labelCostoTotal = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            flowLayoutPanelPasajes = new FlowLayoutPanel();
            reservaItemControlEnPanel = new ReservaItemControl();
            flowLayoutPanelReservas = new FlowLayoutPanel();
            label1 = new Label();
            printDocumentReserva = new System.Drawing.Printing.PrintDocument();
            buttonVolverMenuPrincipal = new Button();
            panelReserva.SuspendLayout();
            SuspendLayout();
            // 
            // panelReserva
            // 
            panelReserva.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panelReserva.AutoScroll = true;
            panelReserva.Controls.Add(label5);
            panelReserva.Controls.Add(labelFechaReserva);
            panelReserva.Controls.Add(buttonImprimirReserva);
            panelReserva.Controls.Add(buttonVolver);
            panelReserva.Controls.Add(labelCostoTotal);
            panelReserva.Controls.Add(label4);
            panelReserva.Controls.Add(label3);
            panelReserva.Controls.Add(label2);
            panelReserva.Controls.Add(flowLayoutPanelPasajes);
            panelReserva.Controls.Add(reservaItemControlEnPanel);
            panelReserva.Location = new Point(64, 80);
            panelReserva.Name = "panelReserva";
            panelReserva.Size = new Size(1420, 740);
            panelReserva.TabIndex = 2;
            panelReserva.Visible = false;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(20, 52);
            label5.Name = "label5";
            label5.Size = new Size(233, 20);
            label5.TabIndex = 1;
            label5.Text = "Fecha en que se realizó la reserva:";
            // 
            // labelFechaReserva
            // 
            labelFechaReserva.AutoSize = true;
            labelFechaReserva.Location = new Point(258, 52);
            labelFechaReserva.Name = "labelFechaReserva";
            labelFechaReserva.Size = new Size(98, 20);
            labelFechaReserva.TabIndex = 2;
            labelFechaReserva.Text = "FechaReserva";
            // 
            // buttonImprimirReserva
            // 
            buttonImprimirReserva.Location = new Point(710, 610);
            buttonImprimirReserva.Name = "buttonImprimirReserva";
            buttonImprimirReserva.Size = new Size(151, 34);
            buttonImprimirReserva.TabIndex = 9;
            buttonImprimirReserva.Text = "Imprimir Detalles";
            buttonImprimirReserva.UseVisualStyleBackColor = true;
            buttonImprimirReserva.Click += buttonImprimirReserva_Click;
            // 
            // buttonVolver
            // 
            buttonVolver.Location = new Point(20, 610);
            buttonVolver.Name = "buttonVolver";
            buttonVolver.Size = new Size(100, 34);
            buttonVolver.TabIndex = 7;
            buttonVolver.Text = "Volver";
            buttonVolver.UseVisualStyleBackColor = true;
            buttonVolver.Click += buttonVolver_Click;
            // 
            // labelCostoTotal
            // 
            labelCostoTotal.AutoSize = true;
            labelCostoTotal.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            labelCostoTotal.ForeColor = Color.Green;
            labelCostoTotal.Location = new Point(360, 615);
            labelCostoTotal.Name = "labelCostoTotal";
            labelCostoTotal.Size = new Size(106, 25);
            labelCostoTotal.TabIndex = 8;
            labelCostoTotal.Text = "CostoTotal";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            label4.Location = new Point(20, 222);
            label4.Name = "label4";
            label4.Size = new Size(279, 25);
            label4.TabIndex = 5;
            label4.Text = "Pasajeros, Asientos y Servicios";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            label3.Location = new Point(20, 90);
            label3.Name = "label3";
            label3.Size = new Size(146, 25);
            label3.TabIndex = 3;
            label3.Text = "Datos de Vuelo";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            label2.Location = new Point(20, 18);
            label2.Name = "label2";
            label2.Size = new Size(174, 25);
            label2.TabIndex = 0;
            label2.Text = "Detalle de Reserva";
            // 
            // flowLayoutPanelPasajes
            // 
            flowLayoutPanelPasajes.AutoScroll = true;
            flowLayoutPanelPasajes.Location = new Point(20, 255);
            flowLayoutPanelPasajes.Name = "flowLayoutPanelPasajes";
            flowLayoutPanelPasajes.Size = new Size(841, 330);
            flowLayoutPanelPasajes.TabIndex = 6;
            // 
            // reservaItemControlEnPanel
            // 
            reservaItemControlEnPanel.BackColor = SystemColors.GradientInactiveCaption;
            reservaItemControlEnPanel.BorderStyle = BorderStyle.FixedSingle;
            reservaItemControlEnPanel.Location = new Point(20, 122);
            reservaItemControlEnPanel.Margin = new Padding(3, 4, 3, 4);
            reservaItemControlEnPanel.Name = "reservaItemControlEnPanel";
            reservaItemControlEnPanel.Size = new Size(841, 85);
            reservaItemControlEnPanel.TabIndex = 4;
            // 
            // flowLayoutPanelReservas
            // 
            flowLayoutPanelReservas.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            flowLayoutPanelReservas.AutoScroll = true;
            flowLayoutPanelReservas.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanelReservas.Location = new Point(64, 80);
            flowLayoutPanelReservas.Name = "flowLayoutPanelReservas";
            flowLayoutPanelReservas.Size = new Size(1420, 740);
            flowLayoutPanelReservas.TabIndex = 1;
            flowLayoutPanelReservas.WrapContents = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            label1.Location = new Point(64, 32);
            label1.Name = "label1";
            label1.Size = new Size(162, 32);
            label1.TabIndex = 0;
            label1.Text = "Mis Reservas";
            // 
            // printDocumentReserva
            // 
            printDocumentReserva.PrintPage += printDocumentReserva_PrintPage;
            // 
            // buttonVolverMenuPrincipal
            // 
            buttonVolverMenuPrincipal.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            buttonVolverMenuPrincipal.Location = new Point(64, 845);
            buttonVolverMenuPrincipal.Name = "buttonVolverMenuPrincipal";
            buttonVolverMenuPrincipal.Size = new Size(135, 32);
            buttonVolverMenuPrincipal.TabIndex = 3;
            buttonVolverMenuPrincipal.Text = "Volver al Menu";
            buttonVolverMenuPrincipal.UseVisualStyleBackColor = true;
            buttonVolverMenuPrincipal.Click += buttonVolverMenuPrincipal_Click;
            // 
            // MenuUsuarioReservaForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1574, 967);
            WindowState = FormWindowState.Maximized;
            Controls.Add(buttonVolverMenuPrincipal);
            Controls.Add(panelReserva);
            Controls.Add(flowLayoutPanelReservas);
            Controls.Add(label1);
            Name = "MenuUsuarioReservaForm";
            Text = "AeroReservas - Mis Reservas";
            panelReserva.ResumeLayout(false);
            panelReserva.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panelReserva;
        private FlowLayoutPanel flowLayoutPanelReservas;
        private FlowLayoutPanel flowLayoutPanelPasajes;
        private Label label1;
        private Label label3;
        private ReservaItemControl reservaItemControlEnPanel;
        private Label label2;
        private Label label4;
        private Label labelCostoTotal;
        private Button buttonVolver;
        private System.Drawing.Printing.PrintDocument printDocumentReserva;
        private Button buttonImprimirReserva;
        private Button buttonVolverMenuPrincipal;
        private Label label5;
        private Label labelFechaReserva;
    }
}