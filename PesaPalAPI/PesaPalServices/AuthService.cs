using PesaIntegration.DTOs;
using PesaIntegration.Repository;

namespace PesaIntegration.PesaPalServices
{
    public class AuthService 
    {
        private readonly IRepository _authRepository;

        public AuthService(IRepository authRepository)
        {
            _authRepository = authRepository;
        }

        public async Task<PesapalAuthResponse> RequestTokenAsync(string consumerKey, string consumerSecret)
        {
            var request = new PesapalAuthRequest
            {
                ConsumerKey = consumerKey,
                ConsumerSecret = consumerSecret
            };

            return await _authRepository.RequestTokenAsync(request);
        }



    }
}
