using System.Windows.Forms;

namespace WindowsForms
{
    partial class PasajeroDeleteForm
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblInstruccion;
        private NumericUpDown nudId;
        private Button btnEliminar;
        private Button btnCancelar;

        private void InitializeComponent()
        {
            lblInstruccion = new Label();
            nudId = new NumericUpDown();
            btnEliminar = new Button();
            btnCancelar = new Button();
            ((System.ComponentModel.ISupportInitialize)nudId).BeginInit();
            SuspendLayout();
            // 
            // lblInstruccion
            // 
            lblInstruccion.AutoSize = true;
            lblInstruccion.Location = new Point(39, 24);
            lblInstruccion.Name = "lblInstruccion";
            lblInstruccion.Size = new Size(249, 20);
            lblInstruccion.TabIndex = 0;
            lblInstruccion.Text = "Ingrese el Id del pasajero a eliminar:";
            // 
            // nudId
            // 
            nudId.Location = new Point(43, 56);
            nudId.Maximum = new decimal(new int[] { int.MaxValue, 0, 0, 0 });
            nudId.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudId.Name = "nudId";
            nudId.Size = new Size(245, 27);
            nudId.TabIndex = 0;
            nudId.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // btnEliminar
            // 
            btnEliminar.Location = new Point(188, 104);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(100, 30);
            btnEliminar.TabIndex = 1;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += BtnEliminar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(39, 104);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(94, 30);
            btnCancelar.TabIndex = 2;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += BtnCancelar_Click;
            // 
            // PasajeroDeleteForm
            // 
            AcceptButton = btnEliminar;
            CancelButton = btnCancelar;
            ClientSize = new Size(318, 167);
            Controls.Add(lblInstruccion);
            Controls.Add(nudId);
            Controls.Add(btnEliminar);
            Controls.Add(btnCancelar);
            Name = "PasajeroDeleteForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Eliminar Pasajero";
            ((System.ComponentModel.ISupportInitialize)nudId).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}