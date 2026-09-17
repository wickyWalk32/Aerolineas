using DTOs;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace WindowsForms
{
    public partial class PasajeroDetalle : Form
    {
        public PasajeroDetalle()
        {
            InitializeComponent();
        }

        private void txtNroDocumento_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                errorProviderNroDni.SetError(txtNroDocumento, "Solo se permiten numeros");
                e.Handled = true;
            }
            else
            {
                errorProviderNroDni.SetError(txtNroDocumento, "");
            }
        }
        private async void btnGuardar_Click(object sender, EventArgs e) {
            PasajeroCreateDTO pasajero = new PasajeroCreateDTO
            {
                Tipo = cboTipoPasajero.Text[0],
                Nombre = txtNombre.Text,
                Apellido = txtApellido.Text,
                TipoDocumento = cboTipoDocumento.Text,
                NroDocumento = txtNroDocumento.Text
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

        private void ClearForm()
        {
            txtNombre.Clear();
            txtApellido.Clear();
            txtNroDocumento.Clear();
            cboTipoDocumento.SelectedIndex = -1;
            cboTipoPasajero.SelectedIndex = -1;
        }
    }
    }

