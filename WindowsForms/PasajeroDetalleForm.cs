using Domain.Model;
using DTOs;
using System;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsForms
{
    public partial class PasajeroDetalleForm : Form
    {
        private bool _esEdicion = false;
        private int _pasajeroId = 0;

        public PasajeroDetalleForm()
        {
            InitializeComponent();
            CargarTiposPasajero(); // Cargamos los valores al iniciar
        }

        public PasajeroDetalleForm(PasajeroUpdateDTO pasajeroUpdateDTO)
        {
            InitializeComponent();
            CargarTiposPasajero(); // Cargamos los valores al iniciar

            _esEdicion = true;
            _pasajeroId = pasajeroUpdateDTO.Id;

            txtNombre.Text = pasajeroUpdateDTO.Nombre;
            txtApellido.Text = pasajeroUpdateDTO.Apellido;
            cboTipoDocumento.Text = pasajeroUpdateDTO.TipoDocumento;
            txtNroDocumento.Text = pasajeroUpdateDTO.NroDocumento;
            cboTipoPasajero.SelectedItem = pasajeroUpdateDTO.Tipo;
        }

        private void txtNroDocumento_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                errorProviderNroDni.SetError(txtNroDocumento, "Solo se permiten números");
                e.Handled = true;
            }
            else
            {
                errorProviderNroDni.SetError(txtNroDocumento, "");
            }
        }

        private async void btnGuardar_Click(object sender, EventArgs e)
        {
            
            if (cboTipoPasajero.SelectedIndex <= 0)
            {
                MessageBox.Show("Por favor, seleccione un tipo de pasajero válido (Mayor o Menor).", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboTipoPasajero.Focus();
                return;
            }

            if (!_esEdicion)
            {
                // NUEVO PASAJERO

                PasajeroCreateDTO pasajero = new PasajeroCreateDTO
                {
                    Nombre = txtNombre.Text,
                    Apellido = txtApellido.Text,
                    TipoDocumento = cboTipoDocumento.Text,
                    NroDocumento = txtNroDocumento.Text,
                    Tipo = cboTipoPasajero.SelectedItem.ToString()
                };

                var request = await Program.HttpClient.PostAsJsonAsync<PasajeroCreateDTO>("pasajeros", pasajero);

                if (request.IsSuccessStatusCode)
                {
                    ClearForm();
                    MessageBox.Show("Pasajero Guardado", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Error al guardar pasajero", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                // EDITAR PASAJERO

                if (_pasajeroId == 0)
                {
                    return;
                }

                PasajeroUpdateDTO pasajero = new PasajeroUpdateDTO
                {
                    Id = _pasajeroId,
                    Nombre = txtNombre.Text,
                    Apellido = txtApellido.Text,
                    TipoDocumento = cboTipoDocumento.Text,
                    NroDocumento = txtNroDocumento.Text,
                    Tipo = cboTipoPasajero.SelectedItem.ToString()
                };

                var request = await Program.HttpClient.PutAsJsonAsync<PasajeroUpdateDTO>($"pasajeros/{_pasajeroId}", pasajero);

                if (request.IsSuccessStatusCode)
                {
                    MessageBox.Show("Cambios Guardados", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Error al guardar pasajero", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void CargarTiposPasajero()
        {
            cboTipoPasajero.Items.Clear();

            cboTipoPasajero.Items.Add("--- Seleccione tipo ---");
            cboTipoPasajero.Items.Add("Mayor");
            cboTipoPasajero.Items.Add("Menor");

            cboTipoPasajero.SelectedIndex = 0; // Dejamos seleccionado "Seleccione tipo" por defecto al abrir el formulario
        }

        private void ClearForm()
        {
            txtNombre.Clear();
            txtApellido.Clear();
            txtNroDocumento.Clear();
            cboTipoDocumento.SelectedIndex = -1;
            cboTipoPasajero.SelectedIndex = 0; // Regresa al placeholder "--- Seleccione tipo ---"
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
    }
}