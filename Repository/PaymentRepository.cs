using DB;
using DB.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class PaymentRepository : IPaymentRepository
    {
        private readonly ServiciosContext _context;
        public PaymentRepository(ServiciosContext context)
        {
            _context = context;
        }
        public async Task AddPaymentAsync(Payment payment)
        {
            await _context.Payments.AddAsync(payment);
        }

        public async Task<Customer?> GetCustomerByIdAsync(Guid id)
        {
            return await _context.Customers.FindAsync(id);
        }

        public async Task<IEnumerable<PaymentResponseDto>> GetPaymentsByCustomerIdAsync(Guid customerId)
        {
            return await _context.Payments
            .Include(p => p.ServiceProvider)
            .Where(p => p.CustomerId == customerId)
            .OrderByDescending(p => p.CreatedAt)
            .Select(p => new PaymentResponseDto
            {
                PaymentId = p.Id,
                ServiceProvider = p.ServiceProvider.Name,
                Amount = p.Amount,
                Status = p.Status,
                CreatedAt = p.CreatedAt
            })
            .ToListAsync();
        }

        public async Task<ServiceProvider?> GetServiceProviderByNameAsync(string name)
        {
            return await _context.ServiceProviders.FirstOrDefaultAsync(sp => sp.Name == name);
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
