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
using DTOs;

namespace WindowsForms
{
    public partial class ServicioAdminMenuForm : Form
    {

        private MenuAdminForm _menuAdminForm;

        public ServicioAdminMenuForm(MenuAdminForm menuAdminForm)
        {
            InitializeComponent();
            _menuAdminForm = menuAdminForm;
            CargarListaServiciosEnItems();
        }

        public async void CargarListaServiciosEnItems() 
        {
            panelListaServicios.Controls.Clear();

            try 
            {
                var listaServicios = await Program.HttpClient.GetFromJsonAsync<List<ServicioCargaDTO>>("/servicios");

                if (listaServicios != null) 
                {
                    foreach (ServicioCargaDTO unServicio in listaServicios) 
                    {
                        ServicioItemControl item = new ServicioItemControl();
                        item.CargarDatos(unServicio);

                        item.OnEditarClicked += Item_OnEditarClicked;
                        item.OnEliminarClicked += Item_OnEliminarClicked;

                        panelListaServicios.Controls.Add(item);
                    }
                }
            } 
            catch (Exception ex)
            {
                MessageBox.Show($"Error al conectar con la Web API: {ex.Message}");
            }
        }

        // Abrir ServicioDetalle para crear un nuevo servicio
        private void btnNuevoServicio_Click(object sender, EventArgs e) 
        {
            ServicioDetalleForm servicioDetalleForm = new ServicioDetalleForm(this);
            this.Hide();
            servicioDetalleForm.ShowDialog();
        }

        // Abrir ServicioDetalle pasando el servicio seleccionado para editarlo
        private void Item_OnEditarClicked(object sender, ServicioUpdateDTO servicioUpdateDto) 
        {
            ServicioDetalleForm servicioDetalleForm = new ServicioDetalleForm(this, servicioUpdateDto);
            this.Hide();
            servicioDetalleForm.ShowDialog();
        }

        // Eliminar servicio seleccionado
        private async void Item_OnEliminarClicked(object sender, ServicioDeleteDTO servicioDeleteDto) 
        {
            var confirmacion = MessageBox.Show(
                $"¿Está seguro de que desea eliminar el servicio {servicioDeleteDto.Nombre}?",
                "Confirmar eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (confirmacion == DialogResult.Yes)
            {
                try
                {
                    // HTTP DELETE a /servicios/{id}
                    HttpResponseMessage response = await Program.HttpClient.DeleteAsync($"/servicios/{servicioDeleteDto.Id}");

                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Servicio eliminado exitosamente.");
                        CargarListaServiciosEnItems(); // Recarga la lista desde la API (con servicio eliminado sin incluir)
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
