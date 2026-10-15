using Domain.Model;
using DTOs;
using System;
using System.Drawing;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsForms
{
    public partial class AvionUpdateForm : Form
    {
        AvionDTO _avionDTO;
        int _capacidadInicial;
        List<AsientoCreateDTO> _asientos;

        public AvionUpdateForm(AvionDTO avion)
        {
            InitializeComponent();
            _avionDTO = avion;
            _capacidadInicial = avion.Capacidad;

            AsignarEventos();
        }

        private void AsignarEventos()
        {
            btnGuardar.Click += async (s, e) => await GuardarCambiosAsync();
            btnVolver.Click += btnVolver_Click;
        }

        private void AvionUpdateForm_Load(object sender, EventArgs e)
        {
            CargarAvionData(_avionDTO);
        }

        private void CargarAvionData(AvionDTO avion)
        {
            lblID.Text = _avionDTO.Id.ToString();
            textBoxDescripcion.Text = _avionDTO.Descripcion;
            textBoxCapacidad.Text = _avionDTO.Capacidad.ToString();
            comboBoxDisponibilidad.SelectedItem = _avionDTO.EstadoDisponibilidad;
            int filas = avion.Asientos.Count()/4; // cantidad de asientos dividido columnas es cantidad de filas
            _asientos = avionControl.AgregarAsientos(filas);
        }


        private async Task GuardarCambiosAsync()
        {
            int id = _avionDTO.Id;
            AvionUpdateDTO avionUpdate;

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
            if (_capacidadInicial.ToString() == textBoxCapacidad.Text)
            {
                // DTO preparado para el PUT
                avionUpdate = new AvionUpdateDTO
                {
                    Id = id,
                    Descripcion = textBoxDescripcion.Text.Trim(),
                    Capacidad = capacidad,
                    EstadoDisponibilidad = comboBoxDisponibilidad.SelectedItem?.ToString() ?? "Disponible"
                };
            }
            else
            {
                avionUpdate = new AvionUpdateDTO
                {
                    Id = id,
                    Descripcion = textBoxDescripcion.Text.Trim(),
                    Capacidad = capacidad,
                    EstadoDisponibilidad = comboBoxDisponibilidad.SelectedItem?.ToString() ?? "Disponible",
                    Asientos = _asientos
                };
            }

                try
                {
                    btnGuardar.Enabled = false;

                    // Petición PUT /aviones/{id}
                    HttpResponseMessage response = await Program.HttpClient.PutAsJsonAsync($"aviones/{id}", avionUpdate);

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

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBoxFilas_SelectedIndexChanged(object sender, EventArgs e)
        {
            avionControl.LimpiarAsientos();
            int filas = int.TryParse(comboBoxFilas.Text.Trim(), out int value) ? value : 0;
            textBoxCapacidad.Text = (filas*4).ToString();
            avionControl.AgregarAsientos(filas);
        }

    }
}