using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Microsoft.Extensions.DependencyInjection;

namespace Blazor.Server.Auth
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddBlazorServerAuth(this IServiceCollection services)
        {
            services.AddAuthorizationCore();
            services.AddCascadingAuthenticationState();
            services.AddScoped<ProtectedLocalStorage>();

            // Registrar el Handler del HttpClient
            services.AddTransient<CustomAuthorizationMessageHandler>();

            services.AddScoped<AuthenticationStateProvider, CustomAuthenticationStateProvider>();
            services.AddScoped<CustomAuthenticationStateProvider>(sp =>
                (CustomAuthenticationStateProvider)sp.GetRequiredService<AuthenticationStateProvider>());

            return services;
        }
    }
}
