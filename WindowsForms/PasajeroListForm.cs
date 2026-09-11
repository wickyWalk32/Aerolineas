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
                // Construye opciones vacías: AppDbContext.OnConfiguring leerá appsettings.json si es necesari

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

        }
    }
}