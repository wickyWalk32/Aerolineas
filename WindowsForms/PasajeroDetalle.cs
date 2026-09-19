using DTOs;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace WindowsForms
{
    public partial class PasajeroDetalle : Form
    {
        private bool _esEdicion = false;
        private int _pasajeroId = 0;


        public PasajeroDetalle()
        {
            InitializeComponent();
        }

        public PasajeroDetalle(PasajeroUpdateDTO pasajeroUpdateDTO)
        {
            
            InitializeComponent();

            _esEdicion = true;
            _pasajeroId = pasajeroUpdateDTO.Id;

            string tipoPas = "";

            if (pasajeroUpdateDTO.Tipo == 'A') 
            {
                tipoPas = "Adulto";
            }

            if (pasajeroUpdateDTO.Tipo == 'M')
            {
                tipoPas = "Menor";
            }

            cboTipoPasajero.Text = tipoPas; //arreglar
            txtNombre.Text = pasajeroUpdateDTO.Nombre;
            txtApellido.Text = pasajeroUpdateDTO.Apellido;
            cboTipoDocumento.Text = pasajeroUpdateDTO.TipoDocumento;
            txtNroDocumento.Text = pasajeroUpdateDTO.NroDocumento;
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
            if (!_esEdicion)
            {
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
            else
            {
                if (_pasajeroId == 0)
                {
                    return;
                }
                PasajeroUpdateDTO pasajero = new PasajeroUpdateDTO
                {
                    Id = _pasajeroId,
                    Tipo = cboTipoPasajero.Text[0],
                    Nombre = txtNombre.Text,
                    Apellido = txtApellido.Text,
                    TipoDocumento = cboTipoDocumento.Text,
                    NroDocumento = txtNroDocumento.Text
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
        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
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

