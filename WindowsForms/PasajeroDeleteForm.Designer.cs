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
            components = new System.ComponentModel.Container();
            lblInstruccion = new Label();
            nudId = new NumericUpDown();
            btnEliminar = new Button();
            btnCancelar = new Button();

            SuspendLayout();
            // 
            // lblInstruccion
            // 
            lblInstruccion.AutoSize = true;
            lblInstruccion.Location = new System.Drawing.Point(16, 18);
            lblInstruccion.Name = "lblInstruccion";
            lblInstruccion.Size = new System.Drawing.Size(250, 20);
            lblInstruccion.Text = "Ingrese el Id del pasajero a eliminar:";
            // 
            // nudId
            // 
            nudId.Location = new System.Drawing.Point(20, 50);
            nudId.Minimum = 1;
            nudId.Maximum = int.MaxValue;
            nudId.Name = "nudId";
            nudId.Size = new System.Drawing.Size(200, 27);
            nudId.TabIndex = 0;
            // 
            // btnEliminar
            // 
            btnEliminar.Location = new System.Drawing.Point(20, 95);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new System.Drawing.Size(100, 30);
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += BtnEliminar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new System.Drawing.Point(130, 95);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new System.Drawing.Size(90, 30);
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += BtnCancelar_Click;
            // 
            // PasajeroDeleteForm
            // 
            ClientSize = new System.Drawing.Size(260, 140);
            Controls.Add(lblInstruccion);
            Controls.Add(nudId);
            Controls.Add(btnEliminar);
            Controls.Add(btnCancelar);
            Name = "PasajeroDeleteForm";
            Text = "Eliminar Pasajero";
            StartPosition = FormStartPosition.CenterParent;
            AcceptButton = btnEliminar;
            CancelButton = btnCancelar;
            ResumeLayout(false);
            PerformLayout();
        }
    }
}