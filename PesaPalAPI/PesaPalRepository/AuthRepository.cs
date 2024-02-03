using Newtonsoft.Json;
using PesaIntegration.DTOs;
using System.Net.Http.Headers;
using System.Text;

namespace PesaIntegration.Repository
{
    public class AuthRepository
    {
       
        private readonly HttpClient _httpClient;
        private readonly string _authApiBaseUrl;

        public AuthRepository(HttpClient httpClient, string authApiBaseUrl)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
            _authApiBaseUrl = authApiBaseUrl ?? throw new ArgumentNullException(nameof(authApiBaseUrl));
        }

        public async Task<PesapalAuthResponse> RequestTokenAsync(PesapalAuthRequest request)
        {
            try
            {
                // Construct the API endpoint URL
                var authApiUrl = $"{_authApiBaseUrl}/api/Auth/RequestToken";

                // Convert request object to JSON
                var jsonRequest = JsonConvert.SerializeObject(request);
                var requestContent = new StringContent(jsonRequest, Encoding.UTF8, "application/json");

                // Make the HTTP POST request to the Pesapal Auth API
                var response = await _httpClient.PostAsync(authApiUrl, requestContent);

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

        

    }
}
