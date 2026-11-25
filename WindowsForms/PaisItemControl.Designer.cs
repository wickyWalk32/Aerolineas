namespace WindowsForms
{
    partial class PaisItemControl
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

        #region Código generado por el Diseñador de componentes

        private void InitializeComponent()
        {
            lblId = new Label();
            lblNombre = new Label();
            btnEditarPais = new Button();
            btnEliminarPais = new Button();
            SuspendLayout();
            // 
            // lblId
            // 
            lblId.AutoSize = true;
            lblId.Location = new Point(25, 18);
            lblId.Name = "lblId";
            lblId.Size = new Size(22, 20);
            lblId.TabIndex = 0;
            lblId.Text = "Id";
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblNombre.Location = new Point(95, 17);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(80, 23);
            lblNombre.TabIndex = 1;
            lblNombre.Text = "Nombre";
            // 
            // btnEditarPais
            // 
            btnEditarPais.Location = new Point(851, 12);
            btnEditarPais.Name = "btnEditarPais";
            btnEditarPais.Size = new Size(90, 29);
            btnEditarPais.TabIndex = 2;
            btnEditarPais.Text = "Editar";
            btnEditarPais.UseVisualStyleBackColor = true;
            btnEditarPais.Click += btnEditarPais_Click;
            // 
            // btnEliminarPais
            // 
            btnEliminarPais.Location = new Point(947, 12);
            btnEliminarPais.Name = "btnEliminarPais";
            btnEliminarPais.Size = new Size(90, 29);
            btnEliminarPais.TabIndex = 3;
            btnEliminarPais.Text = "Eliminar";
            btnEliminarPais.UseVisualStyleBackColor = true;
            btnEliminarPais.Click += btnEliminarPais_Click;
            // 
            // PaisItemControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BorderStyle = BorderStyle.FixedSingle;
            Controls.Add(btnEliminarPais);
            Controls.Add(btnEditarPais);
            Controls.Add(lblNombre);
            Controls.Add(lblId);
            Name = "PaisItemControl";
            Size = new Size(1070, 56);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblId;
        private Label lblNombre;
        private Button btnEditarPais;
        private Button btnEliminarPais;
    }
}

