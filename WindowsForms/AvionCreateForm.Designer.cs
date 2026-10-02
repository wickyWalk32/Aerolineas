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
            panel1.Location = new Point(200, 116);
            panel1.Name = "panel1";
            panel1.Size = new Size(399, 319);
            panel1.TabIndex = 14;
            // 
            // comboBoxDisponibilidad
            // 
            comboBoxDisponibilidad.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxDisponibilidad.FormattingEnabled = true;
            comboBoxDisponibilidad.Location = new Point(139, 159);
            comboBoxDisponibilidad.Margin = new Padding(3, 4, 3, 4);
            comboBoxDisponibilidad.Name = "comboBoxDisponibilidad";
            comboBoxDisponibilidad.Size = new Size(218, 28);
            comboBoxDisponibilidad.TabIndex = 7;
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(149, 240);
            btnGuardar.Margin = new Padding(3, 4, 3, 4);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(94, 31);
            btnGuardar.TabIndex = 0;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            // 
            // textBoxDescripcion
            // 
            textBoxDescripcion.Location = new Point(139, 67);
            textBoxDescripcion.Margin = new Padding(3, 4, 3, 4);
            textBoxDescripcion.Name = "textBoxDescripcion";
            textBoxDescripcion.Size = new Size(218, 27);
            textBoxDescripcion.TabIndex = 1;
            // 
            // textBoxCapacidad
            // 
            textBoxCapacidad.Location = new Point(139, 112);
            textBoxCapacidad.Margin = new Padding(3, 4, 3, 4);
            textBoxCapacidad.Name = "textBoxCapacidad";
            textBoxCapacidad.Size = new Size(218, 27);
            textBoxCapacidad.TabIndex = 2;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(26, 159);
            label4.Name = "label4";
            label4.Size = new Size(107, 20);
            label4.TabIndex = 8;
            label4.Text = "Disponibilidad";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(26, 71);
            label1.Name = "label1";
            label1.Size = new Size(87, 20);
            label1.TabIndex = 3;
            label1.Text = "Descripción";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(26, 115);
            label2.Name = "label2";
            label2.Size = new Size(80, 20);
            label2.TabIndex = 4;
            label2.Text = "Capacidad";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(26, 155);
            label3.Name = "label3";
            label3.Size = new Size(0, 20);
            label3.TabIndex = 6;
            // 
            // lblTituloNuevoEditarAvion
            // 
            lblTituloNuevoEditarAvion.AutoSize = true;
            lblTituloNuevoEditarAvion.Font = new Font("Segoe UI", 16F);
            lblTituloNuevoEditarAvion.Location = new Point(139, 43);
            lblTituloNuevoEditarAvion.Name = "lblTituloNuevoEditarAvion";
            lblTituloNuevoEditarAvion.Size = new Size(154, 37);
            lblTituloNuevoEditarAvion.TabIndex = 13;
            lblTituloNuevoEditarAvion.Text = "Crear Avion";
            // 
            // btnVolver
            // 
            btnVolver.Location = new Point(139, 478);
            btnVolver.Margin = new Padding(3, 4, 3, 4);
            btnVolver.Name = "btnVolver";
            btnVolver.Size = new Size(86, 31);
            btnVolver.TabIndex = 12;
            btnVolver.Text = "Volver";
            btnVolver.UseVisualStyleBackColor = true;
            // 
            // AvionCreateForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(742, 543);
            Controls.Add(panel1);
            Controls.Add(lblTituloNuevoEditarAvion);
            Controls.Add(btnVolver);
            Margin = new Padding(3, 4, 3, 4);
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