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
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            Configuration = new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory)
                .AddJsonFile("Configuracion/appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            string? apiBaseUrl = Configuration["Api:BaseUrl"]!;

            HttpClient = new HttpClient
            {
                BaseAddress = new Uri(apiBaseUrl)
            };


            // ejemplo de uso en un winforms
            //var response = await Program.HttpClient.GetAsync("Paises");


            // VENTANA QUE SE ABRE AL INICIAR LA APLICACION
            //Application.Run(new LoginForm());
            //Application.Run(new MenuPrincipalForm());
            System.Windows.Forms.Application.Run(new MenuPrincipalForm());

        }
    }
}