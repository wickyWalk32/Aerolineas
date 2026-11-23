namespace WindowsForms
{
    partial class MenuUsuarioSeleccionarAsientoForm
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
            avionControl = new AvionControl();
            label1 = new Label();
            flowLayoutPanelPasajeros = new FlowLayoutPanel();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            textBoxNombre = new TextBox();
            textBoxApellido = new TextBox();
            textBoxDocumento = new TextBox();
            comboBoxTipoDocumento = new ComboBox();
            label6 = new Label();
            comboBoxEdad = new ComboBox();
            buttonGuardar = new Button();
            label7 = new Label();
            buttonContinuar = new Button();
            buttonVolver = new Button();
            SuspendLayout();
            // 
            // avionControl
            // 
            avionControl.Location = new Point(536, 55);
            avionControl.Name = "avionControl";
            avionControl.Size = new Size(237, 645);
            avionControl.TabIndex = 0;
            avionControl.Click += avionControl_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label1.Location = new Point(573, 31);
            label1.Name = "label1";
            label1.Size = new Size(160, 21);
            label1.TabIndex = 1;
            label1.Text = "Seleccionar Asiento";
            // 
            // flowLayoutPanelPasajeros
            // 
            flowLayoutPanelPasajeros.Location = new Point(83, 143);
            flowLayoutPanelPasajeros.Name = "flowLayoutPanelPasajeros";
            flowLayoutPanelPasajeros.Size = new Size(274, 100);
            flowLayoutPanelPasajeros.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(72, 309);
            label2.Name = "label2";
            label2.Size = new Size(51, 15);
            label2.TabIndex = 3;
            label2.Text = "Nombre";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(72, 343);
            label3.Name = "label3";
            label3.Size = new Size(51, 15);
            label3.TabIndex = 4;
            label3.Text = "Apellido";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(72, 381);
            label4.Name = "label4";
            label4.Size = new Size(70, 15);
            label4.TabIndex = 5;
            label4.Text = "Documento";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(72, 427);
            label5.Name = "label5";
            label5.Size = new Size(96, 15);
            label5.TabIndex = 6;
            label5.Text = "Tipo Documento";
            // 
            // textBoxNombre
            // 
            textBoxNombre.Location = new Point(177, 306);
            textBoxNombre.Name = "textBoxNombre";
            textBoxNombre.Size = new Size(134, 23);
            textBoxNombre.TabIndex = 7;
            // 
            // textBoxApellido
            // 
            textBoxApellido.Location = new Point(177, 340);
            textBoxApellido.Name = "textBoxApellido";
            textBoxApellido.Size = new Size(134, 23);
            textBoxApellido.TabIndex = 8;
            // 
            // textBoxDocumento
            // 
            textBoxDocumento.Location = new Point(177, 378);
            textBoxDocumento.Name = "textBoxDocumento";
            textBoxDocumento.Size = new Size(134, 23);
            textBoxDocumento.TabIndex = 9;
            // 
            // comboBoxTipoDocumento
            // 
            comboBoxTipoDocumento.FormattingEnabled = true;
            comboBoxTipoDocumento.Items.AddRange(new object[] { "Documento Nacional de Identidad (DNI)", "Libreta de enrolamiento (LE)", "Libreta cívica (LC)" });
            comboBoxTipoDocumento.Location = new Point(174, 421);
            comboBoxTipoDocumento.Name = "comboBoxTipoDocumento";
            comboBoxTipoDocumento.Size = new Size(226, 23);
            comboBoxTipoDocumento.TabIndex = 10;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(72, 276);
            label6.Name = "label6";
            label6.Size = new Size(33, 15);
            label6.TabIndex = 11;
            label6.Text = "Edad";
            // 
            // comboBoxEdad
            // 
            comboBoxEdad.FormattingEnabled = true;
            comboBoxEdad.Items.AddRange(new object[] { "Mayor (+16)", "Menor" });
            comboBoxEdad.Location = new Point(176, 272);
            comboBoxEdad.Name = "comboBoxEdad";
            comboBoxEdad.Size = new Size(121, 23);
            comboBoxEdad.TabIndex = 12;
            // 
            // buttonGuardar
            // 
            buttonGuardar.Location = new Point(194, 506);
            buttonGuardar.Name = "buttonGuardar";
            buttonGuardar.Size = new Size(126, 23);
            buttonGuardar.TabIndex = 13;
            buttonGuardar.Text = "Guardar Cambios";
            buttonGuardar.UseVisualStyleBackColor = true;
            buttonGuardar.Click += buttonGuardar_Click;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label7.Location = new Point(143, 108);
            label7.Name = "label7";
            label7.Size = new Size(82, 21);
            label7.TabIndex = 14;
            label7.Text = "Pasajeros\r\n";
            // 
            // buttonSiguiente
            // 
            buttonContinuar.Location = new Point(362, 584);
            buttonContinuar.Name = "buttonSiguiente";
            buttonContinuar.Size = new Size(106, 23);
            buttonContinuar.TabIndex = 15;
            buttonContinuar.Text = "Siguiente";
            buttonContinuar.UseVisualStyleBackColor = true;
            buttonContinuar.Click += buttonSiguiente_Click;
            // 
            // buttonVolver
            // 
            buttonVolver.Location = new Point(44, 584);
            buttonVolver.Name = "buttonVolver";
            buttonVolver.Size = new Size(98, 23);
            buttonVolver.TabIndex = 16;
            buttonVolver.Text = "Volver";
            buttonVolver.UseVisualStyleBackColor = true;
            buttonVolver.Click += buttonVolver_Click;
            // 
            // MenuUsuarioSeleccionarAsientoForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 749);
            WindowState = FormWindowState.Maximized;
            Controls.Add(buttonVolver);
            Controls.Add(buttonContinuar);
            Controls.Add(label7);
            Controls.Add(buttonGuardar);
            Controls.Add(comboBoxEdad);
            Controls.Add(label6);
            Controls.Add(comboBoxTipoDocumento);
            Controls.Add(textBoxDocumento);
            Controls.Add(textBoxApellido);
            Controls.Add(textBoxNombre);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(flowLayoutPanelPasajeros);
            Controls.Add(label1);
            Controls.Add(avionControl);
            Name = "MenuUsuarioSeleccionarAsientoForm";
            Text = "MenuUsuarioSeleccionarAsientoForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private AvionControl avionControl;
        private Label label1;
        private FlowLayoutPanel flowLayoutPanelPasajeros;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private TextBox textBoxNombre;
        private TextBox textBoxApellido;
        private TextBox textBoxDocumento;
        private ComboBox comboBoxTipoDocumento;
        private Label label6;
        private ComboBox comboBoxEdad;
        private Button buttonGuardar;
        private Label label7;
        private Button buttonContinuar;
        private Button buttonVolver;
    }
}