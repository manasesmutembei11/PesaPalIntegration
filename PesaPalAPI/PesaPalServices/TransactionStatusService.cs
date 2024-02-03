using PesaIntegration.DTOs;
using PesaIntegration.Repository;

namespace PesaIntegration.PesaPalServices
{
    public class TransactionStatusService
    {
        private readonly IRepository _Repository;

        public TransactionStatusService(IRepository Repository)
        {
            _Repository = Repository ?? throw new ArgumentNullException(nameof(Repository));
        }

        public async Task<TransactionStatusDTO> GetTransactionStatusAsync(string accessToken, string orderTrackingId)
        {
            return await _Repository.GetTransactionStatusAsync(accessToken, orderTrackingId);
        }


    }
}
