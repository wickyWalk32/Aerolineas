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
            lblID = new Label();
            comboBoxFilas = new ComboBox();
            labelFilas = new Label();
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
            avionControl = new AvionControl();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(lblID);
            panel1.Controls.Add(comboBoxFilas);
            panel1.Controls.Add(labelFilas);
            panel1.Controls.Add(lblIdBusqueda);
            panel1.Controls.Add(comboBoxDisponibilidad);
            panel1.Controls.Add(btnGuardar);
            panel1.Controls.Add(textBoxDescripcion);
            panel1.Controls.Add(textBoxCapacidad);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(label2);
            panel1.Location = new Point(12, 61);
            panel1.Name = "panel1";
            panel1.Size = new Size(413, 260);
            panel1.TabIndex = 0;
            // 
            // lblID
            // 
            lblID.AutoSize = true;
            lblID.Location = new Point(150, 26);
            lblID.Name = "lblID";
            lblID.Size = new Size(18, 15);
            lblID.TabIndex = 12;
            lblID.Text = "ID";
            // 
            // comboBoxFilas
            // 
            comboBoxFilas.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxFilas.FormattingEnabled = true;
            comboBoxFilas.Items.AddRange(new object[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12" });
            comboBoxFilas.Location = new Point(150, 191);
            comboBoxFilas.Name = "comboBoxFilas";
            comboBoxFilas.Size = new Size(221, 23);
            comboBoxFilas.TabIndex = 10;
            comboBoxFilas.SelectedIndexChanged += comboBoxFilas_SelectedIndexChanged;
            // 
            // labelFilas
            // 
            labelFilas.AutoSize = true;
            labelFilas.Location = new Point(20, 194);
            labelFilas.Name = "labelFilas";
            labelFilas.Size = new Size(30, 15);
            labelFilas.TabIndex = 11;
            labelFilas.Text = "Filas";
            // 
            // lblIdBusqueda
            // 
            lblIdBusqueda.AutoSize = true;
            lblIdBusqueda.Location = new Point(20, 25);
            lblIdBusqueda.Name = "lblIdBusqueda";
            lblIdBusqueda.Size = new Size(55, 15);
            lblIdBusqueda.TabIndex = 2;
            lblIdBusqueda.Text = "ID Avión:";
            // 
            // comboBoxDisponibilidad
            // 
            comboBoxDisponibilidad.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxDisponibilidad.FormattingEnabled = true;
            comboBoxDisponibilidad.Items.AddRange(new object[] { "Disponible", "En Mantenimiento", "Inactivo" });
            comboBoxDisponibilidad.Location = new Point(150, 150);
            comboBoxDisponibilidad.Name = "comboBoxDisponibilidad";
            comboBoxDisponibilidad.Size = new Size(221, 23);
            comboBoxDisponibilidad.TabIndex = 3;
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(156, 225);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(100, 30);
            btnGuardar.TabIndex = 4;
            btnGuardar.Text = "Guardar Cambios";
            // 
            // textBoxDescripcion
            // 
            textBoxDescripcion.Location = new Point(150, 70);
            textBoxDescripcion.Name = "textBoxDescripcion";
            textBoxDescripcion.Size = new Size(221, 23);
            textBoxDescripcion.TabIndex = 5;
            // 
            // textBoxCapacidad
            // 
            textBoxCapacidad.Location = new Point(150, 110);
            textBoxCapacidad.Name = "textBoxCapacidad";
            textBoxCapacidad.ReadOnly = true;
            textBoxCapacidad.Size = new Size(221, 23);
            textBoxCapacidad.TabIndex = 6;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(20, 153);
            label4.Name = "label4";
            label4.Size = new Size(86, 15);
            label4.TabIndex = 7;
            label4.Text = "Disponibilidad:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(20, 73);
            label1.Name = "label1";
            label1.Size = new Size(72, 15);
            label1.TabIndex = 8;
            label1.Text = "Descripción:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(20, 113);
            label2.Name = "label2";
            label2.Size = new Size(66, 15);
            label2.TabIndex = 9;
            label2.Text = "Capacidad:";
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new System.Drawing.Font("Segoe UI", 16F);
            lblTitulo.Location = new Point(103, 28);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(166, 30);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Modificar Avión";
            // 
            // btnVolver
            // 
            btnVolver.Location = new Point(103, 416);
            btnVolver.Name = "btnVolver";
            btnVolver.Size = new Size(80, 30);
            btnVolver.TabIndex = 1;
            btnVolver.Text = "Volver";
            // 
            // avionControl
            // 
            avionControl.Location = new Point(440, 40);
            avionControl.Name = "avionControl";
            avionControl.Size = new Size(254, 640);
            avionControl.TabIndex = 12;
            // 
            // AvionUpdateForm
            // 
            ClientSize = new Size(711, 749);
            Controls.Add(avionControl);
            Controls.Add(lblTitulo);
            Controls.Add(panel1);
            Controls.Add(btnVolver);
            Name = "AvionUpdateForm";
            Load += AvionUpdateForm_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Label lblIdBusqueda;
        private TextBox textBoxDescripcion;
        private TextBox textBoxCapacidad;
        private ComboBox comboBoxDisponibilidad;
        private Label label1;
        private Label label2;
        private Label label4;
        private Button btnGuardar;
        private Label lblTitulo;
        private Button btnVolver;
        private ComboBox comboBoxFilas;
        private Label labelFilas;
        private AvionControl avionControl;
        private Label lblID;
    }
}