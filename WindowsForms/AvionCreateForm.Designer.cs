namespace WindowsForms
{
    partial class AvionCreateForm
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
            panel1 = new Panel();
            comboBoxDisponibilidad = new ComboBox();
            btnGuardar = new Button();
            textBoxDescripcion = new TextBox();
            textBoxCapacidad = new TextBox();
            label4 = new Label();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            lblTituloNuevoEditarAvion = new Label();
            btnVolver = new Button();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(comboBoxDisponibilidad);
            panel1.Controls.Add(btnGuardar);
            panel1.Controls.Add(textBoxDescripcion);
            panel1.Controls.Add(textBoxCapacidad);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label3);
            panel1.Location = new Point(233, 104);
            panel1.Margin = new Padding(3, 2, 3, 2);
            panel1.Name = "panel1";
            panel1.Size = new Size(295, 240);
            panel1.TabIndex = 14;
            // 
            // comboBoxDisponibilidad
            // 
            comboBoxDisponibilidad.FormattingEnabled = true;
            comboBoxDisponibilidad.Location = new Point(150, 116);
            comboBoxDisponibilidad.Name = "comboBoxDisponibilidad";
            comboBoxDisponibilidad.Size = new Size(121, 23);
            comboBoxDisponibilidad.TabIndex = 7;
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(106, 165);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(82, 23);
            btnGuardar.TabIndex = 0;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            // 
            // textBoxDescripcion
            // 
            textBoxDescripcion.Location = new Point(150, 47);
            textBoxDescripcion.Name = "textBoxDescripcion";
            textBoxDescripcion.Size = new Size(121, 23);
            textBoxDescripcion.TabIndex = 1;
            // 
            // textBoxCapacidad
            // 
            textBoxCapacidad.Location = new Point(150, 81);
            textBoxCapacidad.Name = "textBoxCapacidad";
            textBoxCapacidad.Size = new Size(121, 23);
            textBoxCapacidad.TabIndex = 2;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(24, 116);
            label4.Name = "label4";
            label4.Size = new Size(83, 15);
            label4.TabIndex = 8;
            label4.Text = "Disponibilidad";
            label4.Click += label4_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(24, 50);
            label1.Name = "label1";
            label1.Size = new Size(69, 15);
            label1.TabIndex = 3;
            label1.Text = "Descripcion";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(24, 83);
            label2.Name = "label2";
            label2.Size = new Size(63, 15);
            label2.TabIndex = 4;
            label2.Text = "Capacidad";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(24, 113);
            label3.Name = "label3";
            label3.Size = new Size(0, 15);
            label3.TabIndex = 6;
            // 
            // lblTituloNuevoEditarAvion
            // 
            lblTituloNuevoEditarAvion.AutoSize = true;
            lblTituloNuevoEditarAvion.Font = new Font("Segoe UI", 16F);
            lblTituloNuevoEditarAvion.Location = new Point(122, 54);
            lblTituloNuevoEditarAvion.Name = "lblTituloNuevoEditarAvion";
            lblTituloNuevoEditarAvion.Size = new Size(127, 30);
            lblTituloNuevoEditarAvion.TabIndex = 13;
            lblTituloNuevoEditarAvion.Text = "Crear Avion";
            // 
            // btnVolver
            // 
            btnVolver.Location = new Point(122, 371);
            btnVolver.Name = "btnVolver";
            btnVolver.Size = new Size(75, 23);
            btnVolver.TabIndex = 12;
            btnVolver.Text = "Volver";
            btnVolver.UseVisualStyleBackColor = true;
            // 
            // AvionCreateForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(649, 450);
            Controls.Add(panel1);
            Controls.Add(lblTituloNuevoEditarAvion);
            Controls.Add(btnVolver);
            Name = "AvionCreateForm";
            Text = "AvionCreateForm";
            Load += AvionCreateForm_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private ComboBox comboBoxDisponibilidad; // Corregido
        private Button btnGuardar;
        private TextBox textBoxDescripcion;     // Corregido
        private TextBox textBoxCapacidad;
        private Label label4;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label lblTituloNuevoEditarAvion;
        private Button btnVolver;
    }
}