using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RP_App.Contracts.Register;

public class RegistrationService
{
    private readonly HttpClient _httpClient;

    public RegistrationService()
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

    public async Task<HttpResponseMessage> RegisterAsync(string email, string username, string password)
    {
        var registrationRequest = new RegistrationRequest
        {
            Email = email,
            Username = username,
            Password = password
        };

        var json = JsonConvert.SerializeObject(registrationRequest);
        var content = new StringContent(json, Encoding.UTF8, "application/json");

        try
        {
            var response = await _httpClient.PostAsync("https://192.168.1.104:7128/api/users/register", content);

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
