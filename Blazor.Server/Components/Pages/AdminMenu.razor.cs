using Blazor.Server.Auth;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Microsoft.JSInterop;
using System.Threading.Tasks;

namespace Blazor.Server.Components.Pages
{
    public partial class AdminMenu
    {
        [Inject] public NavigationManager Navigation { get; set; } = default!;
        [Inject] public ProtectedLocalStorage LocalStorage { get; set; } = default!;
        [Inject] public CustomAuthenticationStateProvider AuthStateProvider { get; set; } = default!;
        [Inject] public IJSRuntime JSRuntime { get; set; } = default!;

        // VARIABLE PARA EL @ref
        private ElementReference botonAdministrarVuelos;

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                // Fuerza un pequeño delay opcional para asegurar que el DOM esté completamente renderizado e interactivo
                await Task.Delay(50);

                try
                {
                    // Aplica el foco de manera nativa
                    await botonAdministrarVuelos.FocusAsync();
                    StateHasChanged();
                }
                catch
                {
                    // Fallback por si el renderizado inicial se cruza con el ciclo de vida del prerender
                }
            }
        }

        protected async Task CerrarSesion()
        {
            await LocalStorage.DeleteAsync("authToken");
            AuthStateProvider.NotificarUsuarioCierreSesion();
            Navigation.NavigateTo("/login");
        }

        protected void IrAGestionUsuarios() => Navigation.NavigateTo("/admin/usuarios");
        protected void IrAGestionVuelos() => Navigation.NavigateTo("/admin/vuelos");
        protected void IrAGestionCiudades() => Navigation.NavigateTo("/admin/ciudades");
        protected void IrAGestionAviones() => Navigation.NavigateTo("/admin/aviones");
        protected void IrAGestionServicios() => Navigation.NavigateTo("/admin/servicios");
        protected void IrAGestionPasajeros() => Navigation.NavigateTo("/admin/pasajeros");
    }
}