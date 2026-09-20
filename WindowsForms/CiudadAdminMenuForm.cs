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
    public partial class CiudadAdminMenuForm : Form
    {

        private readonly MenuAdminForm _menuPrincipalForm;


        public CiudadAdminMenuForm(MenuAdminForm menuPrincipalForm)
        {
            InitializeComponent();
            _menuPrincipalForm = menuPrincipalForm;
            CargarListaCiudadesEnItems();
        }

        // Al ingresar a la ventana o recargar
        public async void CargarListaCiudadesEnItems()
        {
            panelListaCiudades.Controls.Clear();

            try
            {
                // 1. Llama a la Web API mediante un GET HTTP
                var listaCiudades = await Program.HttpClient.GetFromJsonAsync<List<CiudadDTO>>("/ciudades");

                if (listaCiudades != null)
                {
                    // 2. Dibuja las tarjetas recibidas desde la API
                    // Usa la tarjeta genérica CiudadItemControl.cs
                    foreach (var unaCiudad in listaCiudades)
                    {
                        CiudadItemControl item = new CiudadItemControl();
                        item.CargarDatos(unaCiudad);

                        item.OnEditarClicked += Item_OnEditarClicked;
                        item.OnEliminarClicked += Item_OnEliminarClicked;

                        panelListaCiudades.Controls.Add(item);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al conectar con la Web API: {ex.Message}");
            }
        }

        // Abrir CiudadDetalle para crear una nueva ciudad
        private void btnNuevaCiudad_Click(object sender, EventArgs e)
        {
            CiudadDetalleForm ciudadDetalle = new CiudadDetalleForm(this);
            this.Hide();
            ciudadDetalle.Show();
        }

        // Abrir CiudadDetalle pasando la ciudad seleccionada para editar
        private void Item_OnEditarClicked(object? sender, CiudadDTO ciudadAEditar)
        {
            CiudadDetalleForm ciudadDetalle = new CiudadDetalleForm(this, ciudadAEditar);
            this.Hide();
            ciudadDetalle.Show();
        }

        // Eliminar ciudad seleccionada
        private async void Item_OnEliminarClicked(object? sender, CiudadDTO ciudadAEliminar)
        {
            var confirmacion = MessageBox.Show(
                $"¿Está seguro de que desea eliminar la ciudad de {ciudadAEliminar.Nombre}?",
                "Confirmar eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (confirmacion == DialogResult.Yes)
            {
                try
                {
                    // HTTP DELETE a /ciudades/{id}
                    HttpResponseMessage response = await Program.HttpClient.DeleteAsync($"/ciudades/{ciudadAEliminar.Id}");

                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Ciudad eliminada exitosamente.");
                        CargarListaCiudadesEnItems(); // Recarga la lista desde la API (con ciudad eliminada sin incluir)
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
            // Volvemos a mostrar el menú que teníamos oculto
            _menuPrincipalForm.Show();

            // Cerramos la pantalla actual de Administrar Ciudades
            this.Close();
        }

    }
}
