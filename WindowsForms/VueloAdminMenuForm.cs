using DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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

        // Al ingresar a la ventana o recargar
        public async void CargarListaVuelosEnItems()
        {
            panelListaVuelos.Controls.Clear();

            try
            {
                var listaVuelos = await Program.HttpClient.GetFromJsonAsync<List<VueloCargaDTO>>("vuelos");

                if (listaVuelos != null)
                {
                    foreach (VueloCargaDTO unVuelo in listaVuelos)
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
        }

        // Abrir VueloDetalle para crear un nuevo vuelo
        private void btnNuevoVuelo_Click(object sender, EventArgs e)
        {
            VueloDetalleForm vueloDetalleForm = new VueloDetalleForm(this);
            this.Hide();
            vueloDetalleForm.ShowDialog();
        }

        // Abrir VueloDetalle pasando el vuelo seleccionado para editarlo
        private void Item_OnEditarClicked(object sender, VueloUpdateDTO vueloUpdateDto)
        {
            VueloDetalleForm vueloDetalleForm = new VueloDetalleForm(this, vueloUpdateDto);
            this.Hide();
            vueloDetalleForm.ShowDialog();
        }

        // Eliminar vuelo seleccionado
        private async void Item_OnEliminarClicked(object sender, VueloDeleteDTO vueloDeleteDto)
        {
            var confirmacion = MessageBox.Show(
                $"¿Está seguro de que desea eliminar el vuelo de {vueloDeleteDto.CiudadOrigenNombre } a " +
                $"{vueloDeleteDto.CiudadDestinoNombre} del día {vueloDeleteDto.FechaHoraVuelo}, aerolínea " +
                $"{vueloDeleteDto.Aerolinea}?",
                "Confirmar eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (confirmacion == DialogResult.Yes)
            {
                try
                {
                    // HTTP DELETE a /vuelos/{id}
                    HttpResponseMessage response = await Program.HttpClient.DeleteAsync($"/vuelos/{vueloDeleteDto.Id}");

                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Vuelo eliminado exitosamente.");
                        CargarListaVuelosEnItems(); // Recarga la lista desde la API (con vuelo eliminado sin incluir)
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
