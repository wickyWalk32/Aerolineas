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
            lblNombreApellido.Location = new Point(84, 10);
            lblNombreApellido.Name = "lblNombreApellido";
            lblNombreApellido.Size = new Size(103, 15);
            lblNombreApellido.TabIndex = 0;
            lblNombreApellido.Text = "nombre y apellido";
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Location = new Point(228, 10);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(36, 15);
            lblEmail.TabIndex = 1;
            lblEmail.Text = "email";
            // 
            // btnEditarUsuario
            // 
            btnEditarUsuario.Location = new Point(471, 8);
            btnEditarUsuario.Margin = new Padding(3, 2, 3, 2);
            btnEditarUsuario.Name = "btnEditarUsuario";
            btnEditarUsuario.Size = new Size(65, 22);
            btnEditarUsuario.TabIndex = 2;
            btnEditarUsuario.Text = "Editar";
            btnEditarUsuario.UseVisualStyleBackColor = true;
            btnEditarUsuario.Click += btnEditar_Click;
            // 
            // btnEliminarUsuario
            // 
            btnEliminarUsuario.Location = new Point(541, 8);
            btnEliminarUsuario.Margin = new Padding(3, 2, 3, 2);
            btnEliminarUsuario.Name = "btnEliminarUsuario";
            btnEliminarUsuario.Size = new Size(62, 22);
            btnEliminarUsuario.TabIndex = 3;
            btnEliminarUsuario.Text = "Eliminar";
            btnEliminarUsuario.UseVisualStyleBackColor = true;
            btnEliminarUsuario.Click += btnEliminar_Click;
            // 
            // lblRol
            // 
            lblRol.AutoSize = true;
            lblRol.Location = new Point(334, 10);
            lblRol.Name = "lblRol";
            lblRol.Size = new Size(21, 15);
            lblRol.TabIndex = 4;
            lblRol.Text = "rol";
            // 
            // lblIdUsuario
            // 
            lblIdUsuario.AutoSize = true;
            lblIdUsuario.Location = new Point(29, 10);
            lblIdUsuario.Name = "lblIdUsuario";
            lblIdUsuario.Size = new Size(17, 15);
            lblIdUsuario.TabIndex = 5;
            lblIdUsuario.Text = "id";
            lblIdUsuario.Click += lblIdUsuario_Click;
            // 
            // UsuarioItemControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BorderStyle = BorderStyle.FixedSingle;
            Controls.Add(lblIdUsuario);
            Controls.Add(lblRol);
            Controls.Add(btnEliminarUsuario);
            Controls.Add(btnEditarUsuario);
            Controls.Add(lblEmail);
            Controls.Add(lblNombreApellido);
            Margin = new Padding(3, 2, 3, 2);
            Name = "UsuarioItemControl";
            Size = new Size(633, 36);
            Load += UsuarioItemControl_Load;
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
