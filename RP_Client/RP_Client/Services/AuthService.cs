using Newtonsoft.Json;
using RP_Client.Contracts.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RP_Client.Services
{
    public class AuthService
    {
        private readonly HttpClient _httpClient;

        public AuthService()
        {
            var handler = new HttpClientHandler
            {
                ServerCertificateCustomValidationCallback = (message, cert, chain, errors) =>
                {
                    return true; // Довіряти будь-якому сертифікату
                }
            };

            _httpClient = new HttpClient(handler)
            {
                Timeout = TimeSpan.FromSeconds(30)
            };
        }

        public async Task<SignInResponse> SendSignInRequestAsync(string email, string password)
        {
            var authRequest = new SignInRequest
            {
                Email = email,
                Password = password
            };

            var json = JsonConvert.SerializeObject(authRequest);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            try
            {
                var response = await _httpClient.PostAsync(Constants.ServerURL + Constants.UserEndpoints.LoginEndpoint, content);

                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<SignInResponse>(responseContent);
                }
                else
                {
                    throw new Exception($"Error: {response.StatusCode}, {response.ReasonPhrase}");
                }
            }
            catch (TaskCanceledException ex)
            {
                throw new Exception("The operation was canceled. This might be due to a timeout or a network issue.", ex);
            }
        }

        public async Task<HttpResponseMessage> SendSignUpRequestAsync(string email, string username, string password)
        {
            var registrationRequest = new SignUpRequest
            {
                Email = email,
                Username = username,
                Password = password
            };

            var json = JsonConvert.SerializeObject(registrationRequest);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            try
            {
                var response = await _httpClient.PostAsync(Constants.ServerURL + Constants.UserEndpoints.RegisterEndpoint, content);

                if (response.IsSuccessStatusCode)
                {
                    return response;
                }
                else
                {
                    var errorContent = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Error: {response.StatusCode}, {response.ReasonPhrase}, Details: {errorContent}");
                }
            }
            catch (TaskCanceledException ex)
            {
                throw new Exception("The operation was canceled. This might be due to a timeout or a network issue.", ex);
            }
        }
    }
}
