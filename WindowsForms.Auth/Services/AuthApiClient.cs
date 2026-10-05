using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http.Json;
using DTOs;
using WindowsForms.Auth.Session;

namespace WindowsForms.Auth.Services
{
    public class AuthApiClient
    {
        private readonly string _loginEndpoint;

        public AuthApiClient(string loginEndpoint = "usuarios/login")
        {
            _loginEndpoint = loginEndpoint;
        }

        public async Task<UsuarioLoginResultDTO?> LoginAsync(string email, string password)
        {
            try
            {
                var credentials = new UsuarioLoginRequestDTO { Email = email, Contrasenia = password };
                var response = await UserSession.HttpClient.PostAsJsonAsync(_loginEndpoint, credentials);

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<UsuarioLoginResultDTO>();
                }
            }
            catch (Exception)
            {
                // Aquí se puede registrar el error de red
                throw;
            }

            return null;
        }
    }
}