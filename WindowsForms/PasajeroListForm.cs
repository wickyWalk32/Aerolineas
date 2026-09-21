using DTOs;
using System;
using System.Linq;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsForms
{
    public partial class PasajeroListForm : Form
    {
        public PasajeroListForm()
        {
            InitializeComponent();
        }

        private async void PasajeroListForm_Load(object sender, EventArgs e)
        {
            await CargarPasajerosAsync();
        }

        private async Task CargarPasajerosAsync()
        {
            try
            {
                // Construye opciones vacías: AppDbContext.OnConfiguring leerá appsettings.json si es necesario
                var response = await Program.HttpClient.GetFromJsonAsync<List<PasajeroDTO>>("pasajeros");
                
                // Ordena por Apellido, luego Nombre
                var ordenada = response?.OrderBy(p => p.Apellido).ThenBy(p => p.Nombre).ToList();

                // Bind con un BindingSource para facilitar futuras operaciones
                var bs = new BindingSource { DataSource = ordenada };
                dgvPasajeros.DataSource = bs;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar pasajeros: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void BtnRefrescar_Click(object sender, EventArgs e)
        {
            await CargarPasajerosAsync();
        }

        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvPasajeros_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            var row = dgvPasajeros.Rows[e.RowIndex];

            // Como las columnas se autogeneran del DTO, extraemos el objeto directamente 
            // usando DataBoundItem para evitar cualquier error de nombres de celdas:
            if (row.DataBoundItem is PasajeroDTO pasajeroSeleccionado)
            {
                PasajeroUpdateDTO pasajero = new PasajeroUpdateDTO
                {
                    Id = pasajeroSeleccionado.Id,
                    Tipo = pasajeroSeleccionado.Tipo,
                    Nombre = pasajeroSeleccionado.Nombre,
                    Apellido = pasajeroSeleccionado.Apellido,
                    TipoDocumento = pasajeroSeleccionado.TipoDocumento,
                    NroDocumento = pasajeroSeleccionado.NroDocumento
                };

                // Modificar Pasajero
                var pasajeroDetalle = new PasajeroDetalleForm(pasajero);
                pasajeroDetalle.Show();
            }
        }

    }
}