using Newtonsoft.Json;
using PesaIntegration.DTOs;
using System.Net.Http.Headers;
using System.Text;

namespace PesaIntegration.Repository
{
    public class RegisterIPNRepository
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseUrl;

        public RegisterIPNRepository(HttpClient httpClient, string baseUrl)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
            _baseUrl = baseUrl ?? throw new ArgumentNullException(nameof(baseUrl));
        }

        public async Task<RegisterIPNResponseDTO> RegisterIPNUrlAsync(RegisterIPNRequestDTO request)
        {
            var url = $"{_baseUrl}/api/URLSetup/RegisterIPN";
            var accessToken = "YOUR_ACCESS_TOKEN"; // Replace with actual access token

            try
            {
                var requestContent = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

                var response = await _httpClient.PostAsync(url, requestContent);

                if (response.IsSuccessStatusCode)
                {
                    var jsonResponse = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<RegisterIPNResponseDTO>(jsonResponse);
                }
                else
                {
                    var jsonResponse = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<RegisterIPNResponseDTO>(jsonResponse);
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions
                Console.WriteLine($"An error occurred: {ex.Message}");
                throw;
            }
        }

    }
}
