using Newtonsoft.Json;
using PesaIntegration.DTOs;
using PesaIntegration.Repository;
using System.Net.Http.Headers;
using System.Text;

namespace PesaPalAPI.PesaPalRepository
{
    public class PesaPalRepository : IRepository
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseUrl;

        public PesaPalRepository(HttpClient httpClient, string baseUrl)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
            _baseUrl = baseUrl ?? throw new ArgumentNullException(nameof(baseUrl));
        }

        public async Task<PesapalAuthResponse> RequestTokenAsync(PesapalAuthRequest request)
        {
            try
            {
                var Url = $"{_baseUrl}/api/PesaPal/RequestToken";

                // Convert request object to JSON
                var jsonRequest = JsonConvert.SerializeObject(request);
                var requestContent = new StringContent(jsonRequest, Encoding.UTF8, "application/json");

                // Make the HTTP POST request to the Pesapal Auth API
                var response = await _httpClient.PostAsync(Url, requestContent);

                if (response.IsSuccessStatusCode)
                {
                    // Parse the JSON response into PesapalAuthResponse DTO
                    var jsonResponse = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<PesapalAuthResponse>(jsonResponse);
                }
                else
                {
                    // Handle error response
                    var jsonResponse = await response.Content.ReadAsStringAsync();
                    var errorResponse = JsonConvert.DeserializeObject<PesapalAuthResponse>(jsonResponse);
                    return errorResponse;
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions
                Console.WriteLine($"An error occurred: {ex.Message}");
                throw;
            }
        }

        public async Task<RegisterIPNResponseDTO> RegisterIPNUrlAsync(RegisterIPNRequestDTO request)
        {
            var url = $"{_baseUrl}/api/PesaPal/RegisterIPN";
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
                    var errorResponse = JsonConvert.DeserializeObject<RegisterIPNResponseDTO>(jsonResponse);
                    return errorResponse;
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions
                Console.WriteLine($"An error occurred: {ex.Message}");
                throw;
            }
        }

        public async Task<List<GetIPNListResponseDTO>> GetIPNListAsync(string accessToken)
        {
            var url = $"{_baseUrl}/api/PesaPal/GetIpnList";

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


        public async Task<TransactionStatusDTO> GetTransactionStatusAsync(string accessToken, string orderTrackingId)
        {
            var url = $"{_baseUrl}/api/PesaPal/GetTransactionStatus?orderTrackingId={orderTrackingId}";

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
