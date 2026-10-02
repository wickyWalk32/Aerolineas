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
            btnVolver = new Button();
            btnCargar = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridViewAviones).BeginInit();
            SuspendLayout();
            // 
            // dataGridViewAviones
            // 
            dataGridViewAviones.AllowUserToAddRows = false;
            dataGridViewAviones.AllowUserToDeleteRows = false;
            dataGridViewAviones.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewAviones.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewAviones.Location = new Point(34, 107);
            dataGridViewAviones.Margin = new Padding(3, 4, 3, 4);
            dataGridViewAviones.MultiSelect = false;
            dataGridViewAviones.Name = "dataGridViewAviones";
            dataGridViewAviones.ReadOnly = true;
            dataGridViewAviones.RowHeadersWidth = 51;
            dataGridViewAviones.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewAviones.Size = new Size(663, 398);
            dataGridViewAviones.TabIndex = 0;
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new System.Drawing.Font("Segoe UI", 16F);
            lblTitulo.Location = new Point(34, 33);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(239, 37);
            lblTitulo.TabIndex = 1;
            lblTitulo.Text = "Listado de Aviones";
            // 
            // btnVolver
            // 
            btnVolver.Location = new Point(34, 542);
            btnVolver.Margin = new Padding(3, 4, 3, 4);
            btnVolver.Name = "btnVolver";
            btnVolver.Size = new Size(96, 31);
            btnVolver.TabIndex = 3;
            btnVolver.Text = "Volver";
            btnVolver.UseVisualStyleBackColor = true;
            // 
            // btnCargar
            // 
            btnCargar.Location = new Point(603, 544);
            btnCargar.Name = "btnCargar";
            btnCargar.Size = new Size(94, 29);
            btnCargar.TabIndex = 4;
            btnCargar.Text = "Refrescar";
            btnCargar.UseVisualStyleBackColor = true;
            // 
            // AvionListForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(731, 610);
            Controls.Add(btnCargar);
            Controls.Add(btnVolver);
            Controls.Add(lblTitulo);
            Controls.Add(dataGridViewAviones);
            Margin = new Padding(3, 4, 3, 4);
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
        private Button btnVolver;
        private Button btnCargar;
    }
}