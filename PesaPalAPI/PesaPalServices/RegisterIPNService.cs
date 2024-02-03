using PesaIntegration.DTOs;
using PesaIntegration.Repository;

namespace PesaIntegration.PesaPalServices
{
    public class RegisterIPNService 
    {
        private readonly IRepository _Repository;

        public RegisterIPNService(IRepository Repository)
        {
            _Repository = Repository ?? throw new ArgumentNullException(nameof(Repository));
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

    }
}
