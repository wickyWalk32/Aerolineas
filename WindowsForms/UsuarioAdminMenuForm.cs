using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http.Json; // Necesario para GetFromJsonAsync
using DTOs;

namespace WindowsForms
{
    public partial class UsuarioAdminMenuForm : Form
    {
        // Para reabrir la ventana de Login salir del sistema.
        private readonly MenuAdminForm _menuPrincipalForm;
        /*private readonly UsuarioDetalleForm _usuarioDetalle;

        private readonly HttpClient _httpClient;*/

        // Constructor: se ejecuta al cargar la ventana
        // Recibe la instancia original de MenuPrincipalForm y cargar el menu ppal al salir
        public UsuarioAdminMenuForm(MenuAdminForm menuPrincipalForm)
        {
            InitializeComponent();
            _menuPrincipalForm = menuPrincipalForm;

            // Llamamos al método asíncrono de carga
            CargarListaUsuariosEnItems();
        }

        // Al ingresar a la ventana
        public async void CargarListaUsuariosEnItems()
        {
            panelListaUsuarios.Controls.Clear();

            try
            {
                // 1. Llama a la Web API mediante un GET HTTP
                var listaUsuarios = await Program.HttpClient.GetFromJsonAsync<List<UsuarioDTO>>("/usuarios");

                if (listaUsuarios != null)
                {
                    // 2. Dibuja las tarjetas recibidas desde la API
                    // Usa la tarjeta genérica UsuarioItemControl.cs
                    foreach (var user in listaUsuarios)
                    {
                        UsuarioItemControl item = new UsuarioItemControl();
                        item.CargarDatos(user);

                        item.OnEditarClicked += Item_OnEditarClicked;
                        item.OnEliminarClicked += Item_OnEliminarClicked;

                        panelListaUsuarios.Controls.Add(item);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al conectar con la Web API: {ex.Message}");
            }
        }

        // Abrir UsuarioDetalle
        private void btnNuevoUsuario_Click(object sender, EventArgs e)
        {
            UsuarioDetalleForm usuarioDetalle = new UsuarioDetalleForm(this);
            this.Hide();
            usuarioDetalle.Show();
        }

        // Evento para Editar: relacionado con el boton Editar de la tarjeta genérica UsuarioItemControl.cs
        // Se ejecuta cuando hacen clic en "Editar" en cualquiera de las tarjetas / filas.
        private void Item_OnEditarClicked(object? sender, UsuarioDTO usuarioAEditar)
        {
            UsuarioDetalleForm usuarioDetalleForm = new UsuarioDetalleForm(this, usuarioAEditar);
            this.Hide();
            usuarioDetalleForm.Show();
        }

        // Evento para Eliminar: relacionado con el boton Eliminar de la tarjeta genérica UsuarioItemControl.cs
        // Se ejecuta cuando hacen clic en "Eliminar" en cualquiera de las tarjetas / filas.
        private async void Item_OnEliminarClicked(object? sender, UsuarioDTO usuarioAEliminar)
        {
            var confirmacion = MessageBox.Show(
                $"¿Está seguro de que desea eliminar a {usuarioAEliminar.Nombre} {usuarioAEliminar.Apellido}?",
                "Confirmar eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (confirmacion == DialogResult.Yes)
            {
                try
                {
                    // HTTP DELETE a /usuarios/{id}
                    HttpResponseMessage response = await Program.HttpClient.DeleteAsync($"/usuarios/{usuarioAEliminar.Id}");
                    
                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Usuario eliminado exitosamente.");
                        CargarListaUsuariosEnItems(); // Recarga la lista desde la API (con usuario eliminado sin incluir)
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

            // Cerramos la pantalla actual de Administrar Usuarios
            this.Close();
        }

    }
}
