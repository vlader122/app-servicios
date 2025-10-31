using DB.Models;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class PaymentService : IPaymentService
    {
        private readonly IPaymentRepository _paymentRepository;
        public PaymentService(IPaymentRepository paymentRepository)
        {
            _paymentRepository = paymentRepository;
        }
        public async Task<(PaymentResponseDto? Response, string? ErrorMessage, int StatusCode)> CreatePaymentAsync(CreatePaymentRequestDto request)
        {
            var customer = await _paymentRepository.GetCustomerByIdAsync(request.CustomerId);
            if (customer == null)
            {
                return (null, "Cliente no encontrado.", 404);
            }

            var serviceProvider = await _paymentRepository.GetServiceProviderByNameAsync(request.ServiceProvider);
            if (serviceProvider == null)
            {
                return (null, "Proveedor de servicio no encontrado.", 404);
            }

            var payment = new Payment
            {
                CustomerId = customer.Id,
                ServiceProviderId = serviceProvider.Id,
                Amount = request.Amount
            };

            await _paymentRepository.AddPaymentAsync(payment);
            await _paymentRepository.SaveChangesAsync();

            var response = new PaymentResponseDto
            {
                PaymentId = payment.Id,
                ServiceProvider = serviceProvider.Name,
                Amount = payment.Amount,
                Status = payment.Status,
                CreatedAt = payment.CreatedAt
            };

            return (response, null, 201);
        }

        public async Task<IEnumerable<PaymentResponseDto>> GetPaymentsByCustomerAsync(Guid customerId)
        {
            return await _paymentRepository.GetPaymentsByCustomerIdAsync(customerId);
        }
    }
}
