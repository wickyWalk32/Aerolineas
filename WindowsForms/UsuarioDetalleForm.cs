using DTOs;
using System.Net.Http.Json;

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

        // Constructor para nuevo usuario (autoregistro usuario)
        public UsuarioDetalleForm(LoginForm loginForm)
        {
            InitializeComponent();
            lblTituloNuevoEditarUsuario.Text = "Registrarse en el sistema";
            lblId.Text = "";
            lblIdUsuario.Text = "";
            _loginForm = loginForm;

            // Ocultar elementos que no debe ver el usuario no registrado
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
            lblId.Text = "";
            lblIdUsuario.Text = "";
            _usuarioAdminMenuForm = usuarioAdminMenuForm;

            var roles = new List<string> { "-- Seleccione Rol --", "admin", "usuario" };
            comboBoxRol.DataSource = roles;
            comboBoxRol.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        // Constructor para editar (editado por admin)
        public UsuarioDetalleForm(UsuarioAdminMenuForm usuarioAdminMenuForm, UsuarioDTO usuarioAEditar) : this(usuarioAdminMenuForm)
        {
            _usuarioAdminMenuForm = usuarioAdminMenuForm;
            _esEdicion = true;
            lblTituloNuevoEditarUsuario.Text = "Editar Usuario";
            UsuarioResultado = usuarioAEditar;

            var roles = new List<string> { "-- Seleccione Rol --", "admin", "usuario" };
            comboBoxRol.DataSource = roles;
            comboBoxRol.DropDownStyle = ComboBoxStyle.DropDownList;

            lblIdUsuario.Text = usuarioAEditar.Id.ToString();
            textBoxNombre.Text = usuarioAEditar.Nombre;
            textBoxApellido.Text = usuarioAEditar.Apellido;
            textBoxEmail.Text = usuarioAEditar.Email;
            comboBoxRol.SelectedItem = usuarioAEditar.Rol;
        }

        private async void btnGuardar_Click(object sender, EventArgs e)
        {
            bool esAutoRegistro = _loginForm != null;

            bool camposComunesValidos = !string.IsNullOrWhiteSpace(textBoxNombre.Text) &&
                                        !string.IsNullOrWhiteSpace(textBoxApellido.Text) &&
                                        !string.IsNullOrWhiteSpace(textBoxEmail.Text);

            if (esAutoRegistro)
            {
                if (!camposComunesValidos || string.IsNullOrWhiteSpace(textBoxContrasenia.Text))
                {
                    MessageBox.Show(
                        "Por favor complete nombre, apellido, email y contraseña.",
                        "Atención",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );
                    return;
                }
            }
            else if (!_esEdicion)
            {
                bool rolValidoAdmin = comboBoxRol.SelectedIndex > 0 && comboBoxRol.SelectedItem != null;
                if (!camposComunesValidos || !rolValidoAdmin)
                {
                    MessageBox.Show(
                        "Por favor complete los campos obligatorios y seleccione un rol válido.",
                        "Atención",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );
                    return;
                }
            }
            else
            {
                bool rolValidoEdicion = comboBoxRol.SelectedIndex > 0 && comboBoxRol.SelectedItem != null;
                if (!camposComunesValidos || !rolValidoEdicion)
                {
                    MessageBox.Show(
                        "Por favor complete los campos obligatorios y seleccione un rol válido.",
                        "Atención",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );
                    return;
                }
            }

            if (!_esEdicion)
            {
                try
                {
                    HttpResponseMessage response;

                    if (esAutoRegistro)
                    {
                        var dtoRegistro = new UsuarioRegistroDTO
                        {
                            Nombre = textBoxNombre.Text.Trim(),
                            Apellido = textBoxApellido.Text.Trim(),
                            Email = textBoxEmail.Text.Trim(),
                            Contrasenia = textBoxContrasenia.Text
                        };

                        response = await Program.HttpClient.PostAsJsonAsync("registro", dtoRegistro);
                    }
                    else
                    {
                        string rolAsignado = comboBoxRol.SelectedItem?.ToString() ?? "usuario";

                        var nuevoUsuario = new UsuarioCreateDTO
                        {
                            Nombre = textBoxNombre.Text.Trim(),
                            Apellido = textBoxApellido.Text.Trim(),
                            Email = textBoxEmail.Text.Trim(),
                            Contrasenia = textBoxContrasenia.Text,
                            Rol = rolAsignado
                        };

                        response = await Program.HttpClient.PostAsJsonAsync("usuarios", nuevoUsuario);
                    }

                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show(
                            esAutoRegistro ? "Cuenta creada exitosamente. Ya podés iniciar sesión." : "Usuario registrado exitosamente.",
                            "Éxito",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information
                        );

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
                        string detalleError = await response.Content.ReadAsStringAsync();
                        MessageBox.Show(
                            string.IsNullOrWhiteSpace(detalleError)
                                ? $"Error al guardar: {response.ReasonPhrase}"
                                : $"Error al guardar: {detalleError}",
                            "Error",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error
                        );
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
                    Nombre = textBoxNombre.Text.Trim(),
                    Apellido = textBoxApellido.Text.Trim(),
                    Email = textBoxEmail.Text.Trim(),
                    Contrasenia = textBoxContrasenia.Text,
                    Rol = comboBoxRol.SelectedItem?.ToString() ?? "usuario",
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
                        string detalleError = await response.Content.ReadAsStringAsync();
                        MessageBox.Show(
                            string.IsNullOrWhiteSpace(detalleError)
                                ? $"Error al guardar: {response.ReasonPhrase}"
                                : $"Error al guardar: {detalleError}",
                            "Error",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error
                        );
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

            if (comboBoxRol.Items.Count > 0)
            {
                comboBoxRol.SelectedIndex = 0;
            }
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
