using DTOs;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsForms
{
    public partial class AvionListForm : Form
    {
        
        public AvionListForm()
        {
            InitializeComponent();
            AsignarEventos();
        }

        private void AsignarEventos()
        {
            btnCargar.Click += async (s, e) => await CargarAvionesAsync();
            btnVolver.Click += btnVolver_Click;
        }

        private async void AvionListForm_Load(object sender, EventArgs e)
        {
            ConfigurarGrilla();
            await CargarAvionesAsync();
        }

        private void ConfigurarGrilla()
        {
            // Ajustar visualmente las columnas de la grilla
            dataGridViewAviones.AutoGenerateColumns = true;
        }

        private async Task CargarAvionesAsync()
        {
            try
            {
                btnCargar.Enabled = false;

                // Consulta al endpoint GET /aviones
                List<AvionDTO>? listaAviones = await Program.HttpClient.GetFromJsonAsync<List<AvionDTO>>("aviones");

                if (listaAviones != null)
                {
                    dataGridViewAviones.DataSource = null; // Limpiar origen previo
                    dataGridViewAviones.DataSource = listaAviones;

                    // Personalizar cabeceras de columnas (opcional)
                    if (dataGridViewAviones.Columns["Id"] != null)
                        dataGridViewAviones.Columns["Id"].HeaderText = "ID Avión";

                    if (dataGridViewAviones.Columns["Descripcion"] != null)
                        dataGridViewAviones.Columns["Descripcion"].HeaderText = "Descripción";

                    if (dataGridViewAviones.Columns["Capacidad"] != null)
                        dataGridViewAviones.Columns["Capacidad"].HeaderText = "Capacidad (Cantidad de Pasajeros)";

                    if (dataGridViewAviones.Columns["EstadoDisponibilidad"] != null)
                        dataGridViewAviones.Columns["EstadoDisponibilidad"].HeaderText = "Estado";
                }
            }
            catch (Exception)
            {
                MessageBox.Show($"Error al cargar la lista de aviones.", "Error de conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnCargar.Enabled = true;
            }
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close(); // Cierra esta ventana modal de forma limpia
        }
        
    }
}