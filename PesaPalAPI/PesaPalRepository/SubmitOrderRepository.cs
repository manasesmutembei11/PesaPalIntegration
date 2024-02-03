using Newtonsoft.Json;
using PesaIntegration.DTOs;
using System.Net.Http.Headers;
using System.Text;

namespace PesaIntegration.Repository
{
    public class SubmitOrderRepository
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseUrl;

        public SubmitOrderRepository(HttpClient httpClient, string baseUrl)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
            _baseUrl = baseUrl ?? throw new ArgumentNullException(nameof(baseUrl));
        }

        public async Task<SubmitOrderResponseDTO> SubmitOrderRequestAsync(string accessToken, SubmitOrderRequestDTO request)
        {
            var url = $"{_baseUrl}/api/Transactions/SubmitOrderRequest";

            try
            {
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

                var jsonRequest = JsonConvert.SerializeObject(request);
                var content = new StringContent(jsonRequest, Encoding.UTF8, "application/json");

                var response = await _httpClient.PostAsync(url, content);

                if (response.IsSuccessStatusCode)
                {
                    var jsonResponse = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<SubmitOrderResponseDTO>(jsonResponse);
                }
                else
                {
                    var jsonResponse = await response.Content.ReadAsStringAsync();
                    // Handle error response
                    Console.WriteLine($"Error response: {jsonResponse}");
                    return new SubmitOrderResponseDTO();
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
