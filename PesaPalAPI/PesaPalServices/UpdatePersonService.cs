
using PesaIntegration.PesaPalServices; 
using PesaIntegration.Repository;

namespace PesaPalAPI.PesaPalServices
{
    public class UpdatePersonService
    {
        private readonly IService _service; // Use camelCase for private fields
        private readonly IRepository _repository;

        public UpdatePersonService(IService service, IRepository repository)
        {
            _service = service;
            _repository = repository;
        }

        public async Task UpdatePersonStatusOnPayment(string orderTrackingId)
        {
            // Assuming you have a method in PesaPalService to get payment status
            var paymentStatus = await _service.GetTransactionStatusAsync(orderTrackingId);

            if (paymentStatus == PaymentStatus.Success) // Adjust this based on your PesaPalService
            {
                // Retrieve the person based on orderTrackingId or any identifier
                var person = _repository.GetPersonByOrderTrackingId(orderTrackingId);

                if (person != null && person.Status == PersonStatus.New)
                {
                    // Update the person status to Confirmed
                    person.Status = PersonStatus.Confirmed;
                    _repository.UpdatePerson(person);
                }
            }
        }
    }
}
