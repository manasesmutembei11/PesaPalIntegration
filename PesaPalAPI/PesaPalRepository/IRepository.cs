using PesaIntegration.DTOs;

namespace PesaIntegration.Repository
{
    public interface IRepository
    {
        Task<PesapalAuthResponse> RequestTokenAsync(PesapalAuthRequest request);
        Task<RegisterIPNResponseDTO> RegisterIPNUrlAsync(RegisterIPNRequestDTO request);
        Task<List<GetIPNListResponseDTO>> GetIPNListAsync(string accessToken);
        Task<SubmitOrderResponseDTO> SubmitOrderRequestAsync(string accessToken, SubmitOrderRequestDTO request);
        Task<TransactionStatusDTO> GetTransactionStatusAsync(string accessToken, string orderTrackingId);
    }
}
