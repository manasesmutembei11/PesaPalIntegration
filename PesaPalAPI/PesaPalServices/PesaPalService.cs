using PesaIntegration.DTOs;
using PesaIntegration.PesaPalServices;
using PesaIntegration.Repository;

namespace PesaPalAPI.PesaPalServices
{
    public class PesaPalService : IService
    {
        private readonly IRepository _Repository;

        public PesaPalService(IRepository Repository)
        {
            _Repository = Repository ?? throw new ArgumentNullException(nameof(Repository));
        }

        public async Task<PesapalAuthResponse> RequestTokenAsync(string consumerKey, string consumerSecret)
        {
            var request = new PesapalAuthRequest
            {
                ConsumerKey = consumerKey,
                ConsumerSecret = consumerSecret
            };

            return await _Repository.RequestTokenAsync(request);
        }

        public async Task<RegisterIPNResponseDTO> RegisterIPNUrlAsync(string url, string ipnNotificationType, string accessToken)
        {
            var request = new RegisterIPNRequestDTO
            {
                Url = url,
                IpnNotificationType = ipnNotificationType
            };

            return await _Repository.RegisterIPNUrlAsync(request);
        }

        public async Task<List<GetIPNListResponseDTO>> GetIPNListAsync(string accessToken)
        {
            return await _Repository.GetIPNListAsync(accessToken);
        }

        public async Task<SubmitOrderResponseDTO> SubmitOrderRequestAsync(string accessToken, SubmitOrderRequestDTO request)
        {
            return await _Repository.SubmitOrderRequestAsync(accessToken, request);
        }

        public async Task<TransactionStatusDTO> GetTransactionStatusAsync(string accessToken, string orderTrackingId)
        {
            return await _Repository.GetTransactionStatusAsync(accessToken, orderTrackingId);
        }
    }
}
