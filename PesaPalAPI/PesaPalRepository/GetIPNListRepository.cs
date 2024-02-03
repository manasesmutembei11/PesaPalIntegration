using Newtonsoft.Json;
using PesaIntegration.DTOs;
using System.Net.Http.Headers;

namespace PesaIntegration.Repository
{
    public class GetIPNListRepository
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseUrl;

        public GetIPNListRepository(HttpClient httpClient, string baseUrl)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
            _baseUrl = baseUrl ?? throw new ArgumentNullException(nameof(baseUrl));
        }

        public async Task<List<GetIPNListResponseDTO>> GetIPNListAsync(string accessToken)
        {
            var url = $"{_baseUrl}/api/URLSetup/GetIpnList";

            try
            {
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

                var response = await _httpClient.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    var jsonResponse = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<List<GetIPNListResponseDTO>>(jsonResponse);
                }
                else
                {
                    var jsonResponse = await response.Content.ReadAsStringAsync();
                    // Handle error response
                    Console.WriteLine($"Error response: {jsonResponse}");
                    return new List<GetIPNListResponseDTO>();
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
