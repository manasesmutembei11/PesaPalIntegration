namespace PesaIntegration.DTOs
{
    public class ResponseDTOs
    {
    }

    public class PesapalErrorObject
    {
        public string? Type { get; set; }
        public string? Code { get; set; }
        public string? Message { get; set; }
    }


    public class PesapalAuthResponse
    {
        public string? Token { get; set; }
        public string? ExpiryDate { get; set; }
        public PesapalErrorObject? Error { get; set; }
        public string? Status { get; set; }
        public string? Message { get; set; }
    }

    public class RegisterIPNResponseDTO
    {
        public string? Url { get; set; }
        public string? CreatedDate { get; set; }
        public string? IpnId { get; set; }
        public int? Error { get; set; }
        public string? Status { get; set; }
    }

    public class GetIPNListResponseDTO
    {
        public string Url { get; set; }
        public string CreatedDate { get; set; }
        public string IpnId { get; set; }
        public int? Error { get; set; }
        public string Status { get; set; }
    }

    public class SubmitOrderResponseDTO
    {
        public string OrderTrackingId { get; set; }
        public string MerchantReference { get; set; }
        public string RedirectUrl { get; set; }
        public int? Error { get; set; }
        public string Status { get; set; }
    }

    public class TransactionStatusDTO
    {
        public string PaymentMethod { get; set; }
        public decimal Amount { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ConfirmationCode { get; set; }
        public string PaymentStatusDescription { get; set; }
        public string Description { get; set; }
        public string Message { get; set; }
        public string PaymentAccount { get; set; }
        public string CallBackUrl { get; set; }
        public int StatusCode { get; set; }
        public string MerchantReference { get; set; }
        public string Currency { get; set; }
        public ErrorDTO Error { get; set; }
        public string Status { get; set; }
    }

    public class ErrorDTO
    {
        public string ErrorType { get; set; }
        public string Code { get; set; }
        public string ErrorMessage { get; set; }
        public string CallBackUrl { get; set; }
    }
}
