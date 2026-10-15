using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTOs;
using System.Net.Http.Json;
using WindowsForms.Auth.Services;
using WindowsForms.Auth.Session;

namespace WindowsForms
{
    public partial class LoginForm : Form
    {
        
        // Propiedad pública que Program.cs necesita para saber el rol y datos del usuario logueado
        public UsuarioLoginResultDTO? UsuarioAutenticado { get; private set; }

        private readonly AuthApiClient _authApiClient;

        public LoginForm()
        {
            InitializeComponent();

            // Configuramos la URL base de la WebApi
            UserSession.ConfigureClient("https://localhost:7099/");

            _authApiClient = new AuthApiClient();

            // Configura el botón de ingresar como el botón por defecto del formulario
            this.AcceptButton = btnIngresar;

            /* 
             * <<< INGRESO RÁPIDO >>>
             * 
             * Comentar y descomentar, según se quiera ingresar como admin o como usuario comun:
             * 
             */


            /* Usuario de tipo 'usuario' aniadido a la bd: */

            //textBoxEmail.Text = "usu@email.com";
            //textBoxContrasenia.Text = "usu";

            /* Usuario de tipo 'admin' aniadido a la bd mediante el DbContext y el EnsureCrated(): */

            textBoxEmail.Text = "admin@email.com";
            textBoxContrasenia.Text = "admin";

        }

        private async void btnIngresar_Click(object sender, EventArgs e)
        {
            string email = textBoxEmail.Text.Trim();
            string contrasenia = textBoxContrasenia.Text.Trim();

            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(contrasenia))
            {
                MessageBox.Show("Por favor, ingrese email y contraseña.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Deshabilitar botón para evitar doble clic mientras procesa
            btnIngresar.Enabled = false;

            try
            {
                
                var resultado = await _authApiClient.LoginAsync(email, contrasenia);

                if (resultado != null && !string.IsNullOrEmpty(resultado.Token))
                {
                    // 1. Guardamos el token en la sesión centralizada de la librería
                    UserSession.SetToken(resultado.Token);

                    // 2. Asignamos el resultado a la propiedad para que Program.cs lo reciba (rol, nombre, etc.)
                    UsuarioAutenticado = resultado;

                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Credenciales incorrectas o usuario no autorizado.", "Error de Autenticación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                // Para seguir viendo el error en la consola de Visual Studio en el desarrollo
                System.Diagnostics.Debug.WriteLine($"Error técnico interno: {ex.Message}");

                // Mensaje para el usuario
                MessageBox.Show(
                    "Fallo al conectar, disculpe las molestias. ¡Inténtelo más tarde!",
                    "Error de conexión",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
            finally
            {
                btnIngresar.Enabled = true;
            }

        }

        private void btnAutoregistroUsuario_Click(object sender, EventArgs e)
        {

            // 1. Escondemos el formulario de login actual
            this.Hide();

            // 2. Abrimos el registro como diálogo pasando la instancia del login
            using (var usuarioDetalleForm = new UsuarioDetalleForm(this))
            {
                usuarioDetalleForm.ShowDialog();
            }

            // 3. Al volver del registro, volvemos a mostrar el login
            textBoxContrasenia.Clear();
            this.Show();
        }

        // Botones para probar el ingreso en etapa de desarrollo.
        
        private void btnCargarDatosAdmin_Click(object sender, EventArgs e)
        {
            textBoxEmail.Text = "admin@email.com";
            textBoxContrasenia.Text = "admin";
        }

        private void btnCargarDatosUsuario_Click(object sender, EventArgs e)
        {
            textBoxEmail.Text = "usu@email.com";
            textBoxContrasenia.Text = "usu";
        }

        // Cierra la aplicación por completo y libera todos los procesos.
        private void btnSalirSistema_Click(object sender, EventArgs e)
        {

            DialogResult resultado = MessageBox.Show(
                "¿Está seguro de que desea salir del sistema?",
                "Confirmar salida",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (resultado == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

    }
}
