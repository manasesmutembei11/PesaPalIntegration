using PesaIntegration.DTOs;
using PesaIntegration.Repository;

namespace PesaIntegration.PesaPalServices
{
    public class SubmitOrderService
    {
        private readonly IRepository _Repository;

        public SubmitOrderService(IRepository Repository)
        {
            _Repository = Repository ?? throw new ArgumentNullException(nameof(Repository));
        }

        public async Task<SubmitOrderResponseDTO> SubmitOrderRequestAsync(string accessToken, SubmitOrderRequestDTO request)
        {
            return await _Repository.SubmitOrderRequestAsync(accessToken, request);
        }

    }
}
