using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blazor.Server.Auth
{
    // Esta clase estática de extensión limpia la configuración dentro del Program.cs del proyecto principal.

    public static class DependencyInjection
    {
        public static IServiceCollection AddBlazorServerAuth(this IServiceCollection services)
        {
            services.AddAuthorizationCore();
            services.AddCascadingAuthenticationState();
            services.AddScoped<ProtectedLocalStorage>();

            services.AddScoped<AuthenticationStateProvider, CustomAuthenticationStateProvider>();
            services.AddScoped<CustomAuthenticationStateProvider>(sp =>
                (CustomAuthenticationStateProvider)sp.GetRequiredService<AuthenticationStateProvider>());

            return services;
        }
    }
}
