namespace WindowsForms
{
    partial class PaisDetalleForm
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
            lblTituloNuevoEditarPais = new Label();
            panel1 = new Panel();
            textBoxNombre = new TextBox();
            btnGuardar = new Button();
            labelNombre = new Label();
            lblIdPais = new Label();
            lblId = new Label();
            btnVolver = new Button();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // lblTituloNuevoEditarPais
            // 
            lblTituloNuevoEditarPais.AutoSize = true;
            lblTituloNuevoEditarPais.Font = new Font("Segoe UI", 16F);
            lblTituloNuevoEditarPais.Location = new Point(104, 41);
            lblTituloNuevoEditarPais.Name = "lblTituloNuevoEditarPais";
            lblTituloNuevoEditarPais.Size = new Size(256, 37);
            lblTituloNuevoEditarPais.TabIndex = 0;
            lblTituloNuevoEditarPais.Text = "NuevoEditarPais";
            // 
            // panel1
            // 
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(textBoxNombre);
            panel1.Controls.Add(btnGuardar);
            panel1.Controls.Add(labelNombre);
            panel1.Controls.Add(lblIdPais);
            panel1.Controls.Add(lblId);
            panel1.Location = new Point(179, 123);
            panel1.Name = "panel1";
            panel1.Size = new Size(460, 240);
            panel1.TabIndex = 1;
            // 
            // lblId
            // 
            lblId.AutoSize = true;
            lblId.Location = new Point(55, 35);
            lblId.Name = "lblId";
            lblId.Size = new Size(22, 20);
            lblId.TabIndex = 0;
            lblId.Text = "Id";
            // 
            // lblIdPais
            // 
            lblIdPais.AutoSize = true;
            lblIdPais.Location = new Point(150, 35);
            lblIdPais.Name = "lblIdPais";
            lblIdPais.Size = new Size(22, 20);
            lblIdPais.TabIndex = 1;
            lblIdPais.Text = "id";
            // 
            // labelNombre
            // 
            labelNombre.AutoSize = true;
            labelNombre.Location = new Point(55, 85);
            labelNombre.Name = "labelNombre";
            labelNombre.Size = new Size(64, 20);
            labelNombre.TabIndex = 2;
            labelNombre.Text = "Nombre";
            // 
            // textBoxNombre
            // 
            textBoxNombre.Location = new Point(150, 82);
            textBoxNombre.Name = "textBoxNombre";
            textBoxNombre.Size = new Size(270, 27);
            textBoxNombre.TabIndex = 3;
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(180, 165);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(100, 32);
            btnGuardar.TabIndex = 4;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // btnVolver
            // 
            btnVolver.Location = new Point(104, 405);
            btnVolver.Name = "btnVolver";
            btnVolver.Size = new Size(100, 32);
            btnVolver.TabIndex = 2;
            btnVolver.Text = "Volver";
            btnVolver.UseVisualStyleBackColor = true;
            btnVolver.Click += btnVolver_Click;
            // 
            // PaisDetalleForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 520);
            WindowState = FormWindowState.Maximized;
            Controls.Add(btnVolver);
            Controls.Add(panel1);
            Controls.Add(lblTituloNuevoEditarPais);
            Name = "PaisDetalleForm";
            Text = "Administrador - País";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTituloNuevoEditarPais;
        private Panel panel1;
        private Button btnGuardar;
        private Button btnVolver;
        private TextBox textBoxNombre;
        private Label labelNombre;
        private Label lblIdPais;
        private Label lblId;
    }
}