namespace PesaIntegration.DTOs
{
    public class RequestDTOs
    {
    }
    public class PesapalAuthRequest
    {
        public string? ConsumerKey { get; set; }
        public string? ConsumerSecret { get; set; }
    }

    public class RegisterIPNRequestDTO
    {
        public string? Url { get; set; }
        public string? IpnNotificationType { get; set; }
    }

    public class SubmitOrderRequestDTO
    {
        public string Id { get; set; }
        public string Currency { get; set; }
        public float Amount { get; set; }
        public string Description { get; set; }
        public string CallbackUrl { get; set; }
        public string CancellationUrl { get; set; }
        public Guid NotificationId { get; set; }
        public BillingAddressDTO BillingAddress { get; set; }
    }

    public class BillingAddressDTO
    {
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }
        public string CountryCode { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Line1 { get; set; }
        public string Line2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
        public string ZipCode { get; set; }
    }
    public class GetTransactionStatusDTO
    {
        public string OrderTrackingId { get; set; }
    }
}
