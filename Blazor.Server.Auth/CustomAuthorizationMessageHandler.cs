using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using System.Net.Http.Headers;

namespace Blazor.Server.Auth
    {
        public class CustomAuthorizationMessageHandler : DelegatingHandler
        {

            private readonly ProtectedLocalStorage _localStorage;

            public CustomAuthorizationMessageHandler(ProtectedLocalStorage localStorage)
            {
                _localStorage = localStorage;
            }

            protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
            {
                // El login y el autoregistro son públicos, no necesita token
                if (request.RequestUri != null &&
                    (request.RequestUri.AbsolutePath.Contains("login", StringComparison.OrdinalIgnoreCase) ||
                     request.RequestUri.AbsolutePath.Contains("registro", StringComparison.OrdinalIgnoreCase)))
            {
                return await base.SendAsync(request, cancellationToken);
            }

            try
                {
                    var result = await _localStorage.GetAsync<string>("authToken");
                    if (result.Success && !string.IsNullOrEmpty(result.Value))
                    {
                        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", result.Value);
                    }
                }
                catch
                {
                    // Ignorar errores de prerendering o storage
                }

                return await base.SendAsync(request, cancellationToken);
            }

        }
    }