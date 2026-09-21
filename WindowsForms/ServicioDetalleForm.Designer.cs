namespace WindowsForms
{
    partial class ServicioDetalleForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblTituloNuevoEditarServicio = new Label();
            panel1 = new Panel();
            textBoxPrecio = new TextBox();
            textBoxNombre = new TextBox();
            label6 = new Label();
            btnGuardar = new Button();
            textBoxDescripcion = new TextBox();
            label5 = new Label();
            label4 = new Label();
            lblIdServicio = new Label();
            lblId = new Label();
            btnVolver = new Button();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // lblTituloNuevoEditarServicio
            // 
            lblTituloNuevoEditarServicio.AutoSize = true;
            lblTituloNuevoEditarServicio.Font = new Font("Segoe UI", 16F);
            lblTituloNuevoEditarServicio.Location = new Point(104, 41);
            lblTituloNuevoEditarServicio.Name = "lblTituloNuevoEditarServicio";
            lblTituloNuevoEditarServicio.Size = new Size(256, 37);
            lblTituloNuevoEditarServicio.TabIndex = 0;
            lblTituloNuevoEditarServicio.Text = "NuevoEditarServicio";
            // 
            // panel1
            // 
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(textBoxPrecio);
            panel1.Controls.Add(textBoxNombre);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(btnGuardar);
            panel1.Controls.Add(textBoxDescripcion);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(lblIdServicio);
            panel1.Controls.Add(lblId);
            panel1.Location = new Point(179, 123);
            panel1.Name = "panel1";
            panel1.Size = new Size(460, 429);
            panel1.TabIndex = 1;
            // 
            // textBoxPrecio
            // 
            textBoxPrecio.Location = new Point(158, 306);
            textBoxPrecio.Name = "textBoxPrecio";
            textBoxPrecio.Size = new Size(280, 27);
            textBoxPrecio.TabIndex = 8;
            // 
            // textBoxNombre
            // 
            textBoxNombre.Location = new Point(158, 84);
            textBoxNombre.Name = "textBoxNombre";
            textBoxNombre.Size = new Size(280, 27);
            textBoxNombre.TabIndex = 6;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(55, 313);
            label6.Name = "label6";
            label6.Size = new Size(50, 20);
            label6.TabIndex = 5;
            label6.Text = "Precio";
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(183, 379);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(94, 29);
            btnGuardar.TabIndex = 0;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // textBoxDescripcion
            // 
            textBoxDescripcion.Location = new Point(158, 135);
            textBoxDescripcion.MaximumSize = new Size(280, 150);
            textBoxDescripcion.MinimumSize = new Size(280, 150);
            textBoxDescripcion.Multiline = true;
            textBoxDescripcion.Name = "textBoxDescripcion";
            textBoxDescripcion.Size = new Size(280, 150);
            textBoxDescripcion.TabIndex = 7;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(55, 135);
            label5.Name = "label5";
            label5.Size = new Size(87, 20);
            label5.TabIndex = 4;
            label5.Text = "Descripción";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(55, 84);
            label4.Name = "label4";
            label4.Size = new Size(64, 20);
            label4.TabIndex = 3;
            label4.Text = "Nombre";
            // 
            // lblIdServicio
            // 
            lblIdServicio.AutoSize = true;
            lblIdServicio.Location = new Point(158, 42);
            lblIdServicio.Name = "lblIdServicio";
            lblIdServicio.Size = new Size(22, 20);
            lblIdServicio.TabIndex = 2;
            lblIdServicio.Text = "id";
            // 
            // lblId
            // 
            lblId.AutoSize = true;
            lblId.Location = new Point(55, 42);
            lblId.Name = "lblId";
            lblId.Size = new Size(22, 20);
            lblId.TabIndex = 1;
            lblId.Text = "Id";
            // 
            // btnVolver
            // 
            btnVolver.Location = new Point(104, 604);
            btnVolver.Name = "btnVolver";
            btnVolver.Size = new Size(94, 29);
            btnVolver.TabIndex = 2;
            btnVolver.Text = "Volver";
            btnVolver.UseVisualStyleBackColor = true;
            btnVolver.Click += btnVolver_Click;
            // 
            // ServicioDetalleForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 677);
            Controls.Add(btnVolver);
            Controls.Add(panel1);
            Controls.Add(lblTituloNuevoEditarServicio);
            Name = "ServicioDetalleForm";
            Text = "Administrador";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTituloNuevoEditarServicio;
        private Panel panel1;
        private Button btnGuardar;
        private Button btnVolver;
        private TextBox textBoxPrecio;
        private TextBox textBoxDescripcion;
        private TextBox textBoxNombre;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label lblIdServicio;
        private Label lblId;
    }
}