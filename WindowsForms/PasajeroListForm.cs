using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Data;
using DTOs;
using Microsoft.EntityFrameworkCore;
using Domain;
using Application.Services;

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
                var options = new DbContextOptionsBuilder<AppDbContext>().Options;
                using var context = new AppDbContext(options);
                var repo = new PasajeroRepository(context);
                var service = new PasajeroService(repo);

                var lista = await service.GetAllAsync();

                // Ordena por Apellido, luego Nombre
                var ordenada = lista.OrderBy(p => p.Apellido).ThenBy(p => p.Nombre).ToList();

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