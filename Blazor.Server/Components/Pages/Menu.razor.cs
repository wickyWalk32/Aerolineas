using Blazor.Server.Auth;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;

namespace Blazor.Server.Components.Pages
{
    public partial class Menu
    {
        [Inject] public NavigationManager Navigation { get; set; } = default!;
        [Inject] public ProtectedLocalStorage LocalStorage { get; set; } = default!;
        [Inject] public CustomAuthenticationStateProvider AuthStateProvider { get; set; } = default!;

        protected async Task CerrarSesion()
        {
            // 1. Remover el token del almacenamiento local
            await LocalStorage.DeleteAsync("authToken");

            // 2. Notificar al proveedor de autenticación
            AuthStateProvider.NotificarUsuarioCierreSesion();

            // 3. Redirigir al Login
            Navigation.NavigateTo("/login");
        }
    }
}