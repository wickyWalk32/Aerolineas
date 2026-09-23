using System.Windows.Forms;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace WindowsForms
{
    partial class AvionListForm
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
            dataGridViewAviones = new DataGridView();
            lblTitulo = new Label();
            btnCargar = new Button();
            btnVolver = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridViewAviones).BeginInit();
            SuspendLayout();
            // 
            // dataGridViewAviones
            // 
            dataGridViewAviones.AllowUserToAddRows = false;
            dataGridViewAviones.AllowUserToDeleteRows = false;
            dataGridViewAviones.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewAviones.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewAviones.Location = new Point(30, 80);
            dataGridViewAviones.MultiSelect = false;
            dataGridViewAviones.Name = "dataGridViewAviones";
            dataGridViewAviones.ReadOnly = true;
            dataGridViewAviones.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewAviones.Size = new Size(580, 280);
            dataGridViewAviones.TabIndex = 0;
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new System.Drawing.Font("Segoe UI", 16F);
            lblTitulo.Location = new Point(30, 25);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(203, 30);
            lblTitulo.TabIndex = 1;
            lblTitulo.Text = "Listado de Aviones";
            // 
            // btnCargar
            // 
            btnCargar.Location = new Point(410, 380);
            btnCargar.Name = "btnCargar";
            btnCargar.Size = new Size(95, 30);
            btnCargar.TabIndex = 2;
            btnCargar.Text = "Actualizar";
            btnCargar.UseVisualStyleBackColor = true;
            // 
            // btnVolver
            // 
            btnVolver.Location = new Point(515, 380);
            btnVolver.Name = "btnVolver";
            btnVolver.Size = new Size(95, 30);
            btnVolver.TabIndex = 3;
            btnVolver.Text = "Volver";
            btnVolver.UseVisualStyleBackColor = true;
            // 
            // AvionListForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(640, 435);
            Controls.Add(btnVolver);
            Controls.Add(btnCargar);
            Controls.Add(lblTitulo);
            Controls.Add(dataGridViewAviones);
            Name = "AvionListForm";
            Text = "Listado de Aviones";
            Load += AvionListForm_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridViewAviones).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridViewAviones;
        private Label lblTitulo;
        private Button btnCargar;
        private Button btnVolver;
    }
}