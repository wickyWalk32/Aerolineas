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

namespace WindowsForms
{
    public partial class LoginForm : Form
    {
        public UsuarioLoginResultDTO? UsuarioAutenticado { get; private set; }

        public LoginForm()
        {
            InitializeComponent();

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

            /* Usuario de tipo 'admin' aniadido a la bd: */

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

            try
            {
                /*using (var httpClient = new HttpClient { BaseAddress = new Uri("https://localhost:7099/") })
                {
                    UsuarioLoginRequestDTO usuarioLoginRequestDto = new UsuarioLoginRequestDTO
                    {
                        Email = email,
                        Contrasenia = contrasenia
                    };

                    HttpResponseMessage response = await httpClient.PostAsJsonAsync("/usuarios/login", usuarioLoginRequestDto);

                    // Leemos la respuesta como UsuarioLoginResultDTO (a resultado llega un DTO de Usuario)
                    var resultado = await response.Content.ReadFromJsonAsync<UsuarioLoginResultDTO>();

                    if (response.IsSuccessStatusCode && resultado != null && resultado.Exitoso)
                    {
                        this.UsuarioAutenticado = resultado;
                        this.DialogResult = DialogResult.OK;
                        this.Close(); // Cierra y destruye la ventana de Login
                    }
                    else
                    {
                        string mensajeError = resultado?.Mensaje ?? "Acceso denegado.";
                        MessageBox.Show(mensajeError, "Error de Autenticación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }*/

                // Utilizamos el HttpClient global configurado en Program.cs

                UsuarioLoginRequestDTO usuarioLoginRequestDto = new UsuarioLoginRequestDTO
                {
                    Email = email,
                    Contrasenia = contrasenia
                };

                HttpResponseMessage response = await Program.HttpClient.PostAsJsonAsync("/usuarios/login", usuarioLoginRequestDto);

                // Leemos la respuesta como UsuarioLoginResultDTO
                var resultado = await response.Content.ReadFromJsonAsync<UsuarioLoginResultDTO>();

                if (response.IsSuccessStatusCode && resultado != null && resultado.Exitoso)
                {
                    // === GUARDAMOS EL TOKEN JWT Y CONFIGURAMOS EL CLIENTE HTTP ===
                    if (!string.IsNullOrEmpty(resultado.Token))
                    {
                        Program.TokenJwt = resultado.Token;
                        Program.HttpClient.DefaultRequestHeaders.Authorization =
                            new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", Program.TokenJwt);
                    }

                    this.UsuarioAutenticado = resultado;
                    this.DialogResult = DialogResult.OK;
                    this.Close(); // Cierra y destruye la ventana de Login
                }
                else
                {
                    string mensajeError = resultado?.Mensaje ?? "Acceso denegado.";
                    MessageBox.Show(mensajeError, "Error de Autenticación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error de conexión con la Web API: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

    }
}
