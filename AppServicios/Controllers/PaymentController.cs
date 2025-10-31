using DB.Models;
using Microsoft.AspNetCore.Mvc;
using Service;

namespace AppServicios.Controllers
{
    [ApiController]
    [Route("api/payments")]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentService _paymentService;

        public PaymentController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        [HttpPost]
        public async Task<IActionResult> CreatePayment([FromBody] CreatePaymentRequestDto request)
        {
            var (response, errorMessage, statusCode) = await _paymentService.CreatePaymentAsync(request);

            if (errorMessage != null)
            {
                return StatusCode(statusCode, new { message = errorMessage });
            }

            return CreatedAtAction(
                nameof(GetPaymentsByCustomer),
                new { customerId = request.CustomerId },
                response);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PaymentResponseDto>>> GetPaymentsByCustomer([FromQuery] Guid customerId)
        {
            if (customerId == Guid.Empty)
            {
                return BadRequest(new { message = "El customerId es obligatorio." });
            }

            var payments = await _paymentService.GetPaymentsByCustomerAsync(customerId);

            return Ok(payments);
        }
    }
}
