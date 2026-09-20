namespace WindowsForms
{
    partial class UsuarioItemControl
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
            lblNombreApellido = new Label();
            lblEmail = new Label();
            btnEditarUsuario = new Button();
            btnEliminarUsuario = new Button();
            lblRol = new Label();
            lblIdUsuario = new Label();
            SuspendLayout();
            // 
            // lblNombreApellido
            // 
            lblNombreApellido.AutoSize = true;
            lblNombreApellido.Location = new Point(111, 15);
            lblNombreApellido.Name = "lblNombreApellido";
            lblNombreApellido.Size = new Size(136, 20);
            lblNombreApellido.TabIndex = 0;
            lblNombreApellido.Text = "Nombre y Apellido";
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Location = new Point(458, 15);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(46, 20);
            lblEmail.TabIndex = 1;
            lblEmail.Text = "Email";
            // 
            // btnEditarUsuario
            // 
            btnEditarUsuario.Location = new Point(868, 11);
            btnEditarUsuario.Name = "btnEditarUsuario";
            btnEditarUsuario.Size = new Size(90, 29);
            btnEditarUsuario.TabIndex = 2;
            btnEditarUsuario.Text = "Editar";
            btnEditarUsuario.UseVisualStyleBackColor = true;
            btnEditarUsuario.Click += btnEditar_Click;
            // 
            // btnEliminarUsuario
            // 
            btnEliminarUsuario.Location = new Point(965, 11);
            btnEliminarUsuario.Name = "btnEliminarUsuario";
            btnEliminarUsuario.Size = new Size(90, 29);
            btnEliminarUsuario.TabIndex = 3;
            btnEliminarUsuario.Text = "Eliminar";
            btnEliminarUsuario.UseVisualStyleBackColor = true;
            btnEliminarUsuario.Click += btnEliminar_Click;
            // 
            // lblRol
            // 
            lblRol.AutoSize = true;
            lblRol.Location = new Point(750, 15);
            lblRol.Name = "lblRol";
            lblRol.Size = new Size(31, 20);
            lblRol.TabIndex = 4;
            lblRol.Text = "Rol";
            // 
            // lblIdUsuario
            // 
            lblIdUsuario.AutoSize = true;
            lblIdUsuario.Location = new Point(25, 15);
            lblIdUsuario.Name = "lblIdUsuario";
            lblIdUsuario.Size = new Size(22, 20);
            lblIdUsuario.TabIndex = 5;
            lblIdUsuario.Text = "Id";
            // 
            // UsuarioItemControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BorderStyle = BorderStyle.FixedSingle;
            Controls.Add(lblIdUsuario);
            Controls.Add(lblRol);
            Controls.Add(btnEliminarUsuario);
            Controls.Add(btnEditarUsuario);
            Controls.Add(lblEmail);
            Controls.Add(lblNombreApellido);
            Name = "UsuarioItemControl";
            Size = new Size(1085, 50);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblNombreApellido;
        private Label lblEmail;
        private Button btnEditarUsuario;
        private Button btnEliminarUsuario;
        private Label lblRol;
        private Label lblIdUsuario;
    }
}
