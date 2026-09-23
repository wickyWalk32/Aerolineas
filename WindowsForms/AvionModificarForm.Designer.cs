using System.Windows.Forms;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace WindowsForms
{
    partial class AvionUpdateForm
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
            btnBuscar = new Button();
            numIdBusqueda = new NumericUpDown();
            lblIdBusqueda = new Label();
            comboBoxDisponibilidad = new ComboBox();
            btnGuardar = new Button();
            textBoxDescripcion = new TextBox();
            textBoxCapacidad = new TextBox();
            label4 = new Label();
            label1 = new Label();
            label2 = new Label();
            lblTitulo = new Label();
            btnVolver = new Button();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numIdBusqueda).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(btnBuscar);
            panel1.Controls.Add(numIdBusqueda);
            panel1.Controls.Add(lblIdBusqueda);
            panel1.Controls.Add(comboBoxDisponibilidad);
            panel1.Controls.Add(btnGuardar);
            panel1.Controls.Add(textBoxDescripcion);
            panel1.Controls.Add(textBoxCapacidad);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(label2);
            panel1.Location = new Point(175, 80);
            panel1.Name = "panel1";
            panel1.Size = new Size(350, 260);
            panel1.TabIndex = 0;
            // 
            // lblIdBusqueda
            // 
            lblIdBusqueda.AutoSize = true;
            lblIdBusqueda.Location = new Point(20, 25);
            lblIdBusqueda.Name = "lblIdBusqueda";
            lblIdBusqueda.Size = new Size(55, 15);
            lblIdBusqueda.Text = "ID Avión:";
            // 
            // numIdBusqueda
            // 
            numIdBusqueda.Location = new Point(150, 23);
            numIdBusqueda.Maximum = new decimal(new int[] { 99999, 0, 0, 0 });
            numIdBusqueda.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numIdBusqueda.Name = "numIdBusqueda";
            numIdBusqueda.Size = new Size(80, 23);
            numIdBusqueda.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // btnBuscar
            // 
            btnBuscar.Location = new Point(240, 22);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(80, 25);
            btnBuscar.Text = "Buscar";
            // 
            // textBoxDescripcion
            // 
            textBoxDescripcion.Location = new Point(150, 70);
            textBoxDescripcion.Name = "textBoxDescripcion";
            textBoxDescripcion.Size = new Size(170, 23);
            // 
            // textBoxCapacidad
            // 
            textBoxCapacidad.Location = new Point(150, 110);
            textBoxCapacidad.Name = "textBoxCapacidad";
            textBoxCapacidad.Size = new Size(170, 23);
            // 
            // comboBoxDisponibilidad
            // 
            comboBoxDisponibilidad.FormattingEnabled = true;
            comboBoxDisponibilidad.Location = new Point(150, 150);
            comboBoxDisponibilidad.Name = "comboBoxDisponibilidad";
            comboBoxDisponibilidad.Size = new Size(170, 23);
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(20, 73);
            label1.Text = "Descripción:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(20, 113);
            label2.Text = "Capacidad:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(20, 153);
            label4.Text = "Disponibilidad:";
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(130, 205);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(100, 30);
            btnGuardar.Text = "Guardar Cambios";
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new System.Drawing.Font("Segoe UI", 16F);
            lblTitulo.Location = new Point(175, 30);
            lblTitulo.Text = "Modificar Avión";
            // 
            // btnVolver
            // 
            btnVolver.Location = new Point(175, 360);
            btnVolver.Name = "btnVolver";
            btnVolver.Size = new Size(80, 30);
            btnVolver.Text = "Volver";
            // 
            // AvionUpdateForm
            // 
            ClientSize = new Size(700, 420);
            Controls.Add(lblTitulo);
            Controls.Add(panel1);
            Controls.Add(btnVolver);
            Name = "AvionUpdateForm";
            Text = "Modificar Avión";
            Load += AvionUpdateForm_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numIdBusqueda).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Label lblIdBusqueda;
        private NumericUpDown numIdBusqueda;
        private Button btnBuscar;
        private TextBox textBoxDescripcion;
        private TextBox textBoxCapacidad;
        private ComboBox comboBoxDisponibilidad;
        private Label label1;
        private Label label2;
        private Label label4;
        private Button btnGuardar;
        private Label lblTitulo;
        private Button btnVolver;
    }
}