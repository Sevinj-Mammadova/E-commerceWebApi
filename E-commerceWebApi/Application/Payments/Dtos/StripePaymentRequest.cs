namespace E_commerceWebApi.Application.Payments.Dtos
{
    public class StripePaymentRequest
    {
        public long Amount { get; set; }  // in cents (e.g., $10.00 = 1000)
        public string Currency { get; set; } = "usd";
        public string PaymentMethodId { get; set; } = string.Empty;
    }
}


