using DTOs;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Microsoft.JSInterop;
using System.Net.Http.Json;
using Blazor.Server.Auth; // Para consumir el proveedor

namespace Blazor.Server.Components.Pages    // NombreProyecto.SubcarpetaComponents.SubcarpetaPages
{
    public partial class Login              // "partial" class porque trabaja en conjunto con "Login.razor"
    {
        [Inject] public HttpClient Http { get; set; } = default!;
        [Inject] public NavigationManager Navigation { get; set; } = default!;
        [Inject] public ProtectedLocalStorage LocalStorage { get; set; } = default!;
        [Inject] public IJSRuntime JSRuntime { get; set; } = default!; // Para usar JavaScript
        [Inject] public CustomAuthenticationStateProvider AuthStateProvider { get; set; } = default!; // Para Tokens JWT

        protected UsuarioLoginRequestDTO loginModel = new();
        protected string? mensajeError;
        protected bool cargando = false;
        protected InputText? inputEmail;

        // Se ejecutar al cargar la página.
        protected override void OnInitialized()
        {
            loginModel.Email = "admin@email.com";
            loginModel.Contrasenia = "admin";
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {

            if (firstRender)
            {
                // Importamos el archivo como un módulo ES6
                await using var moduloJs = await JSRuntime.InvokeAsync<IJSObjectReference>("import", "./js/login.js");

                // Invocamos la función exportada de forma segura
                await moduloJs.InvokeVoidAsync("ponerFoco", "email");
            }

            /*
            // Pone el foco sobre el campo email usando la API nativa de Blazor
            if (firstRender && inputEmail?.Element != null)
            {
                await inputEmail.Element.Value.FocusAsync();
            }
            */

        }

        // Botón Ingresar.
        protected async Task ProcesarLogin()
        {
            cargando = true;
            mensajeError = null;

            try
            {
                var response = await Http.PostAsJsonAsync("usuarios/login", loginModel);

                if (response.IsSuccessStatusCode)
                {
                    var resultado = await response.Content.ReadFromJsonAsync<UsuarioLoginResultDTO>();

                    if (resultado != null && resultado.Exitoso && !string.IsNullOrEmpty(resultado.Token))
                    {
                        // 1. Guarda el Token JWT en el almacenamiento encriptado del navegador
                        await LocalStorage.SetAsync("authToken", resultado.Token);

                        // 2. Notificar al AuthStateProvider
                        AuthStateProvider.NotificarUsuarioAutenticado(resultado.Token);

                        // 3. Redirección según el Rol retornado en el DTO al menú de admin o al menú de usuario
                        RedirigirSegunRol(resultado.Rol);
                    }
                    else
                    {
                        mensajeError = resultado?.Mensaje ?? "No se pudo procesar la respuesta del servidor.";
                    }
                }
                else if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                {
                    mensajeError = "Credenciales inválidas. Verifique su correo y contraseña.";
                }
                else
                {
                    mensajeError = "Ocurrió un error al intentar comunicarse con el servidor.";
                }
            }
            catch (Exception)
            {
                mensajeError = "Error de conexión con el servicio de autenticación.";
            }
            finally
            {
                cargando = false;
            }
        }

        private void RedirigirSegunRol(string? rol)
        {
            // Comparación simple por nombre de rol
            if (!string.IsNullOrEmpty(rol) && rol.Equals("admin", StringComparison.OrdinalIgnoreCase))
            {
                Navigation.NavigateTo("/admin/menu");
            }
            else if (!string.IsNullOrEmpty(rol) && rol.Equals("usuario", StringComparison.OrdinalIgnoreCase))
            {
                Navigation.NavigateTo("/menu");
            }
        }

        // Botón Registrarse.
        protected void IrARegistro()
        {
            Navigation.NavigateTo("/usuarios");
        }

    }
}