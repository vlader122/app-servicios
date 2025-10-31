using DB.Models;

namespace Repository
{
    public interface IPaymentRepository
    {
        Task<Customer?> GetCustomerByIdAsync(Guid id);
        Task<ServiceProvider?> GetServiceProviderByNameAsync(string name);

        Task AddPaymentAsync(Payment payment);

        Task<IEnumerable<PaymentResponseDto>> GetPaymentsByCustomerIdAsync(Guid customerId);

        Task<int> SaveChangesAsync();
    }
}
