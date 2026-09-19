namespace WindowsForms
{
    partial class CiudadDetalle
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
            lblTituloId = new Label();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(119, 254);
            btnGuardar.Margin = new Padding(3, 4, 3, 4);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(94, 31);
            btnGuardar.TabIndex = 0;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // textBoxNombre
            // 
            textBoxNombre.Location = new Point(172, 63);
            textBoxNombre.Margin = new Padding(3, 4, 3, 4);
            textBoxNombre.Name = "textBoxNombre";
            textBoxNombre.Size = new Size(138, 27);
            textBoxNombre.TabIndex = 1;
            // 
            // textBoxCodigoPostal
            // 
            textBoxCodigoPostal.Location = new Point(172, 108);
            textBoxCodigoPostal.Margin = new Padding(3, 4, 3, 4);
            textBoxCodigoPostal.Name = "textBoxCodigoPostal";
            textBoxCodigoPostal.Size = new Size(138, 27);
            textBoxCodigoPostal.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(28, 66);
            label1.Name = "label1";
            label1.Size = new Size(64, 20);
            label1.TabIndex = 3;
            label1.Text = "Nombre";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(28, 111);
            label2.Name = "label2";
            label2.Size = new Size(101, 20);
            label2.TabIndex = 4;
            label2.Text = "Codigo Postal";
            // 
            // textBoxCodigoAeropuerto
            // 
            textBoxCodigoAeropuerto.Location = new Point(172, 148);
            textBoxCodigoAeropuerto.Margin = new Padding(3, 4, 3, 4);
            textBoxCodigoAeropuerto.Name = "textBoxCodigoAeropuerto";
            textBoxCodigoAeropuerto.Size = new Size(138, 27);
            textBoxCodigoAeropuerto.TabIndex = 5;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(28, 151);
            label3.Name = "label3";
            label3.Size = new Size(138, 20);
            label3.TabIndex = 6;
            label3.Text = "Codigo Aeropuerto";
            // 
            // btnVolver
            // 
            btnVolver.Location = new Point(126, 450);
            btnVolver.Margin = new Padding(3, 4, 3, 4);
            btnVolver.Name = "btnVolver";
            btnVolver.Size = new Size(86, 31);
            btnVolver.TabIndex = 9;
            btnVolver.Text = "Volver";
            btnVolver.UseVisualStyleBackColor = true;
            btnVolver.Click += btnVolver_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(28, 195);
            label4.Name = "label4";
            label4.Size = new Size(34, 20);
            label4.TabIndex = 8;
            label4.Text = "Pais";
            // 
            // comboBoxPais
            // 
            comboBoxPais.FormattingEnabled = true;
            comboBoxPais.Location = new Point(172, 192);
            comboBoxPais.Margin = new Padding(3, 4, 3, 4);
            comboBoxPais.Name = "comboBoxPais";
            comboBoxPais.Size = new Size(138, 28);
            comboBoxPais.TabIndex = 7;
            // 
            // lblTituloNuevoEditarCiudad
            // 
            lblTituloNuevoEditarCiudad.AutoSize = true;
            lblTituloNuevoEditarCiudad.Font = new Font("Segoe UI", 16F);
            lblTituloNuevoEditarCiudad.Location = new Point(126, 28);
            lblTituloNuevoEditarCiudad.Name = "lblTituloNuevoEditarCiudad";
            lblTituloNuevoEditarCiudad.Size = new Size(256, 37);
            lblTituloNuevoEditarCiudad.TabIndex = 10;
            lblTituloNuevoEditarCiudad.Text = "NuevoEditar Ciudad";
            // 
            // panel1
            // 
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(lblIdCiudad);
            panel1.Controls.Add(lblTituloId);
            panel1.Controls.Add(comboBoxPais);
            panel1.Controls.Add(btnGuardar);
            panel1.Controls.Add(textBoxNombre);
            panel1.Controls.Add(textBoxCodigoPostal);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(textBoxCodigoAeropuerto);
            panel1.Location = new Point(253, 95);
            panel1.Name = "panel1";
            panel1.Size = new Size(337, 319);
            panel1.TabIndex = 11;
            // 
            // lblIdCiudad
            // 
            lblIdCiudad.AutoSize = true;
            lblIdCiudad.Location = new Point(172, 25);
            lblIdCiudad.Name = "lblIdCiudad";
            lblIdCiudad.Size = new Size(50, 20);
            lblIdCiudad.TabIndex = 10;
            lblIdCiudad.Text = "label6";
            // 
            // lblTituloId
            // 
            lblTituloId.AutoSize = true;
            lblTituloId.Location = new Point(28, 25);
            lblTituloId.Name = "lblTituloId";
            lblTituloId.Size = new Size(22, 20);
            lblTituloId.TabIndex = 9;
            lblTituloId.Text = "Id";
            // 
            // CiudadDetalle
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 523);
            Controls.Add(panel1);
            Controls.Add(lblTituloNuevoEditarCiudad);
            Controls.Add(btnVolver);
            Margin = new Padding(3, 4, 3, 4);
            Name = "CiudadDetalle";
            Text = "Administrador";
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
        private Label lblTituloId;
    }
}