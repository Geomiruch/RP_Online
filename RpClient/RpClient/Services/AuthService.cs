using Newtonsoft.Json;
using RpClient.Contracts.Auth;
using RpClient.Tools;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace RpClient.Services
{
    public class AuthService
    {
        public async Task<SignInResponse> SendSignInRequestAsync(string email, string password)
        {
            using (HttpClient httpClient = HttpClientHelper.CreateHttpClient())
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
                    var response = await httpClient.PostAsync(Constants.ServerURL + Constants.UserEndpoints.LoginEndpoint, content);

                    if (response.IsSuccessStatusCode)
                    {
                        var responseContent = await response.Content.ReadAsStringAsync();
                        var signInResponse = JsonConvert.DeserializeObject<SignInResponse>(responseContent);

                        await Task.Run(async () => await SecureStorage.SetAsync("jwt_token", signInResponse.Token));

                        return signInResponse;
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
        }

        public async Task<HttpResponseMessage> SendSignUpRequestAsync(string email, string username, string password)
        {
            using (HttpClient httpClient = HttpClientHelper.CreateHttpClient())
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
                    var response = await httpClient.PostAsync(Constants.ServerURL + Constants.UserEndpoints.RegisterEndpoint, content);

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

        public string GetUserRoleFromToken()
        {
            var handler = new JwtSecurityTokenHandler();
            var jwtToken = handler.ReadJwtToken(Task.Run(async () => await SecureStorage.Default.GetAsync("jwt_token")).Result);

            var roleClaim = jwtToken.Claims.FirstOrDefault(claim => claim.Type == ClaimTypes.Role);

            return roleClaim?.Value;
        }
    }
}
