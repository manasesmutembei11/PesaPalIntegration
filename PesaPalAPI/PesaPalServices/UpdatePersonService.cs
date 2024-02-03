using PesaIntegration.PesaPalServices;
using PesaIntegration.Repository;
namespace PesaPalAPI.PesaPalServices
{
    public class UpdatePersonService
    {
        private readonly IService _Service; // Your Pesapal integration service
        private readonly IRepository _Repository; // Your repository for managing people

        public UpdatePersonService(IService Service, IRepository Repository)
        {
            _Service = Service;
            _Repository = Repository;
        }

        public async Task UpdatePersonStatusOnPayment(string orderTrackingId)
        {
            // Assuming you have a method in PesapalService to get payment status
            var paymentStatus = await _Service.GetTransactionStatusAsync(orderTrackingId);

            if (paymentStatus == PaymentStatus.Success) // Adjust this based on your PesapalService
            {
                // Retrieve the person based on orderTrackingId or any identifier
                var person = _Repository.GetPersonByOrderTrackingId(orderTrackingId);

                if (person != null && person.Status == PersonStatus.New)
                {
                    // Update the person status to Confirmed
                    person.Status = PersonStatus.Confirmed;
                    _Repository.UpdatePerson(person);
                }
            }
        }


    }
}
