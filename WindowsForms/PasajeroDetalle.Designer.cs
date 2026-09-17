namespace WindowsForms
{
    public partial class PasajeroDetalle : Form
    {
        private Label lblNombre;
        private Label lblApellido;
        private Label lblTipoDocumento;
        private Label lblNroDocumento;
        private Label lblTipoPasajero;
        private TextBox txtNombre;
        private TextBox txtApellido;
        private TextBox txtNroDocumento;
        private ComboBox cboTipoDocumento;
        private ComboBox cboTipoPasajero;
        private Button btnGuardar;
        private Button btnVolver;


        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            lblNombre = new Label();
            lblApellido = new Label();
            lblTipoDocumento = new Label();
            lblNroDocumento = new Label();
            lblTipoPasajero = new Label();
            txtNombre = new TextBox();
            txtApellido = new TextBox();
            txtNroDocumento = new TextBox();
            cboTipoDocumento = new ComboBox();
            cboTipoPasajero = new ComboBox();
            btnGuardar = new Button();
            btnVolver = new Button();
            errorProviderNroDni = new ErrorProvider(components);
            ((System.ComponentModel.ISupportInitialize)errorProviderNroDni).BeginInit();
            SuspendLayout();
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Location = new Point(24, 20);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(54, 15);
            lblNombre.TabIndex = 0;
            lblNombre.Text = "Nombre:";
            // 
            // lblApellido
            // 
            lblApellido.AutoSize = true;
            lblApellido.Location = new Point(24, 56);
            lblApellido.Name = "lblApellido";
            lblApellido.Size = new Size(54, 15);
            lblApellido.TabIndex = 1;
            lblApellido.Text = "Apellido:";
            // 
            // lblTipoDocumento
            // 
            lblTipoDocumento.AutoSize = true;
            lblTipoDocumento.Location = new Point(24, 92);
            lblTipoDocumento.Name = "lblTipoDocumento";
            lblTipoDocumento.Size = new Size(114, 15);
            lblTipoDocumento.TabIndex = 2;
            lblTipoDocumento.Text = "Tipo de documento:";
            // 
            // lblNroDocumento
            // 
            lblNroDocumento.AutoSize = true;
            lblNroDocumento.Location = new Point(24, 128);
            lblNroDocumento.Name = "lblNroDocumento";
            lblNroDocumento.Size = new Size(105, 15);
            lblNroDocumento.TabIndex = 3;
            lblNroDocumento.Text = "Nº de documento:";
            // 
            // lblTipoPasajero
            // 
            lblTipoPasajero.AutoSize = true;
            lblTipoPasajero.Location = new Point(24, 164);
            lblTipoPasajero.Name = "lblTipoPasajero";
            lblTipoPasajero.Size = new Size(80, 15);
            lblTipoPasajero.TabIndex = 4;
            lblTipoPasajero.Text = "Tipo pasajero:";
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(140, 16);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(240, 23);
            txtNombre.TabIndex = 0;
            // 
            // txtApellido
            // 
            txtApellido.Location = new Point(140, 52);
            txtApellido.Name = "txtApellido";
            txtApellido.Size = new Size(240, 23);
            txtApellido.TabIndex = 1;
            // 
            // txtNroDocumento
            // 
            txtNroDocumento.Location = new Point(220, 127);
            txtNroDocumento.Name = "txtNroDocumento";
            txtNroDocumento.Size = new Size(160, 23);
            txtNroDocumento.TabIndex = 3;
            txtNroDocumento.KeyPress += txtNroDocumento_KeyPress;
            // 
            // cboTipoDocumento
            // 
            cboTipoDocumento.DropDownStyle = ComboBoxStyle.DropDownList;
            cboTipoDocumento.Items.AddRange(new object[] { "DNI", "DNI (Extranjero)", "Libreta Cívica (LC)", "Libreta de Enrolamiento (LE)" });
            cboTipoDocumento.Location = new Point(220, 88);
            cboTipoDocumento.Name = "cboTipoDocumento";
            cboTipoDocumento.Size = new Size(160, 23);
            cboTipoDocumento.TabIndex = 2;
            // 
            // cboTipoPasajero
            // 
            cboTipoPasajero.DropDownStyle = ComboBoxStyle.DropDownList;
            cboTipoPasajero.Items.AddRange(new object[] { "Adulto", "Menor" });
            cboTipoPasajero.Location = new Point(220, 164);
            cboTipoPasajero.Name = "cboTipoPasajero";
            cboTipoPasajero.Size = new Size(160, 23);
            cboTipoPasajero.TabIndex = 4;
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(61, 295);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(100, 30);
            btnGuardar.TabIndex = 5;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += this.btnGuardar_Click;
            // 
            // btnVolver
            // 
            btnVolver.Location = new Point(298, 295);
            btnVolver.Name = "btnVolver";
            btnVolver.Size = new Size(100, 30);
            btnVolver.TabIndex = 6;
            btnVolver.Text = "Volver";
            btnVolver.UseVisualStyleBackColor = true;
            btnVolver.Click += btnVolver_Click;
            // 
            // errorProviderNroDni
            // 
            errorProviderNroDni.ContainerControl = this;
            // 
            // PasajeroDetalle
            // 
            AcceptButton = btnGuardar;
            CancelButton = btnVolver;
            ClientSize = new Size(465, 374);
            Controls.Add(lblNombre);
            Controls.Add(txtNombre);
            Controls.Add(lblApellido);
            Controls.Add(txtApellido);
            Controls.Add(lblTipoDocumento);
            Controls.Add(cboTipoDocumento);
            Controls.Add(lblNroDocumento);
            Controls.Add(txtNroDocumento);
            Controls.Add(lblTipoPasajero);
            Controls.Add(cboTipoPasajero);
            Controls.Add(btnGuardar);
            Controls.Add(btnVolver);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "PasajeroDetalle";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Registro de Pasajero";
            ((System.ComponentModel.ISupportInitialize)errorProviderNroDni).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
        private ErrorProvider errorProviderNroDni;
        private System.ComponentModel.IContainer components;
    }
}