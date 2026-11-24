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
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new System.Drawing.Font("Segoe UI", 16F);
            lblTitulo.Location = new Point(64, 32);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(192, 37);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Modificar Avión";
            // 
            // panel1
            // 
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(lblID);
            panel1.Controls.Add(lblIdBusqueda);
            panel1.Controls.Add(textBoxDescripcion);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(textBoxCapacidad);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(comboBoxDisponibilidad);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(btnGuardar);
            panel1.Location = new Point(64, 90);
            panel1.Name = "panel1";
            panel1.Size = new Size(440, 265);
            panel1.TabIndex = 1;
            // 
            // lblIdBusqueda
            // 
            lblIdBusqueda.AutoSize = true;
            lblIdBusqueda.Location = new Point(25, 25);
            lblIdBusqueda.Name = "lblIdBusqueda";
            lblIdBusqueda.Size = new Size(74, 20);
            lblIdBusqueda.TabIndex = 0;
            lblIdBusqueda.Text = "ID Avión:";
            // 
            // lblID
            // 
            lblID.AutoSize = true;
            lblID.Location = new Point(150, 25);
            lblID.Name = "lblID";
            lblID.Size = new Size(24, 20);
            lblID.TabIndex = 1;
            lblID.Text = "ID";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(25, 68);
            label1.Name = "label1";
            label1.Size = new Size(87, 20);
            label1.TabIndex = 2;
            label1.Text = "Descripción:";
            // 
            // textBoxDescripcion
            // 
            textBoxDescripcion.Location = new Point(150, 65);
            textBoxDescripcion.Name = "textBoxDescripcion";
            textBoxDescripcion.Size = new Size(255, 27);
            textBoxDescripcion.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(25, 110);
            label2.Name = "label2";
            label2.Size = new Size(81, 20);
            label2.TabIndex = 4;
            label2.Text = "Capacidad:";
            // 
            // textBoxCapacidad
            // 
            textBoxCapacidad.Location = new Point(150, 107);
            textBoxCapacidad.Name = "textBoxCapacidad";
            textBoxCapacidad.Size = new Size(255, 27);
            textBoxCapacidad.TabIndex = 5;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(25, 152);
            label4.Name = "label4";
            label4.Size = new Size(113, 20);
            label4.TabIndex = 6;
            label4.Text = "Disponibilidad:";
            // 
            // comboBoxDisponibilidad
            // 
            comboBoxDisponibilidad.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxDisponibilidad.FormattingEnabled = true;
            comboBoxDisponibilidad.Items.AddRange(new object[] { "Disponible", "En Mantenimiento", "Inactivo" });
            comboBoxDisponibilidad.Location = new Point(150, 149);
            comboBoxDisponibilidad.Name = "comboBoxDisponibilidad";
            comboBoxDisponibilidad.Size = new Size(255, 28);
            comboBoxDisponibilidad.TabIndex = 7;
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(150, 205);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(140, 34);
            btnGuardar.TabIndex = 8;
            btnGuardar.Text = "Guardar Cambios";
            btnGuardar.UseVisualStyleBackColor = true;
            // 
            // btnVolver
            // 
            btnVolver.Location = new Point(64, 385);
            btnVolver.Name = "btnVolver";
            btnVolver.Size = new Size(120, 34);
            btnVolver.TabIndex = 2;
            btnVolver.Text = "Volver";
            btnVolver.UseVisualStyleBackColor = true;
            // 
            // AvionUpdateForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 600);
            WindowState = FormWindowState.Maximized;
            Controls.Add(lblTitulo);
            Controls.Add(panel1);
            Controls.Add(btnVolver);
            Name = "AvionUpdateForm";
            Text = "Administrador - Modificar Avión";
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
        private Label lblID;
    }
}