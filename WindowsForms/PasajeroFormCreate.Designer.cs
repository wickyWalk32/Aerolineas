using System;
using System.Windows.Forms;
using Domain.Model;

namespace WindowsForms
{
    public partial class PasajeroFormCreate : Form
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
            SuspendLayout();
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Location = new Point(24, 20);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(82, 25);
            lblNombre.TabIndex = 0;
            lblNombre.Text = "Nombre:";
            // 
            // lblApellido
            // 
            lblApellido.AutoSize = true;
            lblApellido.Location = new Point(24, 56);
            lblApellido.Name = "lblApellido";
            lblApellido.Size = new Size(82, 25);
            lblApellido.TabIndex = 1;
            lblApellido.Text = "Apellido:";
            // 
            // lblTipoDocumento
            // 
            lblTipoDocumento.AutoSize = true;
            lblTipoDocumento.Location = new Point(24, 92);
            lblTipoDocumento.Name = "lblTipoDocumento";
            lblTipoDocumento.Size = new Size(173, 25);
            lblTipoDocumento.TabIndex = 2;
            lblTipoDocumento.Text = "Tipo de documento:";
            // 
            // lblNroDocumento
            // 
            lblNroDocumento.AutoSize = true;
            lblNroDocumento.Location = new Point(24, 128);
            lblNroDocumento.Name = "lblNroDocumento";
            lblNroDocumento.Size = new Size(159, 25);
            lblNroDocumento.TabIndex = 3;
            lblNroDocumento.Text = "Nº de documento:";
            // 
            // lblTipoPasajero
            // 
            lblTipoPasajero.AutoSize = true;
            lblTipoPasajero.Location = new Point(24, 164);
            lblTipoPasajero.Name = "lblTipoPasajero";
            lblTipoPasajero.Size = new Size(123, 25);
            lblTipoPasajero.TabIndex = 4;
            lblTipoPasajero.Text = "Tipo pasajero:";
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(140, 16);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(240, 31);
            txtNombre.TabIndex = 0;
            // 
            // txtApellido
            // 
            txtApellido.Location = new Point(140, 52);
            txtApellido.Name = "txtApellido";
            txtApellido.Size = new Size(240, 31);
            txtApellido.TabIndex = 1;
            // 
            // txtNroDocumento
            // 
            txtNroDocumento.Location = new Point(220, 127);
            txtNroDocumento.Name = "txtNroDocumento";
            txtNroDocumento.Size = new Size(160, 31);
            txtNroDocumento.TabIndex = 3;
            // 
            // cboTipoDocumento
            // 
            cboTipoDocumento.DropDownStyle = ComboBoxStyle.DropDownList;
            cboTipoDocumento.Location = new Point(220, 88);
            cboTipoDocumento.Name = "cboTipoDocumento";
            cboTipoDocumento.Size = new Size(160, 33);
            cboTipoDocumento.TabIndex = 2;
            cboTipoDocumento.SelectedIndexChanged += cboTipoDocumento_SelectedIndexChanged;
            // 
            // cboTipoPasajero
            // 
            cboTipoPasajero.DropDownStyle = ComboBoxStyle.DropDownList;
            cboTipoPasajero.Location = new Point(220, 164);
            cboTipoPasajero.Name = "cboTipoPasajero";
            cboTipoPasajero.Size = new Size(160, 33);
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
            btnGuardar.Click += btnGuardar_Click;
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
            // PasajeroFormCreate
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
            Name = "PasajeroFormCreate";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Registro de Pasajero";
            ResumeLayout(false);
            PerformLayout();
        }

        private void CargarDesplegables()
        {
            cboTipoDocumento.Items.Clear();
            cboTipoDocumento.Items.Add("DNI");
            cboTipoDocumento.Items.Add("Pasaporte");
            cboTipoDocumento.Items.Add("LE/LC");
            cboTipoDocumento.SelectedIndex = 0;

            cboTipoPasajero.Items.Clear();
            cboTipoPasajero.Items.Add("E - Estándar");
            cboTipoPasajero.Items.Add("F - Frecuente");
            cboTipoPasajero.Items.Add("V - VIP");
            cboTipoPasajero.SelectedIndex = 0;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text) ||
                string.IsNullOrWhiteSpace(txtApellido.Text) ||
                string.IsNullOrWhiteSpace(txtNroDocumento.Text))
            {
                MessageBox.Show("Por favor complete todos los campos obligatorios.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string seleccionTipo = cboTipoPasajero.SelectedItem.ToString();
            char tipoChar = seleccionTipo[0];

            try
            {
                Pasajero nuevoPasajero = new Pasajero(
                    txtNombre.Text.Trim(),
                    txtApellido.Text.Trim(),
                    cboTipoDocumento.SelectedItem.ToString(),
                    txtNroDocumento.Text.Trim(),
                    tipoChar
                );

                MessageBox.Show($"¡Pasajero {nuevoPasajero.Nombre} {nuevoPasajero.Apellido} registrado exitosamente!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error al guardar: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LimpiarCampos()
        {
            txtNombre.Clear();
            txtApellido.Clear();
            txtNroDocumento.Clear();
            cboTipoDocumento.SelectedIndex = 0;
            cboTipoPasajero.SelectedIndex = 0;
            txtNombre.Focus();
        }
    }
}