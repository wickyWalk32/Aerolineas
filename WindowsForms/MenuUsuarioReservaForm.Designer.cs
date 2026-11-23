namespace WindowsForms
{
    partial class MenuUsuarioReservaForm
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
            panelReserva = new Panel();
            buttonImprimirReserva = new Button();
            buttonVolver = new Button();
            labelCostoTotal = new Label();
            label4 = new Label();
            label3 = new Label();
            reservaItemControlEnPanel = new ReservaItemControl();
            labelFechaReserva = new Label();
            label2 = new Label();
            flowLayoutPanelPasajes = new FlowLayoutPanel();
            flowLayoutPanelReservas = new FlowLayoutPanel();
            label1 = new Label();
            printDocumentReserva = new System.Drawing.Printing.PrintDocument();
            buttonVolverMenuPrincipal = new Button();
            panelReserva.SuspendLayout();
            SuspendLayout();
            // 
            // panelReserva
            // 
            panelReserva.AutoScroll = true;
            panelReserva.Controls.Add(buttonImprimirReserva);
            panelReserva.Controls.Add(buttonVolver);
            panelReserva.Controls.Add(labelCostoTotal);
            panelReserva.Controls.Add(label4);
            panelReserva.Controls.Add(label3);
            panelReserva.Controls.Add(reservaItemControlEnPanel);
            panelReserva.Controls.Add(labelFechaReserva);
            panelReserva.Controls.Add(label2);
            panelReserva.Controls.Add(flowLayoutPanelPasajes);
            panelReserva.Location = new Point(12, 60);
            panelReserva.Name = "panelReserva";
            panelReserva.Size = new Size(768, 521);
            panelReserva.TabIndex = 2;
            panelReserva.Visible = false;
            // 
            // buttonImprimirReserva
            // 
            buttonImprimirReserva.Location = new Point(307, 481);
            buttonImprimirReserva.Name = "buttonImprimirReserva";
            buttonImprimirReserva.Size = new Size(122, 23);
            buttonImprimirReserva.TabIndex = 10;
            buttonImprimirReserva.Text = "Imprimir Detalles";
            buttonImprimirReserva.UseVisualStyleBackColor = true;
            buttonImprimirReserva.Click += buttonImprimirReserva_Click;
            // 
            // buttonVolver
            // 
            buttonVolver.Location = new Point(69, 481);
            buttonVolver.Name = "buttonVolver";
            buttonVolver.Size = new Size(75, 23);
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
            labelCostoTotal.Location = new Point(519, 476);
            labelCostoTotal.Name = "labelCostoTotal";
            labelCostoTotal.Size = new Size(84, 20);
            labelCostoTotal.TabIndex = 6;
            labelCostoTotal.Text = "CostoTotal";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            label4.Location = new Point(45, 195);
            label4.Name = "label4";
            label4.Size = new Size(222, 20);
            label4.TabIndex = 5;
            label4.Text = "Pasajeros, Asientos y Servicios";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            label3.Location = new Point(45, 84);
            label3.Name = "label3";
            label3.Size = new Size(115, 20);
            label3.TabIndex = 4;
            label3.Text = "Datos de Vuelo";
            // 
            // reservaItemControlEnPanel
            // 
            reservaItemControlEnPanel.BackColor = SystemColors.GradientInactiveCaption;
            reservaItemControlEnPanel.BorderStyle = BorderStyle.FixedSingle;
            reservaItemControlEnPanel.Location = new Point(3, 107);
            reservaItemControlEnPanel.Name = "reservaItemControlEnPanel";
            reservaItemControlEnPanel.Size = new Size(682, 64);
            reservaItemControlEnPanel.TabIndex = 3;
            // 
            // labelFechaReserva
            // 
            labelFechaReserva.AutoSize = true;
            labelFechaReserva.Location = new Point(55, 44);
            labelFechaReserva.Name = "labelFechaReserva";
            labelFechaReserva.Size = new Size(78, 15);
            labelFechaReserva.TabIndex = 2;
            labelFechaReserva.Text = "FechaReserva";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            label2.Location = new Point(45, 15);
            label2.Name = "label2";
            label2.Size = new Size(139, 20);
            label2.TabIndex = 1;
            label2.Text = "Detalle de Reserva";
            // 
            // flowLayoutPanelPasajes
            // 
            flowLayoutPanelPasajes.AutoScroll = true;
            flowLayoutPanelPasajes.Location = new Point(83, 218);
            flowLayoutPanelPasajes.Name = "flowLayoutPanelPasajes";
            flowLayoutPanelPasajes.Size = new Size(554, 224);
            flowLayoutPanelPasajes.TabIndex = 0;
            // 
            // flowLayoutPanelReservas
            // 
            flowLayoutPanelReservas.AutoScroll = true;
            flowLayoutPanelReservas.Location = new Point(12, 60);
            flowLayoutPanelReservas.Name = "flowLayoutPanelReservas";
            flowLayoutPanelReservas.Size = new Size(777, 439);
            flowLayoutPanelReservas.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            label1.Location = new Point(60, 32);
            label1.Name = "label1";
            label1.Size = new Size(125, 25);
            label1.TabIndex = 2;
            label1.Text = "Mis Reservas";
            // 
            // printDocumentReserva
            // 
            printDocumentReserva.PrintPage += printDocumentReserva_PrintPage;
            // 
            // buttonVolverMenuPrincipal
            // 
            buttonVolverMenuPrincipal.Location = new Point(58, 615);
            buttonVolverMenuPrincipal.Name = "buttonVolverMenuPrincipal";
            buttonVolverMenuPrincipal.Size = new Size(114, 23);
            buttonVolverMenuPrincipal.TabIndex = 3;
            buttonVolverMenuPrincipal.Text = "Volver al Menu";
            buttonVolverMenuPrincipal.UseVisualStyleBackColor = true;
            buttonVolverMenuPrincipal.Click += buttonVolverMenuPrincipal_Click;
            // 
            // MenuUsuarioReservaForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(858, 653);
            Controls.Add(buttonVolverMenuPrincipal);
            Controls.Add(label1);
            Controls.Add(flowLayoutPanelReservas);
            Controls.Add(panelReserva);
            Name = "MenuUsuarioReservaForm";
            Text = "MenuUsuarioReservaForm";
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
        private Label labelFechaReserva;
        private Label label2;
        private Label label4;
        private Label labelCostoTotal;
        private Button buttonVolver;
        private System.Drawing.Printing.PrintDocument printDocumentReserva;
        private Button buttonImprimirReserva;
        private Button buttonVolverMenuPrincipal;
    }
}