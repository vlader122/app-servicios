using DB.Models;

namespace Service
{
    public interface IPaymentService
    {
        Task<(PaymentResponseDto? Response, string? ErrorMessage, int StatusCode)> CreatePaymentAsync(CreatePaymentRequestDto request);

        Task<IEnumerable<PaymentResponseDto>> GetPaymentsByCustomerAsync(Guid customerId);
    }
}
