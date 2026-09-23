using DTOs;
using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsForms
{
    public partial class AvionUpdateForm : Form
    {
        // Reemplaza con el puerto de tu API .NET 8
        private static readonly HttpClient _httpClient = new HttpClient
        {
            BaseAddress = new Uri("https://localhost:7001/")
        };

        public AvionUpdateForm()
        {
            InitializeComponent();
            AsignarEventos();
        }

        private void AsignarEventos()
        {
            btnBuscar.Click += async (s, e) => await BuscarAvionAsync();
            btnGuardar.Click += async (s, e) => await GuardarCambiosAsync();
            btnVolver.Click += (s, e) => this.Close();
        }

        private void AvionUpdateForm_Load(object sender, EventArgs e)
        {
            CargarEstados();
        }

        private void CargarEstados()
        {
            comboBoxDisponibilidad.Items.Clear();
            comboBoxDisponibilidad.Items.Add("Disponible");
            comboBoxDisponibilidad.Items.Add("En Mantenimiento");
            comboBoxDisponibilidad.Items.Add("Inactivo");
            comboBoxDisponibilidad.SelectedIndex = 0;
        }

        private async Task BuscarAvionAsync()
        {
            int id = (int)numIdBusqueda.Value;

            try
            {
                btnBuscar.Enabled = false;

                // Consulta GET /aviones/{id}
                HttpResponseMessage response = await _httpClient.GetAsync($"aviones/{id}");

                if (response.IsSuccessStatusCode)
                {
                    var avion = await response.Content.ReadFromJsonAsync<AvionDTO>();

                    if (avion != null)
                    {
                        textBoxDescripcion.Text = avion.Descripcion;
                        textBoxCapacidad.Text = avion.Capacidad.ToString();

                        int indexEstado = comboBoxDisponibilidad.FindStringExact(avion.EstadoDisponibilidad);
                        comboBoxDisponibilidad.SelectedIndex = indexEstado >= 0 ? indexEstado : 0;

                        MessageBox.Show("Datos del avión cargados correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    MessageBox.Show($"No se encontró ningún avión con el ID {id}.", "No Encontrado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show($"Error al consultar API: {response.StatusCode}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error de conexión: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnBuscar.Enabled = true;
            }
        }

        private async Task GuardarCambiosAsync()
        {
            int id = (int)numIdBusqueda.Value;

            if (string.IsNullOrWhiteSpace(textBoxDescripcion.Text))
            {
                MessageBox.Show("Ingrese una descripción válida.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(textBoxCapacidad.Text, out int capacidad) || capacidad <= 0)
            {
                MessageBox.Show("Ingrese una capacidad mayor a 0.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // DTO preparado para el PUT
            var avionUpdate = new AvionUpdateDTO
            {
                Id = id,
                Descripcion = textBoxDescripcion.Text.Trim(),
                Capacidad = capacidad,
                EstadoDisponibilidad = comboBoxDisponibilidad.SelectedItem?.ToString() ?? "Disponible"
            };

            try
            {
                btnGuardar.Enabled = false;

                // Petición PUT /aviones/{id}
                HttpResponseMessage response = await _httpClient.PutAsJsonAsync($"aviones/{id}", avionUpdate);

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("¡Avión actualizado correctamente!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    MessageBox.Show("El avión que intentas modificar ya no existe en la base de datos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    string error = await response.Content.ReadAsStringAsync();
                    MessageBox.Show($"Error al actualizar ({response.StatusCode}): {error}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al conectar con la API: {ex.Message}", "Error de red", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnGuardar.Enabled = true;
            }
        }
    }
}