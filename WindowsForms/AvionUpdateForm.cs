using DTOs;
using System.Net.Http.Json;

namespace WindowsForms
{
    public partial class AvionUpdateForm : Form
    {
        private static readonly char[] LetrasColumnas = { 'A', 'B', 'C', 'D' };

        private readonly AvionDTO _avionDTO;
        private readonly int _capacidadInicial;

        public AvionUpdateForm(AvionDTO avion)
        {
            InitializeComponent();
            _avionDTO = avion;
            _capacidadInicial = avion.Capacidad;

            AsignarEventos();
        }

        private void AsignarEventos()
        {
            btnGuardar.Click += async (_, _) => await GuardarCambiosAsync();
            btnVolver.Click += btnVolver_Click;
        }

        private void AvionUpdateForm_Load(object? sender, EventArgs e)
        {
            CargarAvionData(_avionDTO);
        }

        private void CargarAvionData(AvionDTO avion)
        {
            lblID.Text = avion.Id.ToString();
            textBoxDescripcion.Text = avion.Descripcion;
            textBoxCapacidad.Text = avion.Capacidad.ToString();

            if (comboBoxDisponibilidad.Items.Contains(avion.EstadoDisponibilidad))
            {
                comboBoxDisponibilidad.SelectedItem = avion.EstadoDisponibilidad;
            }
            else if (comboBoxDisponibilidad.Items.Count > 0)
            {
                comboBoxDisponibilidad.SelectedIndex = 0;
            }
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

        private async Task GuardarCambiosAsync()
        {
            int id = _avionDTO.Id;

            if (string.IsNullOrWhiteSpace(textBoxDescripcion.Text))
            {
                MessageBox.Show("Ingrese una descripción válida.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxDescripcion.Focus();
                return;
            }

            if (!int.TryParse(textBoxCapacidad.Text.Trim(), out int capacidad) || capacidad <= 0)
            {
                MessageBox.Show("Ingrese una capacidad mayor a 0.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxCapacidad.Focus();
                return;
            }

            // Solo regeneramos asientos si la capacidad cambió respecto al valor inicial
            List<AsientoCreateDTO>? nuevosAsientos = capacidad != _capacidadInicial
                ? GenerarAsientosPorCapacidad(capacidad)
                : null;

            var avionUpdate = new AvionUpdateDTO
            {
                Id = id,
                Descripcion = textBoxDescripcion.Text.Trim(),
                Capacidad = capacidad,
                EstadoDisponibilidad = comboBoxDisponibilidad.SelectedItem?.ToString() ?? "Disponible",
                Asientos = nuevosAsientos
            };

            try
            {
                btnGuardar.Enabled = false;

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

        private void btnVolver_Click(object? sender, EventArgs e)
        {
            this.Close();
        }
    }
}