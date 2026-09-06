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
            lblNombreApellido.Location = new Point(96, 14);
            lblNombreApellido.Name = "lblNombreApellido";
            lblNombreApellido.Size = new Size(131, 20);
            lblNombreApellido.TabIndex = 0;
            lblNombreApellido.Text = "nombre y apellido";
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Location = new Point(261, 14);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(46, 20);
            lblEmail.TabIndex = 1;
            lblEmail.Text = "email";
            // 
            // btnEditarUsuario
            // 
            btnEditarUsuario.Location = new Point(538, 10);
            btnEditarUsuario.Name = "btnEditarUsuario";
            btnEditarUsuario.Size = new Size(74, 29);
            btnEditarUsuario.TabIndex = 2;
            btnEditarUsuario.Text = "Editar";
            btnEditarUsuario.UseVisualStyleBackColor = true;
            btnEditarUsuario.Click += btnEditar_Click;
            // 
            // btnEliminarUsuario
            // 
            btnEliminarUsuario.Location = new Point(618, 10);
            btnEliminarUsuario.Name = "btnEliminarUsuario";
            btnEliminarUsuario.Size = new Size(71, 29);
            btnEliminarUsuario.TabIndex = 3;
            btnEliminarUsuario.Text = "Eliminar";
            btnEliminarUsuario.UseVisualStyleBackColor = true;
            btnEliminarUsuario.Click += btnEliminar_Click;
            // 
            // lblRol
            // 
            lblRol.AutoSize = true;
            lblRol.Location = new Point(382, 14);
            lblRol.Name = "lblRol";
            lblRol.Size = new Size(27, 20);
            lblRol.TabIndex = 4;
            lblRol.Text = "rol";
            // 
            // lblIdUsuario
            // 
            lblIdUsuario.AutoSize = true;
            lblIdUsuario.Location = new Point(33, 14);
            lblIdUsuario.Name = "lblIdUsuario";
            lblIdUsuario.Size = new Size(22, 20);
            lblIdUsuario.TabIndex = 5;
            lblIdUsuario.Text = "id";
            lblIdUsuario.Click += lblIdUsuario_Click;
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
            Size = new Size(723, 48);
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
