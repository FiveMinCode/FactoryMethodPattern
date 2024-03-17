using Microsoft.AspNetCore.Mvc;

namespace FactoryMethodPattern.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PaymentController : ControllerBase
    {
        
        [HttpGet(Name = "GetPaymentAmount")]
        public int GetPaymentAmount(string? cardNumber, string? upiProvider)
        {
            var paymentFactory = !string.IsNullOrEmpty(upiProvider) ?
                new PaymentFactory[] { new UPIPaymentFactory(upiProvider)}
                : new PaymentFactory[] { new CardPaymentFactory(cardNumber)};

            return paymentFactory[0].CreatePaymentService().charges;
        }
    }
}