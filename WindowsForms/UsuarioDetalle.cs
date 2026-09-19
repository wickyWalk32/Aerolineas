using DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Runtime.InteropServices.JavaScript.JSType;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace WindowsForms
{
    // Ventana para el alta y modificación de usuarios (reutilizable entre ambos)
    public partial class UsuarioDetalle : Form
    {
        public UsuarioDTO? UsuarioResultado { get; private set; }
        private bool _esEdicion = false;

        // Recibo y guardo la ventana de Administrar usuarios para abrirla al cerrar el alta / modif de usu
        private readonly UsuarioAdminMenu _usuarioAdminMenu;

        /* Dos constructores: depende cual se llama, es la ventana que se carga: nuevo / editar. */

        // Constructor para nuevo usuario
        public UsuarioDetalle(UsuarioAdminMenu usuarioAdminMenu)
        {
            InitializeComponent();
            lblTituloNuevoEditarUsuario.Text = "Nuevo Usuario";
            lblIdUsuario.Text = "";
            _usuarioAdminMenu = usuarioAdminMenu;
        }

        // Constructor con parámetro (para EDITAR usuario)
        public UsuarioDetalle(UsuarioAdminMenu usuarioAdminMenu, UsuarioDTO usuarioAEditar) : this(usuarioAdminMenu)
        {
            _usuarioAdminMenu = usuarioAdminMenu;
            _esEdicion = true;
            lblTituloNuevoEditarUsuario.Text = "Editar Usuario";
            UsuarioResultado = usuarioAEditar;

            // Cargamos los datos actuales del usuario elegido en la pantalla anterior en las cajas de texto
            lblIdUsuario.Text = usuarioAEditar.Id.ToString();
            textBoxNombre.Text = usuarioAEditar.Nombre;
            textBoxApellido.Text = usuarioAEditar.Apellido;
            textBoxEmail.Text = usuarioAEditar.Email;
            comboBoxRol.SelectedItem = usuarioAEditar.Rol;
        }


        // Guardar nuevo usuario
        private async void btnGuardar_Click(object sender, EventArgs e)
        {
            // 1. Validaciones básicas
            if (string.IsNullOrWhiteSpace(textBoxNombre.Text) ||
                string.IsNullOrWhiteSpace(textBoxApellido.Text) ||
                string.IsNullOrWhiteSpace(textBoxEmail.Text) ||
                 comboBoxRol.SelectedItem == null )                
            {
                MessageBox.Show("Por favor complete los campos obligatorios.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            if (!_esEdicion)
            {
                UsuarioCreateDTO nuevoUsuario = new UsuarioCreateDTO
                {
                    Nombre = textBoxNombre.Text,
                    Apellido = textBoxApellido.Text,
                    Email = textBoxEmail.Text,
                    ContraseniaHash=textBoxContrasenia.Text,
                    Rol = comboBoxRol.SelectedItem.ToString()
                };
                try
                {
                    var response = await Program.HttpClient.PostAsJsonAsync<UsuarioCreateDTO>("usuarios", nuevoUsuario);
                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Cambios guardados exitosamente.","Success");
                        ClearForm();
                        _usuarioAdminMenu.CargarListaUsuariosEnItems();
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
            else
            {
                UsuarioUpdateDTO usuarioModificar = new UsuarioUpdateDTO
                {
                    Id = Convert.ToInt32(lblIdUsuario.Text),
                    Nombre = textBoxNombre.Text,
                    Apellido = textBoxApellido.Text,
                    Email = textBoxEmail.Text,
                    ContraseniaHash = textBoxContrasenia.Text,
                    Rol = comboBoxRol.SelectedItem.ToString(),
                };
                try
                {
                    var response = await Program.HttpClient.PutAsJsonAsync<UsuarioUpdateDTO>(
                        $"usuarios/{Convert.ToInt32(lblIdUsuario.Text)}", usuarioModificar);
                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Cambios guardados exitosamente.", "Success");
                        _usuarioAdminMenu.CargarListaUsuariosEnItems();
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

        public void ClearForm()
        {
            textBoxNombre.Clear();
            textBoxApellido.Clear();
            textBoxEmail.Clear();
            textBoxContrasenia.Clear();
            comboBoxRol.SelectedIndex = -1;
        }


        private void btnVolver_Click(object sender, EventArgs e)
        {
            _usuarioAdminMenu.Show();
            this.Close();
        }

    }
}
