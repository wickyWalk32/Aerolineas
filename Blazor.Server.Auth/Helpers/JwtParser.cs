using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text.Json;

namespace Blazor.Server.Auth.Helpers
{
    // Helper de Tokens: esta clase parsea los claims contenidos en el JWT para que Blazor pueda interpretarlos.

    public static class JwtParser
    {
        public static IEnumerable<Claim> ParseClaimsFromJwt(string jwt)
        {
            var claims = new List<Claim>();
            var payload = jwt.Split('.')[1];
            var jsonBytes = ParseBase64WithoutPadding(payload);
            var keyValuePairs = JsonSerializer.Deserialize<Dictionary<string, object>>(jsonBytes);

            if (keyValuePairs != null)
            {
                // Buscar el rol por 'role', 'roles' o la URL completa de ClaimTypes.Role
                keyValuePairs.TryGetValue("role", out var roles);
                if (roles == null) keyValuePairs.TryGetValue("roles", out roles);
                if (roles == null) keyValuePairs.TryGetValue(ClaimTypes.Role, out roles);

                if (roles != null)
                {
                    if (roles.ToString()!.StartsWith("["))
                    {
                        var parsedRoles = JsonSerializer.Deserialize<string[]>(roles.ToString()!);
                        foreach (var parsedRole in parsedRoles!)
                        {
                            claims.Add(new Claim(ClaimTypes.Role, parsedRole));
                        }
                    }
                    else
                    {
                        claims.Add(new Claim(ClaimTypes.Role, roles.ToString()!));
                    }

                    // Limpiar las claves para evitar duplicados
                    keyValuePairs.Remove("role");
                    keyValuePairs.Remove("roles");
                    keyValuePairs.Remove(ClaimTypes.Role);
                }

                // Mapear el resto de claims (Name/Email/Sub, etc.)
                claims.AddRange(keyValuePairs.Select(kvp => new Claim(kvp.Key, kvp.Value.ToString()!)));
            }

            return claims;
        }

        private static byte[] ParseBase64WithoutPadding(string base64)
        {
            switch (base64.Length % 4)
            {
                case 2: base64 += "=="; break;
                case 3: base64 += "="; break;
            }
            return Convert.FromBase64String(base64);
        }
    }
}