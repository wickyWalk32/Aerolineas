using DTOs;
using Microsoft.Extensions.Configuration;
using System.Configuration;
using WindowsForms.Auth.Services;
using WindowsForms.Auth.Session; // Importamos la sesión

namespace WindowsForms
{
    internal static class Program
    {
        public static IConfiguration Configuration { get; private set; } = null!;

        // Mantenemos una propiedad pública o accedemos directamente a UserSession.HttpClient y UserSession.TokenJwt
        public static HttpClient HttpClient => UserSession.HttpClient;
        public static string? TokenJwt => UserSession.TokenJwt;

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            // 1. Carga de appsettings.json
            Configuration = new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory)
                .AddJsonFile("Configuracion/appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            // 2. Inicializar HttpClient utilizando la librería de autenticación (UserSession)
            string? apiBaseUrl = Configuration["Api:BaseUrl"];
            if (!string.IsNullOrEmpty(apiBaseUrl))
            {
                UserSession.ConfigureClient(apiBaseUrl);
            }
            else
            {
                // Manejar el error si la URL no está configurada
                MessageBox.Show("No se encontró la URL de la API en el archivo de configuración.", "Error de configuración", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // 3. Flujo de Login y redirección según el rol: se utiliza ShowDialog() para validar credenciales y destruye el formulario
            // de login antes de lanzar la ventana principal según el rol.
            using (LoginForm loginForm = new LoginForm())
            {
                if (loginForm.ShowDialog() == DialogResult.OK && loginForm.UsuarioAutenticado != null)
                {
                    UsuarioLoginResultDTO usuarioAutenticado = loginForm.UsuarioAutenticado;

                    if (usuarioAutenticado.Rol?.ToLower() == "admin")
                    {
                        Application.Run(new MenuAdminForm(usuarioAutenticado));
                    }
                    else
                    {
                        Application.Run(new MenuUsuarioBuscarVueloForm(usuarioAutenticado));
                    }
                }
            }
        }
    }
}