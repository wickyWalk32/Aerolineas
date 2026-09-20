using DTOs;
using Microsoft.Extensions.Configuration;
using System.Configuration;

namespace WindowsForms
{
    internal static class Program
    {
        public static IConfiguration Configuration { get; private set; } = null!;
        public static HttpClient HttpClient { get; private set; } = null!;

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

            // 2. Inicializar HttpClient antes de usarlo en cualquier formulario
            string? apiBaseUrl = Configuration["Api:BaseUrl"];
            if (!string.IsNullOrEmpty(apiBaseUrl))
            {
                HttpClient = new HttpClient
                {
                    BaseAddress = new Uri(apiBaseUrl)
                };
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