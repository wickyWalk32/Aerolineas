using DTOs;
using System.Net.Http.Json;

namespace WindowsForms
{
    public partial class AvionCreateForm : Form
    {
        private static readonly char[] LetrasColumnas = { 'A', 'B', 'C', 'D' };

        public AvionCreateForm()
        {
            InitializeComponent();
        }

        private void AvionCreateForm_Load(object? sender, EventArgs e)
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

        private List<AsientoCreateDTO> GenerarAsientosPorCapacidad(int capacidad)
        {
            var lista = new List<AsientoCreateDTO>(capacidad);

            // Patrón: 1A, 1B, 1C, 1D, 2A, 2B, 2C, 2D, 3A...
            for (int i = 0; i < capacidad; i++)
            {
                int nroFila = (i / LetrasColumnas.Length) + 1;
                char letra = LetrasColumnas[i % LetrasColumnas.Length];
                string codigo = $"{nroFila}{letra}";

                lista.Add(new AsientoCreateDTO
                {
                    Codigo = codigo,
                    Fila = letra,
                    Columna = nroFila,
                    Estado = "Habilitado"
                });
            }

            return lista;
        }

        private async void btnGuardar_Click(object? sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxDescripcion.Text))
            {
                MessageBox.Show("Por favor, ingrese una descripción.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxDescripcion.Focus();
                return;
            }

            if (!int.TryParse(textBoxCapacidad.Text.Trim(), out int capacidad) || capacidad <= 0)
            {
                MessageBox.Show("Ingrese un número válido mayor a 0 en Capacidad.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxCapacidad.Focus();
                return;
            }

            var asientosGenerados = GenerarAsientosPorCapacidad(capacidad);

            var nuevoAvion = new AvionCreateDTO
            {
                Descripcion = textBoxDescripcion.Text.Trim(),
                Capacidad = capacidad,
                EstadoDisponibilidad = comboBoxDisponibilidad.SelectedItem?.ToString() ?? "Disponible",
                AsientosCreateDTO = asientosGenerados
            };

            try
            {
                btnGuardar.Enabled = false;

                HttpResponseMessage response = await Program.HttpClient.PostAsJsonAsync("aviones", nuevoAvion);

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

        private void btnVolver_Click(object? sender, EventArgs e)
        {
            this.Close();
        }
    }
}