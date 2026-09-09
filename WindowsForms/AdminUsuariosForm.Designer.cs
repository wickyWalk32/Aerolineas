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
            lblTituloAdminUsuarios.Location = new Point(31, 16);
            lblTituloAdminUsuarios.Name = "lblTituloAdminUsuarios";
            lblTituloAdminUsuarios.Size = new Size(212, 30);
            lblTituloAdminUsuarios.TabIndex = 0;
            lblTituloAdminUsuarios.Text = "Administrar Usuarios";
            // 
            // btnVolver
            // 
            btnVolver.Location = new Point(31, 294);
            btnVolver.Margin = new Padding(3, 2, 3, 2);
            btnVolver.Name = "btnVolver";
            btnVolver.Size = new Size(82, 22);
            btnVolver.TabIndex = 1;
            btnVolver.Text = "Volver";
            btnVolver.UseVisualStyleBackColor = true;
            btnVolver.Click += btnVolver_Click;
            // 
            // panelListaUsuarios
            // 
            panelListaUsuarios.AutoScroll = true;
            panelListaUsuarios.FlowDirection = FlowDirection.TopDown;
            panelListaUsuarios.Location = new Point(31, 56);
            panelListaUsuarios.Margin = new Padding(3, 2, 3, 2);
            panelListaUsuarios.Name = "panelListaUsuarios";
            panelListaUsuarios.Size = new Size(638, 224);
            panelListaUsuarios.TabIndex = 2;
            panelListaUsuarios.WrapContents = false;
            panelListaUsuarios.Paint += panelListaUsuarios_Paint;
            // 
            // btnNuevoUsuario
            // 
            btnNuevoUsuario.Location = new Point(550, 22);
            btnNuevoUsuario.Margin = new Padding(3, 2, 3, 2);
            btnNuevoUsuario.Name = "btnNuevoUsuario";
            btnNuevoUsuario.Size = new Size(110, 22);
            btnNuevoUsuario.TabIndex = 3;
            btnNuevoUsuario.Text = "Nuevo usuario";
            btnNuevoUsuario.UseVisualStyleBackColor = true;
            btnNuevoUsuario.Click += btnNuevoUsuario_Click;
            // 
            // AdminUsuariosForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(700, 338);
            Controls.Add(btnNuevoUsuario);
            Controls.Add(panelListaUsuarios);
            Controls.Add(btnVolver);
            Controls.Add(lblTituloAdminUsuarios);
            Margin = new Padding(3, 2, 3, 2);
            Name = "AdminUsuariosForm";
            Text = "Administrador";
            Load += AdminUsuariosForm_Load;
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