namespace WindowsForms
{
    partial class ServicioItemControl
    {
        /// <summary> 
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            lblId = new Label();
            lblNombre = new Label();
            lblPrecio = new Label();
            lblDescripcion = new Label();
            btnEditarServicio = new Button();
            btnEliminarServicio = new Button();
            label1 = new Label();
            SuspendLayout();
            // 
            // lblId
            // 
            lblId.AutoSize = true;
            lblId.Location = new Point(25, 15);
            lblId.Name = "lblId";
            lblId.Size = new Size(22, 20);
            lblId.TabIndex = 0;
            lblId.Text = "Id";
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Location = new Point(103, 15);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(64, 20);
            lblNombre.TabIndex = 1;
            lblNombre.Text = "Nombre";
            // 
            // lblPrecio
            // 
            lblPrecio.AutoSize = true;
            lblPrecio.Location = new Point(502, 15);
            lblPrecio.Name = "lblPrecio";
            lblPrecio.Size = new Size(50, 20);
            lblPrecio.TabIndex = 2;
            lblPrecio.Text = "Precio";
            // 
            // lblDescripcion
            // 
            lblDescripcion.AutoSize = true;
            lblDescripcion.Location = new Point(140, 69);
            lblDescripcion.Name = "lblDescripcion";
            lblDescripcion.Size = new Size(164, 20);
            lblDescripcion.TabIndex = 3;
            lblDescripcion.Text = "descripción del servicio";
            // 
            // btnEditarServicio
            // 
            btnEditarServicio.Location = new Point(851, 11);
            btnEditarServicio.Name = "btnEditarServicio";
            btnEditarServicio.Size = new Size(90, 29);
            btnEditarServicio.TabIndex = 4;
            btnEditarServicio.Text = "Editar";
            btnEditarServicio.UseVisualStyleBackColor = true;
            btnEditarServicio.Click += btnEditarServicio_Click;
            // 
            // btnEliminarServicio
            // 
            btnEliminarServicio.Location = new Point(947, 11);
            btnEliminarServicio.Name = "btnEliminarServicio";
            btnEliminarServicio.Size = new Size(90, 29);
            btnEliminarServicio.TabIndex = 5;
            btnEliminarServicio.Text = "Eliminar";
            btnEliminarServicio.UseVisualStyleBackColor = true;
            btnEliminarServicio.Click += btnEliminarServicio_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(44, 69);
            label1.Name = "label1";
            label1.Size = new Size(90, 20);
            label1.TabIndex = 6;
            label1.Text = "Descripción:";
            // 
            // ServicioItemControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BorderStyle = BorderStyle.FixedSingle;
            Controls.Add(label1);
            Controls.Add(btnEliminarServicio);
            Controls.Add(btnEditarServicio);
            Controls.Add(lblDescripcion);
            Controls.Add(lblPrecio);
            Controls.Add(lblNombre);
            Controls.Add(lblId);
            Name = "ServicioItemControl";
            Size = new Size(1070, 148);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblId;
        private Label lblNombre;
        private Label lblPrecio;
        private Label lblDescripcion;
        private Button btnEditarServicio;
        private Button btnEliminarServicio;
        private Label label1;
    }
}
