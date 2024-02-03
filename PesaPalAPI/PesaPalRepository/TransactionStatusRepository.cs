using Newtonsoft.Json;
using PesaIntegration.DTOs;
using System.Net.Http.Headers;

namespace PesaIntegration.PesaPalRepository
{
    public class TransactionStatusRepository
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseUrl;

        public TransactionStatusRepository(HttpClient httpClient, string baseUrl)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
            _baseUrl = baseUrl ?? throw new ArgumentNullException(nameof(baseUrl));
        }

        public async Task<TransactionStatusDTO> GetTransactionStatusAsync(string accessToken, string orderTrackingId)
        {
            var url = $"{_baseUrl}/api/Transactions/GetTransactionStatus?orderTrackingId={orderTrackingId}";

            try
            {
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

                var response = await _httpClient.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    var jsonResponse = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<TransactionStatusDTO>(jsonResponse);
                }
                else
                {
                    var jsonResponse = await response.Content.ReadAsStringAsync();
                    // Handle error response
                    Console.WriteLine($"Error response: {jsonResponse}");
                    return new TransactionStatusDTO();
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
