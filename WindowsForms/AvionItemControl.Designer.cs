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
            label1 = new Label();
            label2 = new Label();
            SuspendLayout();
            // 
            // labelId
            // 
            labelId.AutoSize = true;
            labelId.Location = new Point(22, 23);
            labelId.Name = "labelId";
            labelId.Size = new Size(22, 20);
            labelId.TabIndex = 0;
            labelId.Text = "Id";
            // 
            // labelCapacidad
            // 
            labelCapacidad.AutoSize = true;
            labelCapacidad.Location = new Point(521, 23);
            labelCapacidad.Name = "labelCapacidad";
            labelCapacidad.Size = new Size(80, 20);
            labelCapacidad.TabIndex = 1;
            labelCapacidad.Text = "Capacidad";
            // 
            // labelModelo
            // 
            labelModelo.AutoSize = true;
            labelModelo.Location = new Point(100, 23);
            labelModelo.Name = "labelModelo";
            labelModelo.Size = new Size(61, 20);
            labelModelo.TabIndex = 2;
            labelModelo.Text = "Modelo";
            // 
            // labelEstado
            // 
            labelEstado.AutoSize = true;
            labelEstado.Location = new Point(679, 23);
            labelEstado.Name = "labelEstado";
            labelEstado.Size = new Size(54, 20);
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
            buttonEliminar.Location = new Point(906, -2);
            buttonEliminar.Margin = new Padding(3, 4, 3, 4);
            buttonEliminar.Name = "buttonEliminar";
            buttonEliminar.Size = new Size(63, 65);
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
            buttonEditar.Location = new Point(834, -2);
            buttonEditar.Margin = new Padding(3, 4, 3, 4);
            buttonEditar.Name = "buttonEditar";
            buttonEditar.Size = new Size(47, 65);
            buttonEditar.TabIndex = 5;
            buttonEditar.TabStop = false;
            buttonEditar.Text = "🖉";
            buttonEditar.UseVisualStyleBackColor = false;
            buttonEditar.Click += buttonEditar_Click;
            buttonEditar.MouseEnter += buttonEditar_MouseEnter;
            buttonEditar.MouseLeave += button_MouseLeave;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(439, 23);
            label1.Name = "label1";
            label1.Size = new Size(87, 20);
            label1.TabIndex = 6;
            label1.Text = "Capacidad: ";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(623, 23);
            label2.Name = "label2";
            label2.Size = new Size(61, 20);
            label2.TabIndex = 7;
            label2.Text = "Estado: ";
            // 
            // AvionItemControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BorderStyle = BorderStyle.FixedSingle;
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(buttonEditar);
            Controls.Add(buttonEliminar);
            Controls.Add(labelEstado);
            Controls.Add(labelModelo);
            Controls.Add(labelCapacidad);
            Controls.Add(labelId);
            Margin = new Padding(3, 4, 3, 4);
            Name = "AvionItemControl";
            Size = new Size(1000, 63);
            Load += AvionItemControl_Load;
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
        private Label label1;
        private Label label2;
    }
}
