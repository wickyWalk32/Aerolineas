using DTOs;
using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsForms
{
    public partial class AvionDeleteForm : Form
    {
        // Reemplaza con el puerto exacto de tu Web API .NET 8
        private static readonly HttpClient _httpClient = new HttpClient
        {
            BaseAddress = new Uri("https://localhost:7001/")
        };

        private int? _idAvionSeleccionado = null;

        public AvionDeleteForm()
        {
            InitializeComponent();
            AsignarEventos();
        }

        private void AsignarEventos()
        {
            btnBuscar.Click += async (s, e) => await BuscarAvionAsync();
            btnEliminar.Click += async (s, e) => await EliminarAvionAsync();
            btnVolver.Click += (s, e) => this.Close();
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
                        _idAvionSeleccionado = avion.Id;
                        lblDescripcionValor.Text = avion.Descripcion;
                        lblCapacidadValor.Text = avion.Capacidad.ToString();
                        lblEstadoValor.Text = avion.EstadoDisponibilidad;

                        btnEliminar.Enabled = true; // Habilita el botón de eliminación
                    }
                }
                else if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    LimpiarDatos();
                    MessageBox.Show($"No se encontró ningún avión con el ID {id}.", "No Encontrado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    LimpiarDatos();
                    MessageBox.Show($"Error al consultar la API: {response.StatusCode}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                LimpiarDatos();
                MessageBox.Show($"Error de conexión: {ex.Message}", "Error de red", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnBuscar.Enabled = true;
            }
        }

        private async Task EliminarAvionAsync()
        {
            if (!_idAvionSeleccionado.HasValue) return;

            // Confirmación explícita
            DialogResult confirmacion = MessageBox.Show(
                $"¿Está seguro de eliminar permanentemente el avión '{lblDescripcionValor.Text}' (ID: {_idAvionSeleccionado.Value})?",
                "Confirmar Eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (confirmacion != DialogResult.Yes) return;

            try
            {
                btnEliminar.Enabled = false;

                // Petición DELETE /aviones/{id}
                HttpResponseMessage response = await _httpClient.DeleteAsync($"aviones/{_idAvionSeleccionado.Value}");

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("¡Avión eliminado exitosamente de la base de datos!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    MessageBox.Show("El avión seleccionado ya no existe.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show($"Error al eliminar ({response.StatusCode}).", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al conectar con el servidor: {ex.Message}", "Error de red", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnEliminar.Enabled = true;
            }
        }

        private void LimpiarDatos()
        {
            _idAvionSeleccionado = null;
            lblDescripcionValor.Text = "-";
            lblCapacidadValor.Text = "-";
            lblEstadoValor.Text = "-";
            btnEliminar.Enabled = false;
        }
    }
}