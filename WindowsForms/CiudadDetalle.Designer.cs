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
            label3 = new Label();
            textBoxCodigoAeropuerto = new TextBox();
            comboBoxPais = new ComboBox();
            label4 = new Label();
            btnVolver = new Button();
            SuspendLayout();
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(72, 216);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(75, 23);
            btnGuardar.TabIndex = 0;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // textBoxNombre
            // 
            textBoxNombre.Location = new Point(204, 25);
            textBoxNombre.Name = "textBoxNombre";
            textBoxNombre.Size = new Size(100, 23);
            textBoxNombre.TabIndex = 1;
            // 
            // textBoxCodigoPostal
            // 
            textBoxCodigoPostal.Location = new Point(204, 73);
            textBoxCodigoPostal.Name = "textBoxCodigoPostal";
            textBoxCodigoPostal.Size = new Size(100, 23);
            textBoxCodigoPostal.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(96, 33);
            label1.Name = "label1";
            label1.Size = new Size(51, 15);
            label1.TabIndex = 3;
            label1.Text = "Nombre";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(86, 81);
            label2.Name = "label2";
            label2.Size = new Size(81, 15);
            label2.TabIndex = 4;
            label2.Text = "Codigo Postal";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(72, 124);
            label3.Name = "label3";
            label3.Size = new Size(109, 15);
            label3.TabIndex = 6;
            label3.Text = "Codigo Aeropuerto";
            // 
            // textBoxCodigoAeropuerto
            // 
            textBoxCodigoAeropuerto.Location = new Point(204, 121);
            textBoxCodigoAeropuerto.Name = "textBoxCodigoAeropuerto";
            textBoxCodigoAeropuerto.Size = new Size(100, 23);
            textBoxCodigoAeropuerto.TabIndex = 5;
            // 
            // comboBoxPais
            // 
            comboBoxPais.FormattingEnabled = true;
            comboBoxPais.Location = new Point(204, 170);
            comboBoxPais.Name = "comboBoxPais";
            comboBoxPais.Size = new Size(121, 23);
            comboBoxPais.TabIndex = 7;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(119, 173);
            label4.Name = "label4";
            label4.Size = new Size(28, 15);
            label4.TabIndex = 8;
            label4.Text = "Pais";
            // 
            // btnVolver
            // 
            btnVolver.Location = new Point(204, 216);
            btnVolver.Name = "btnVolver";
            btnVolver.Size = new Size(75, 23);
            btnVolver.TabIndex = 9;
            btnVolver.Text = "Volver";
            btnVolver.UseVisualStyleBackColor = true;
            btnVolver.Click += btnVolver_Click;
            // 
            // CiudadDetalle
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(356, 255);
            Controls.Add(btnVolver);
            Controls.Add(label4);
            Controls.Add(comboBoxPais);
            Controls.Add(label3);
            Controls.Add(textBoxCodigoAeropuerto);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(textBoxCodigoPostal);
            Controls.Add(textBoxNombre);
            Controls.Add(btnGuardar);
            Name = "CiudadDetalle";
            Text = "Ciudad";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnGuardar;
        private TextBox textBoxNombre;
        private TextBox textBoxCodigoPostal;
        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox textBoxCodigoAeropuerto;
        private ComboBox comboBoxPais;
        private Label label4;
        private Button btnVolver;
    }
}