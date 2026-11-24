namespace WindowsForms
{
    partial class AvionCreateForm
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
            panel1 = new Panel();
            comboBoxDisponibilidad = new ComboBox();
            btnGuardar = new Button();
            textBoxDescripcion = new TextBox();
            textBoxCapacidad = new TextBox();
            label4 = new Label();
            label1 = new Label();
            label2 = new Label();
            lblTituloNuevoEditarAvion = new Label();
            btnVolver = new Button();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // lblTituloNuevoEditarAvion
            // 
            lblTituloNuevoEditarAvion.AutoSize = true;
            lblTituloNuevoEditarAvion.Font = new Font("Segoe UI", 16F);
            lblTituloNuevoEditarAvion.Location = new Point(64, 32);
            lblTituloNuevoEditarAvion.Name = "lblTituloNuevoEditarAvion";
            lblTituloNuevoEditarAvion.Size = new Size(165, 37);
            lblTituloNuevoEditarAvion.TabIndex = 0;
            lblTituloNuevoEditarAvion.Text = "Crear Avión";
            // 
            // panel1
            // 
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(textBoxDescripcion);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(textBoxCapacidad);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(comboBoxDisponibilidad);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(btnGuardar);
            panel1.Location = new Point(64, 90);
            panel1.Name = "panel1";
            panel1.Size = new Size(440, 235);
            panel1.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(25, 30);
            label1.Name = "label1";
            label1.Size = new Size(87, 20);
            label1.TabIndex = 0;
            label1.Text = "Descripción";
            // 
            // textBoxDescripcion
            // 
            textBoxDescripcion.Location = new Point(150, 27);
            textBoxDescripcion.Name = "textBoxDescripcion";
            textBoxDescripcion.Size = new Size(255, 27);
            textBoxDescripcion.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(25, 75);
            label2.Name = "label2";
            label2.Size = new Size(76, 20);
            label2.TabIndex = 2;
            label2.Text = "Capacidad";
            // 
            // textBoxCapacidad
            // 
            textBoxCapacidad.Location = new Point(150, 72);
            textBoxCapacidad.Name = "textBoxCapacidad";
            textBoxCapacidad.Size = new Size(255, 27);
            textBoxCapacidad.TabIndex = 3;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(25, 120);
            label4.Name = "label4";
            label4.Size = new Size(109, 20);
            label4.TabIndex = 4;
            label4.Text = "Disponibilidad";
            // 
            // comboBoxDisponibilidad
            // 
            comboBoxDisponibilidad.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxDisponibilidad.FormattingEnabled = true;
            comboBoxDisponibilidad.Location = new Point(150, 117);
            comboBoxDisponibilidad.Name = "comboBoxDisponibilidad";
            comboBoxDisponibilidad.Size = new Size(255, 28);
            comboBoxDisponibilidad.TabIndex = 5;
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(150, 175);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(120, 34);
            btnGuardar.TabIndex = 6;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // btnVolver
            // 
            btnVolver.Location = new Point(64, 355);
            btnVolver.Name = "btnVolver";
            btnVolver.Size = new Size(120, 34);
            btnVolver.TabIndex = 2;
            btnVolver.Text = "Volver";
            btnVolver.UseVisualStyleBackColor = true;
            btnVolver.Click += btnVolver_Click;
            // 
            // AvionCreateForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 600);
            WindowState = FormWindowState.Maximized;
            Controls.Add(btnVolver);
            Controls.Add(panel1);
            Controls.Add(lblTituloNuevoEditarAvion);
            Name = "AvionCreateForm";
            Text = "Administrador - Crear Avión";
            Load += AvionCreateForm_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private ComboBox comboBoxDisponibilidad;
        private Button btnGuardar;
        private TextBox textBoxDescripcion;
        private TextBox textBoxCapacidad;
        private Label label4;
        private Label label1;
        private Label label2;
        private Label lblTituloNuevoEditarAvion;
        private Button btnVolver;
    }
}