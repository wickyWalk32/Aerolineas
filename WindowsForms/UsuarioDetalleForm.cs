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
    // Ventana para el autoregistro y el alta y modificación de usuarios realizada por el admin (reutilizable)
    public partial class UsuarioDetalleForm : Form
    {
        
        // Recibo y guardo la ventana del Login, para volver luego de registrar un nuevo usuario.
        private readonly LoginForm? _loginForm;

        // Recibo y guardo la ventana de Administrar usuarios para abrirla al cerrar el alta / modificacion de usuario.
        private readonly UsuarioAdminMenuForm? _usuarioAdminMenuForm;
        private bool _esEdicion = false;
        public UsuarioDTO? UsuarioResultado { get; private set; }
        

        /* Tres constructores: depende cual se llama, es la ventana que se carga: registrarse / nuevo usuario / editar usuario. */

        // Constructor para nuevo usuario (autoregistro usuario)

        public UsuarioDetalleForm(LoginForm loginForm)
        {
            InitializeComponent();
            lblTituloNuevoEditarUsuario.Text = "Registrarse en el sistema";
            lblIdUsuario.Text = "";
            _loginForm = loginForm;

            // --- OCULTAR ELEMENTOS QUE NO DEBE VER EL USUARIO NO REGISTRADO ---
            lblId.Visible = false;
            lblIdUsuario.Visible = false;
            lblRol.Visible = false;
            comboBoxRol.Visible = false;

        }

        // Constructor para nuevo usuario (creado por admin)

        public UsuarioDetalleForm(UsuarioAdminMenuForm usuarioAdminMenuForm)
        {
            InitializeComponent();
            lblTituloNuevoEditarUsuario.Text = "Nuevo Usuario";
            lblIdUsuario.Text = "";
            _usuarioAdminMenuForm = usuarioAdminMenuForm;
        }

        // Constructor para editar (editado por admin)
        public UsuarioDetalleForm(UsuarioAdminMenuForm usuarioAdminMenuForm, UsuarioDTO usuarioAEditar) : this(usuarioAdminMenuForm)
        {
            _usuarioAdminMenuForm = usuarioAdminMenuForm;
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
            
            // 1. Validaciones básicas según el origen
            bool camposComunesValidos = !string.IsNullOrWhiteSpace(textBoxNombre.Text) &&
                                        !string.IsNullOrWhiteSpace(textBoxApellido.Text) &&
                                        !string.IsNullOrWhiteSpace(textBoxEmail.Text);

            // Si es Admin, exigimos también que el ComboBox tenga un rol seleccionado
            if (_usuarioAdminMenuForm != null && (!camposComunesValidos || comboBoxRol.SelectedItem == null))
            {
                MessageBox.Show("Por favor complete los campos obligatorios.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Si es autoregistro, solo validamos los campos comunes
            if (_loginForm != null && !camposComunesValidos)
            {
                MessageBox.Show("Por favor complete los campos obligatorios.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!_esEdicion)
            {
                // Si viene del login setea rol como "usuario". Si viene del alta/edicion del admin, lo que elija el admin.
                string rolAsignado = "usuario"; // Valor por defecto seguro

                if (_loginForm != null)
                {
                    rolAsignado = "usuario";
                }
                else if (comboBoxRol.SelectedItem != null)
                {
                    rolAsignado = comboBoxRol.SelectedItem.ToString() ?? "usuario";
                }

                UsuarioCreateDTO nuevoUsuario = new UsuarioCreateDTO
                {
                    Nombre = textBoxNombre.Text,
                    Apellido = textBoxApellido.Text,
                    Email = textBoxEmail.Text,
                    Contrasenia = textBoxContrasenia.Text,
                    Rol = rolAsignado
                };

                try
                {
                    var response = await Program.HttpClient.PostAsJsonAsync<UsuarioCreateDTO>("usuarios", nuevoUsuario);

                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Usuario registrado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        if (_usuarioAdminMenuForm != null)
                        {
                            ClearForm();
                            _usuarioAdminMenuForm.CargarListaUsuariosEnItems();
                        }
                        else if (_loginForm != null)
                        {
                            this.Close();
                        }
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
            else if(_esEdicion)
            {
                UsuarioUpdateDTO usuarioModificar = new UsuarioUpdateDTO
                {
                    Id = Convert.ToInt32(lblIdUsuario.Text),
                    Nombre = textBoxNombre.Text,
                    Apellido = textBoxApellido.Text,
                    Email = textBoxEmail.Text,
                    Contrasenia = textBoxContrasenia.Text,
                    Rol = comboBoxRol.SelectedItem.ToString(),
                };

                try
                {
                    var response = await Program.HttpClient.PutAsJsonAsync<UsuarioUpdateDTO>(
                        $"usuarios/{Convert.ToInt32(lblIdUsuario.Text)}", usuarioModificar);

                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Cambios guardados exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        
                        if (_usuarioAdminMenuForm != null)
                        {
                            _usuarioAdminMenuForm.CargarListaUsuariosEnItems();
                        }
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
            if (_loginForm != null)
            {
                this.Close();
            }
            else if (_usuarioAdminMenuForm != null)
            {
                _usuarioAdminMenuForm.Show();
                this.Close();
            }
        }

    }
}
