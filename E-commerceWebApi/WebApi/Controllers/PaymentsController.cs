using E_commerceWebApi.Application.Payments.Dtos;
using Microsoft.AspNetCore.Mvc;
using Stripe;
using Stripe.Checkout;

[ApiController]
[Route("api/[controller]")]
public class PaymentsController : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Pay([FromBody] StripePaymentRequest request)
    {
        try
        {
            var options = new PaymentIntentCreateOptions
            {
                Amount = request.Amount,
                Currency = request.Currency,
                PaymentMethod = request.PaymentMethodId,
                ConfirmationMethod = "manual",
                Confirm = true,
            };

            var service = new PaymentIntentService();
            var intent = await service.CreateAsync(options);

            return Ok(new
            {
                PaymentIntentId = intent.Id,
                Status = intent.Status
            });
        }
        catch (StripeException ex)
        {
            return BadRequest(new { error = ex.Message });
        }
    }
}
