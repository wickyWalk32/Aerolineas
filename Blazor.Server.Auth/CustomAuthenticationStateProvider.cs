using Blazor.Server.Auth.Helpers;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Blazor.Server.Auth
{
    // Custom Provider: maneja el estado de autenticación leyendo el token desde el ProtectedLocalStorage e informando a Blazor
    // de las altas o bajas de sesión.

    public class CustomAuthenticationStateProvider : AuthenticationStateProvider
    {
        private readonly ProtectedLocalStorage _localStorage;
        private readonly ClaimsPrincipal _anonymous = new(new ClaimsIdentity());

        public CustomAuthenticationStateProvider(ProtectedLocalStorage localStorage)
        {
            _localStorage = localStorage;
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            try
            {
                var result = await _localStorage.GetAsync<string>("authToken");
                var token = result.Success ? result.Value : null;

                if (string.IsNullOrWhiteSpace(token))
                {
                    return new AuthenticationState(_anonymous);
                }

                var claims = JwtParser.ParseClaimsFromJwt(token);

                // IMPORTANTE: Especificar 'jwt' como authenticationType para que IsAuthenticated sea true
                var identity = new ClaimsIdentity(claims, "jwt");
                var user = new ClaimsPrincipal(identity);

                return new AuthenticationState(user);
            }
            catch
            {
                // Durante el Prerendering en Blazor Server, la llamada a JS Interop/LocalStorage puede fallar.
                // Devuelve anónimo de manera segura hasta que la app sea interactiva.
                return new AuthenticationState(_anonymous);
            }
        }

        public void NotificarUsuarioAutenticado(string token)
        {
            var claims = JwtParser.ParseClaimsFromJwt(token);
            var identity = new ClaimsIdentity(claims, "jwt");
            var user = new ClaimsPrincipal(identity);

            var authState = Task.FromResult(new AuthenticationState(user));
            NotifyAuthenticationStateChanged(authState);
        }

        public void NotificarUsuarioCierreSesion()
        {
            var authState = Task.FromResult(new AuthenticationState(_anonymous));
            NotifyAuthenticationStateChanged(authState);
        }
    }
}