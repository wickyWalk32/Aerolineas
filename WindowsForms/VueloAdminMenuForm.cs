using DTOs;
using System.Net.Http.Json;

namespace WindowsForms
{
    public partial class VueloAdminMenuForm : Form
    {
        private readonly MenuAdminForm _menuAdminForm;

        public VueloAdminMenuForm(MenuAdminForm menuAdminForm)
        {
            InitializeComponent();
            _menuAdminForm = menuAdminForm;
            CargarListaVuelosEnItems();
        }

        public async void CargarListaVuelosEnItems()
        {
            panelListaVuelos.SuspendLayout();
            panelListaVuelos.Controls.Clear();

            try
            {
                var listaVuelos = await Program.HttpClient.GetFromJsonAsync<List<VueloDTO>>("vuelos");

                if (listaVuelos != null)
                {
                    foreach (VueloDTO unVuelo in listaVuelos)
                    {
                        VueloItemControl item = new VueloItemControl();
                        item.CargarDatos(unVuelo);

                        item.OnEditarClicked += Item_OnEditarClicked;
                        item.OnEliminarClicked += Item_OnEliminarClicked;

                        panelListaVuelos.Controls.Add(item);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al conectar con la Web API: {ex.Message}");
            }
            finally
            {
                panelListaVuelos.ResumeLayout();
            }
        }

        private void btnNuevoVuelo_Click(object sender, EventArgs e)
        {
            VueloDetalleForm vueloDetalleForm = new VueloDetalleForm(this);
            this.Hide();
            vueloDetalleForm.ShowDialog();
            this.Show();
            CargarListaVuelosEnItems();
        }

        private void Item_OnEditarClicked(object? sender, VueloUpdateDTO vueloUpdateDto)
        {
            VueloDetalleForm vueloDetalleForm = new VueloDetalleForm(this, vueloUpdateDto);
            this.Hide();
            vueloDetalleForm.ShowDialog();
            this.Show();
            CargarListaVuelosEnItems();
        }

        private async void Item_OnEliminarClicked(object? sender, VueloDeleteDTO vueloDeleteDto)
        {
            var confirmacion = MessageBox.Show(
                $"¿Está seguro de que desea eliminar el vuelo desde " +
                $"{vueloDeleteDto.CiudadOrigenNombre} a {vueloDeleteDto.CiudadDestinoNombre} " +
                $"del día: {vueloDeleteDto.FechaHoraVuelo:dd/MM/yyyy}, " +
                $"hora: {vueloDeleteDto.FechaHoraVuelo:HH:mm}, " +
                $"aerolínea: {vueloDeleteDto.Aerolinea}?",
                "Confirmar eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (confirmacion == DialogResult.Yes)
            {
                try
                {
                    HttpResponseMessage response = await Program.HttpClient.DeleteAsync($"/vuelos/{vueloDeleteDto.Id}");

                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Vuelo eliminado exitosamente.");
                        CargarListaVuelosEnItems();
                    }
                    else
                    {
                        MessageBox.Show($"Error al eliminar: {response.ReasonPhrase}");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error de conexión: {ex.Message}");
                }
            }
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            _menuAdminForm.Show();
            this.Close();
        }
    }
}