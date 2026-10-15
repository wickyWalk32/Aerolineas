using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http.Headers;

namespace WindowsForms.Auth.Session
{
    public static class UserSession
    {
        public static string TokenJwt { get; private set; } = string.Empty;
        public static HttpClient HttpClient { get; } = new HttpClient();

        public static void ConfigureClient(string baseAddress)
        {
            if (HttpClient.BaseAddress == null)
            {
                HttpClient.BaseAddress = new Uri(baseAddress);
            }
        }

        public static void SetToken(string token)
        {
            TokenJwt = token;
            if (!string.IsNullOrEmpty(token))
            {
                HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            }
            else
            {
                HttpClient.DefaultRequestHeaders.Authorization = null;
            }
        }

        public static void Logout()
        {
            SetToken(string.Empty);
        }
    }
}