using Domain.Model;
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

namespace WindowsForms
{
    public partial class AdminUsuariosForm : Form
    {
        // Para reabrir la ventana de Login salir del sistema.
        private readonly MenuPrincipalForm _menuPrincipalForm;

        private readonly HttpClient _httpClient;

        // Constructor: se ejecuta al cargar la ventana
        // Recibe la instancia original de MenuPrincipalForm y cargar el menu ppal al salir
        public AdminUsuariosForm(MenuPrincipalForm menuPrincipalForm)
        {
            InitializeComponent();
            _menuPrincipalForm = menuPrincipalForm;

            // Instanciamos el cliente HTTP apuntando al puerto de tu Web API
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:7099/") // Puerto 7099
            };

            // Llamamos al método asíncrono de carga
            CargarListaUsuariosEnItems();
        }

        // Al ingresar a la ventana
        private async void CargarListaUsuariosEnItems()
        {
            panelListaUsuarios.Controls.Clear();

            try
            {
                // 1. Llama a la Web API mediante un GET HTTP
                var listaUsuarios = await _httpClient.GetFromJsonAsync<List<Usuario>>("api/usuarios");

                if (listaUsuarios != null)
                {
                    // 2. Dibuja las tarjetas recibidas desde la API
                    // Usa la tarjeta genérica UsuarioItemControl.cs
                    foreach (var us in listaUsuarios)
                    {
                        UsuarioItemControl item = new UsuarioItemControl();
                        item.CargarDatos(us);

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

        // Agregar nuevo usuario a la base de datos
        private async void btnNuevoUsuario_Click(object sender, EventArgs e)
        {
            UsuarioAMForm ventanaNuevoEditar = new UsuarioAMForm(this);

            // Para abrir la ventana modal
            if (ventanaNuevoEditar.ShowDialog() == DialogResult.OK)
            {

                Usuario? nuevoUsuario = ventanaNuevoEditar.UsuarioResultado;

                if (nuevoUsuario != null)
                {
                    try
                    {
                        // Envía el usuario como JSON vía HTTP POST a https://localhost:7099/api/usuarios
                        HttpResponseMessage response = await _httpClient.PostAsJsonAsync("api/usuarios", nuevoUsuario);

                        if (response.IsSuccessStatusCode)
                        {
                            MessageBox.Show("Usuario guardado exitosamente en la base de datos.");
                            CargarListaUsuariosEnItems(); // Recarga la lista desde la API (con nuevo usuario incluido)
                        }
                        else
                        {
                            MessageBox.Show($"Error al guardar: {response.ReasonPhrase}");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error de conexión: {ex.Message}");
                    }
                }

            }
        }

        // Evento para Editar: relacionado con el boton Editar de la tarjeta genérica UsuarioItemControl.cs
        // Se ejecuta cuando hacen clic en "Editar" en cualquiera de las tarjetas / filas.
        private async void Item_OnEditarClicked(object? sender, Usuario usuarioAEditar)
        {
            UsuarioAMForm ventanaEditar = new UsuarioAMForm(this, usuarioAEditar);

            if (ventanaEditar.ShowDialog() == DialogResult.OK)
            {
                Usuario? usuarioModificado = ventanaEditar.UsuarioResultado;

                if (usuarioModificado != null)
                {
                    try
                    {
                        // HTTP PUT a api/usuarios/{id}
                        HttpResponseMessage response = await _httpClient.PutAsJsonAsync($"api/usuarios/{usuarioModificado.Id}", usuarioModificado);

                        if (response.IsSuccessStatusCode)
                        {
                            MessageBox.Show("Usuario actualizado con éxito.");
                            CargarListaUsuariosEnItems(); // Recarga la lista desde la API (con usuario editado incluido)
                        }
                        else
                        {
                            MessageBox.Show($"Error al actualizar: {response.ReasonPhrase}");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error de conexión: {ex.Message}");
                    }
                }
            }
        }

        // Evento para Eliminar: relacionado con el boton Eliminar de la tarjeta genérica UsuarioItemControl.cs
        // Se ejecuta cuando hacen clic en "Eliminar" en cualquiera de las tarjetas / filas.
        private async void Item_OnEliminarClicked(object? sender, Usuario usuarioAEliminar)
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
                    // HTTP DELETE a api/usuarios/{id}
                    HttpResponseMessage response = await _httpClient.DeleteAsync($"api/usuarios/{usuarioAEliminar.Id}");

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
