using Blazor.Server.Auth;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using System.Threading.Tasks;

namespace Blazor.Server.Components.Pages
{
    public partial class AdminMenu
    {
        [Inject] public NavigationManager Navigation { get; set; } = default!;
        [Inject] public ProtectedLocalStorage LocalStorage { get; set; } = default!;
        [Inject] public CustomAuthenticationStateProvider AuthStateProvider { get; set; } = default!;

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