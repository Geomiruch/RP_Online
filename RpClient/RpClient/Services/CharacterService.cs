using Newtonsoft.Json;
using System.Net.Http.Headers;
using RpClient.DTO;
using RpClient.Tools;

namespace RpClient.Services
{
    public class CharacterService
    {
        public async Task<CharactersDto> GetAllAsync()
        {
            using (HttpClient client = HttpClientHelper.CreateHttpClient())
            {
                string token = null;
                try
                {
                    token = Task.Run(async () => await SecureStorage.Default.GetAsync("jwt_token")).Result;
                }
                catch (Exception ex)
                {
                    throw new Exception($"Error retrieving JWT token: {ex.Message}");
                }

                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                string url = Constants.ServerURL + Constants.CharacterEndpoints.GetAllEndpoint;

                var response = client.GetAsync(url).Result;

                if (response.IsSuccessStatusCode)
                {
                    string responseJson = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<CharactersDto>(responseJson);
                }
                else
                {
                    throw new HttpRequestException($"Запит завершився з помилкою: {response.ReasonPhrase}");
                }
            }
        }
    }
}
