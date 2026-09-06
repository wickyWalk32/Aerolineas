namespace WindowsForms
{
    partial class AdminUsuariosForm
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
            lblTituloAdminUsuarios = new Label();
            btnVolver = new Button();
            panelListaUsuarios = new FlowLayoutPanel();
            btnNuevoUsuario = new Button();
            SuspendLayout();
            // 
            // lblTituloAdminUsuarios
            // 
            lblTituloAdminUsuarios.AutoSize = true;
            lblTituloAdminUsuarios.Font = new Font("Segoe UI", 16F);
            lblTituloAdminUsuarios.Location = new Point(35, 21);
            lblTituloAdminUsuarios.Name = "lblTituloAdminUsuarios";
            lblTituloAdminUsuarios.Size = new Size(263, 37);
            lblTituloAdminUsuarios.TabIndex = 0;
            lblTituloAdminUsuarios.Text = "Administrar Usuarios";
            // 
            // btnVolver
            // 
            btnVolver.Location = new Point(35, 392);
            btnVolver.Name = "btnVolver";
            btnVolver.Size = new Size(94, 29);
            btnVolver.TabIndex = 1;
            btnVolver.Text = "Volver";
            btnVolver.UseVisualStyleBackColor = true;
            btnVolver.Click += btnVolver_Click;
            // 
            // panelListaUsuarios
            // 
            panelListaUsuarios.AutoScroll = true;
            panelListaUsuarios.FlowDirection = FlowDirection.TopDown;
            panelListaUsuarios.Location = new Point(35, 75);
            panelListaUsuarios.Name = "panelListaUsuarios";
            panelListaUsuarios.Size = new Size(729, 298);
            panelListaUsuarios.TabIndex = 2;
            panelListaUsuarios.WrapContents = false;
            // 
            // btnNuevoUsuario
            // 
            btnNuevoUsuario.Location = new Point(629, 29);
            btnNuevoUsuario.Name = "btnNuevoUsuario";
            btnNuevoUsuario.Size = new Size(126, 29);
            btnNuevoUsuario.TabIndex = 3;
            btnNuevoUsuario.Text = "Nuevo usuario";
            btnNuevoUsuario.UseVisualStyleBackColor = true;
            btnNuevoUsuario.Click += btnNuevoUsuario_Click;
            // 
            // AdminUsuariosForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnNuevoUsuario);
            Controls.Add(panelListaUsuarios);
            Controls.Add(btnVolver);
            Controls.Add(lblTituloAdminUsuarios);
            Name = "AdminUsuariosForm";
            Text = "Administrador";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTituloAdminUsuarios;
        private Button btnVolver;
        private FlowLayoutPanel panelListaUsuarios;
        private Button btnNuevoUsuario;
    }
}