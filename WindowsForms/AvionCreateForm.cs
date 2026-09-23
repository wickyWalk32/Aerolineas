using DTOs;
using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Windows.Forms;

namespace WindowsForms
{
    public partial class AvionCreateForm : Form
    {
        // Ajusta la URL con el puerto exacto donde ejecuta tu Web API de .NET 8
        private static readonly HttpClient _httpClient = new HttpClient
        {
            BaseAddress = new Uri("https://localhost:7001/")
        };

        public AvionCreateForm()
        {
            InitializeComponent();
            AsignarEventos();
        }

        private void AsignarEventos()
        {
            // Vinculación de eventos Click a los botones
            btnGuardar.Click += btnGuardar_Click;
            btnVolver.Click += btnVolver_Click;
        }

        private void AvionCreateForm_Load(object sender, EventArgs e)
        {
            CargarEstadosDisponibilidad();
        }

        private void CargarEstadosDisponibilidad()
        {
            comboBoxDisponibilidad.Items.Clear();
            comboBoxDisponibilidad.Items.Add("Disponible");
            comboBoxDisponibilidad.Items.Add("En Mantenimiento");
            comboBoxDisponibilidad.Items.Add("Inactivo");
            comboBoxDisponibilidad.SelectedIndex = 0;
        }

        private async void btnGuardar_Click(object sender, EventArgs e)
        {
            // 1. Validar campo Descripción
            if (string.IsNullOrWhiteSpace(textBoxDescripcion.Text))
            {
                MessageBox.Show("Por favor, ingrese una descripción.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Validar campo Capacidad
            if (!int.TryParse(textBoxCapacidad.Text, out int capacidad) || capacidad <= 0)
            {
                MessageBox.Show("Ingrese un número válido mayor a 0 en Capacidad.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 3. Crear el DTO para el POST
            var nuevoAvion = new AvionCreateDTO
            {
                Descripcion = textBoxDescripcion.Text.Trim(),
                Capacidad = capacidad,
                EstadoDisponibilidad = comboBoxDisponibilidad.SelectedItem?.ToString() ?? "Disponible"
            };

            // 4. Enviar datos a la API (.NET 8)
            try
            {
                btnGuardar.Enabled = false;

                HttpResponseMessage response = await _httpClient.PostAsJsonAsync("aviones", nuevoAvion);

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("¡Avión creado exitosamente!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    string errorMsg = await response.Content.ReadAsStringAsync();
                    MessageBox.Show($"Error en la API ({response.StatusCode}): {errorMsg}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"No se pudo conectar con el servidor API: {ex.Message}", "Error de red", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        // Eventos de etiquetas para prevenir errores de compilación CS0103
        private void label1_Click(object sender, EventArgs e) { }
        private void label4_Click(object sender, EventArgs e) { }
    }
}