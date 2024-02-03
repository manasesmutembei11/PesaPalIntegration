using PesaIntegration.DTOs;
using PesaIntegration.Repository;

namespace PesaIntegration.PesaPalServices
{
    public class GetIPNListService
    {
        private readonly IRepository _Repository;

        public GetIPNListService(IRepository Repository)
        {
            _Repository = Repository ?? throw new ArgumentNullException(nameof(Repository));
        }

        public async Task<List<GetIPNListResponseDTO>> GetIPNListAsync(string accessToken)
        {
            return await _Repository.GetIPNListAsync(accessToken);
        }


    }
}
