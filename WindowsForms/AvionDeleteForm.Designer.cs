
namespace WindowsForms
{
    partial class AvionDeleteForm
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
            lblEstadoValor = new Label();
            lblCapacidadValor = new Label();
            lblDescripcionValor = new Label();
            lblEstado = new Label();
            lblCapacidad = new Label();
            lblDescripcion = new Label();
            btnEliminar = new Button();
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
            panel1.Controls.Add(lblEstadoValor);
            panel1.Controls.Add(lblCapacidadValor);
            panel1.Controls.Add(lblDescripcionValor);
            panel1.Controls.Add(lblEstado);
            panel1.Controls.Add(lblCapacidad);
            panel1.Controls.Add(lblDescripcion);
            panel1.Controls.Add(btnEliminar);
            panel1.Location = new Point(160, 75);
            panel1.Name = "panel1";
            panel1.Size = new Size(360, 250);
            panel1.TabIndex = 0;
            // 
            // btnBuscar
            // 
            btnBuscar.Location = new Point(245, 22);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(85, 25);
            btnBuscar.TabIndex = 0;
            btnBuscar.Text = "Buscar";
            // 
            // numIdBusqueda
            // 
            numIdBusqueda.Location = new Point(140, 23);
            numIdBusqueda.Maximum = new decimal(new int[] { 99999, 0, 0, 0 });
            numIdBusqueda.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numIdBusqueda.Name = "numIdBusqueda";
            numIdBusqueda.Size = new Size(90, 23);
            numIdBusqueda.TabIndex = 1;
            numIdBusqueda.Value = new decimal(new int[] { 1, 0, 0, 0 });
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
            // lblEstadoValor
            // 
            lblEstadoValor.AutoSize = true;
            lblEstadoValor.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblEstadoValor.Location = new Point(140, 145);
            lblEstadoValor.Name = "lblEstadoValor";
            lblEstadoValor.Size = new Size(12, 15);
            lblEstadoValor.TabIndex = 3;
            lblEstadoValor.Text = "-";
            // 
            // lblCapacidadValor
            // 
            lblCapacidadValor.AutoSize = true;
            lblCapacidadValor.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblCapacidadValor.Location = new Point(140, 110);
            lblCapacidadValor.Name = "lblCapacidadValor";
            lblCapacidadValor.Size = new Size(12, 15);
            lblCapacidadValor.TabIndex = 4;
            lblCapacidadValor.Text = "-";
            // 
            // lblDescripcionValor
            // 
            lblDescripcionValor.AutoSize = true;
            lblDescripcionValor.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblDescripcionValor.Location = new Point(140, 75);
            lblDescripcionValor.Name = "lblDescripcionValor";
            lblDescripcionValor.Size = new Size(12, 15);
            lblDescripcionValor.TabIndex = 5;
            lblDescripcionValor.Text = "-";
            // 
            // lblEstado
            // 
            lblEstado.AutoSize = true;
            lblEstado.Location = new Point(20, 145);
            lblEstado.Name = "lblEstado";
            lblEstado.Size = new Size(86, 15);
            lblEstado.TabIndex = 6;
            lblEstado.Text = "Disponibilidad:";
            // 
            // lblCapacidad
            // 
            lblCapacidad.AutoSize = true;
            lblCapacidad.Location = new Point(20, 110);
            lblCapacidad.Name = "lblCapacidad";
            lblCapacidad.Size = new Size(66, 15);
            lblCapacidad.TabIndex = 7;
            lblCapacidad.Text = "Capacidad:";
            // 
            // lblDescripcion
            // 
            lblDescripcion.AutoSize = true;
            lblDescripcion.Location = new Point(20, 75);
            lblDescripcion.Name = "lblDescripcion";
            lblDescripcion.Size = new Size(72, 15);
            lblDescripcion.TabIndex = 8;
            lblDescripcion.Text = "Descripción:";
            // 
            // btnEliminar
            // 
            btnEliminar.Enabled = false;
            btnEliminar.ForeColor = Color.DarkRed;
            btnEliminar.Location = new Point(115, 195);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(130, 32);
            btnEliminar.TabIndex = 9;
            btnEliminar.Text = "Eliminar Avión";
            btnEliminar.UseVisualStyleBackColor = true;
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 16F);
            lblTitulo.Location = new Point(160, 25);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(150, 30);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Eliminar Avión";
            // 
            // btnVolver
            // 
            btnVolver.Location = new Point(160, 345);
            btnVolver.Name = "btnVolver";
            btnVolver.Size = new Size(85, 30);
            btnVolver.TabIndex = 1;
            btnVolver.Text = "Volver";
            // 
            // AvionDeleteForm
            // 
            ClientSize = new Size(680, 400);
            Controls.Add(lblTitulo);
            Controls.Add(panel1);
            Controls.Add(btnVolver);
            Name = "AvionDeleteForm";
            Text = "Eliminar Avión";
            Load += AvionDeleteForm_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numIdBusqueda).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private void AvionDeleteForm_Load(object sender, EventArgs e)
        {
           
        }

        #endregion

        private Panel panel1;
        private Label lblIdBusqueda;
        private NumericUpDown numIdBusqueda;
        private Button btnBuscar;
        private Label lblDescripcion;
        private Label lblDescripcionValor;
        private Label lblCapacidad;
        private Label lblCapacidadValor;
        private Label lblEstado;
        private Label lblEstadoValor;
        private Button btnEliminar;
        private Label lblTitulo;
        private Button btnVolver;
    }
}