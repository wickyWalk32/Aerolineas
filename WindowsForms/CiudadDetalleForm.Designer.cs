namespace WindowsForms
{
    partial class CiudadDetalleForm
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
            btnGuardar = new Button();
            textBoxNombre = new TextBox();
            textBoxCodigoPostal = new TextBox();
            label1 = new Label();
            label2 = new Label();
            textBoxCodigoAeropuerto = new TextBox();
            label3 = new Label();
            btnVolver = new Button();
            label4 = new Label();
            comboBoxPais = new ComboBox();
            lblTituloNuevoEditarCiudad = new Label();
            panel1 = new Panel();
            lblIdCiudad = new Label();
            lblId = new Label();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(104, 190);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(82, 23);
            btnGuardar.TabIndex = 0;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // textBoxNombre
            // 
            textBoxNombre.Location = new Point(150, 47);
            textBoxNombre.Name = "textBoxNombre";
            textBoxNombre.Size = new Size(121, 23);
            textBoxNombre.TabIndex = 1;
            // 
            // textBoxCodigoPostal
            // 
            textBoxCodigoPostal.Location = new Point(150, 81);
            textBoxCodigoPostal.Name = "textBoxCodigoPostal";
            textBoxCodigoPostal.Size = new Size(121, 23);
            textBoxCodigoPostal.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(24, 50);
            label1.Name = "label1";
            label1.Size = new Size(51, 15);
            label1.TabIndex = 3;
            label1.Text = "Nombre";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(24, 83);
            label2.Name = "label2";
            label2.Size = new Size(81, 15);
            label2.TabIndex = 4;
            label2.Text = "Codigo Postal";
            // 
            // textBoxCodigoAeropuerto
            // 
            textBoxCodigoAeropuerto.Location = new Point(150, 111);
            textBoxCodigoAeropuerto.Name = "textBoxCodigoAeropuerto";
            textBoxCodigoAeropuerto.Size = new Size(121, 23);
            textBoxCodigoAeropuerto.TabIndex = 5;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(24, 113);
            label3.Name = "label3";
            label3.Size = new Size(109, 15);
            label3.TabIndex = 6;
            label3.Text = "Codigo Aeropuerto";
            // 
            // btnVolver
            // 
            btnVolver.Location = new Point(110, 338);
            btnVolver.Name = "btnVolver";
            btnVolver.Size = new Size(75, 23);
            btnVolver.TabIndex = 9;
            btnVolver.Text = "Volver";
            btnVolver.UseVisualStyleBackColor = true;
            btnVolver.Click += btnVolver_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(24, 146);
            label4.Name = "label4";
            label4.Size = new Size(28, 15);
            label4.TabIndex = 8;
            label4.Text = "Pais";
            // 
            // comboBoxPais
            // 
            comboBoxPais.FormattingEnabled = true;
            comboBoxPais.Location = new Point(150, 144);
            comboBoxPais.Name = "comboBoxPais";
            comboBoxPais.Size = new Size(121, 23);
            comboBoxPais.TabIndex = 7;
            // 
            // lblTituloNuevoEditarCiudad
            // 
            lblTituloNuevoEditarCiudad.AutoSize = true;
            lblTituloNuevoEditarCiudad.Font = new Font("Segoe UI", 16F);
            lblTituloNuevoEditarCiudad.Location = new Point(110, 21);
            lblTituloNuevoEditarCiudad.Name = "lblTituloNuevoEditarCiudad";
            lblTituloNuevoEditarCiudad.Size = new Size(206, 30);
            lblTituloNuevoEditarCiudad.TabIndex = 10;
            lblTituloNuevoEditarCiudad.Text = "NuevoEditar Ciudad";
            // 
            // panel1
            // 
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(lblIdCiudad);
            panel1.Controls.Add(lblId);
            panel1.Controls.Add(comboBoxPais);
            panel1.Controls.Add(btnGuardar);
            panel1.Controls.Add(textBoxNombre);
            panel1.Controls.Add(textBoxCodigoPostal);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(textBoxCodigoAeropuerto);
            panel1.Location = new Point(221, 71);
            panel1.Margin = new Padding(3, 2, 3, 2);
            panel1.Name = "panel1";
            panel1.Size = new Size(295, 240);
            panel1.TabIndex = 11;
            // 
            // lblIdCiudad
            // 
            lblIdCiudad.AutoSize = true;
            lblIdCiudad.Location = new Point(150, 19);
            lblIdCiudad.Name = "lblIdCiudad";
            lblIdCiudad.Size = new Size(38, 15);
            lblIdCiudad.TabIndex = 10;
            lblIdCiudad.Text = "label6";
            // 
            // lblId
            // 
            lblId.AutoSize = true;
            lblId.Location = new Point(24, 19);
            lblId.Name = "lblId";
            lblId.Size = new Size(17, 15);
            lblId.TabIndex = 9;
            lblId.Text = "Id";
            // 
            // CiudadDetalleForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(700, 392);
            Controls.Add(panel1);
            Controls.Add(lblTituloNuevoEditarCiudad);
            Controls.Add(btnVolver);
            Name = "CiudadDetalleForm";
            Text = "Administrador";
            Load += CiudadDetalleForm_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnGuardar;
        private TextBox textBoxNombre;
        private TextBox textBoxCodigoPostal;
        private Label label1;
        private Label label2;
        private TextBox textBoxCodigoAeropuerto;
        private Label label3;
        private Button btnVolver;
        private Label label4;
        private ComboBox comboBoxPais;
        private Label lblTituloNuevoEditarCiudad;
        private Panel panel1;
        private Label lblIdCiudad;
        private Label lblId;
    }
}