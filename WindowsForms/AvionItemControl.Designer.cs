namespace WindowsForms
{
    partial class AvionItemControl
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
            components = new System.ComponentModel.Container();
            labelId = new Label();
            labelCapacidad = new Label();
            labelModelo = new Label();
            labelEstado = new Label();
            toolTipAvion = new ToolTip(components);
            buttonEliminar = new Button();
            buttonEditar = new Button();
            SuspendLayout();
            // 
            // labelId
            // 
            labelId.AutoSize = true;
            labelId.Location = new Point(19, 17);
            labelId.Name = "labelId";
            labelId.Size = new Size(17, 15);
            labelId.TabIndex = 0;
            labelId.Text = "Id";
            // 
            // labelCapacidad
            // 
            labelCapacidad.AutoSize = true;
            labelCapacidad.Location = new Point(217, 17);
            labelCapacidad.Name = "labelCapacidad";
            labelCapacidad.Size = new Size(63, 15);
            labelCapacidad.TabIndex = 1;
            labelCapacidad.Text = "Capacidad";
            // 
            // labelModelo
            // 
            labelModelo.AutoSize = true;
            labelModelo.Location = new Point(112, 17);
            labelModelo.Name = "labelModelo";
            labelModelo.Size = new Size(48, 15);
            labelModelo.TabIndex = 2;
            labelModelo.Text = "Modelo";
            // 
            // labelEstado
            // 
            labelEstado.AutoSize = true;
            labelEstado.Location = new Point(341, 17);
            labelEstado.Name = "labelEstado";
            labelEstado.Size = new Size(42, 15);
            labelEstado.TabIndex = 3;
            labelEstado.Text = "Estado";
            // 
            // buttonEliminar
            // 
            buttonEliminar.Cursor = Cursors.Hand;
            buttonEliminar.FlatAppearance.BorderSize = 0;
            buttonEliminar.FlatAppearance.MouseDownBackColor = Color.Transparent;
            buttonEliminar.FlatAppearance.MouseOverBackColor = Color.Transparent;
            buttonEliminar.FlatStyle = FlatStyle.Flat;
            buttonEliminar.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            buttonEliminar.Location = new Point(564, -1);
            buttonEliminar.Name = "buttonEliminar";
            buttonEliminar.Size = new Size(55, 49);
            buttonEliminar.TabIndex = 4;
            buttonEliminar.TabStop = false;
            buttonEliminar.Text = "✕";
            buttonEliminar.UseVisualStyleBackColor = false;
            buttonEliminar.Click += buttonEliminar_Click;
            buttonEliminar.MouseEnter += buttonEliminar_MouseEnter;
            buttonEliminar.MouseLeave += button_MouseLeave;
            // 
            // buttonEditar
            // 
            buttonEditar.Cursor = Cursors.Hand;
            buttonEditar.FlatAppearance.BorderSize = 0;
            buttonEditar.FlatAppearance.MouseDownBackColor = Color.Transparent;
            buttonEditar.FlatAppearance.MouseOverBackColor = Color.Transparent;
            buttonEditar.FlatStyle = FlatStyle.Flat;
            buttonEditar.Font = new Font("Segoe UI", 15F);
            buttonEditar.Location = new Point(501, -1);
            buttonEditar.Name = "buttonEditar";
            buttonEditar.Size = new Size(41, 49);
            buttonEditar.TabIndex = 5;
            buttonEditar.TabStop = false;
            buttonEditar.Text = "🖉";
            buttonEditar.UseVisualStyleBackColor = false;
            buttonEditar.Click += buttonEditar_Click;
            buttonEditar.MouseEnter += buttonEditar_MouseEnter;
            buttonEditar.MouseLeave += button_MouseLeave;
            // 
            // AvionItemControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BorderStyle = BorderStyle.FixedSingle;
            Controls.Add(buttonEditar);
            Controls.Add(buttonEliminar);
            Controls.Add(labelEstado);
            Controls.Add(labelModelo);
            Controls.Add(labelCapacidad);
            Controls.Add(labelId);
            Name = "AvionItemControl";
            Size = new Size(618, 47);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelId;
        private Label labelCapacidad;
        private Label labelModelo;
        private Label labelEstado;
        private ToolTip toolTipAvion;
        private Button buttonEliminar;
        private Button buttonEditar;
    }
}
