using DB.Models;
using Microsoft.EntityFrameworkCore;

namespace DB
{
    public class ServiciosContext : DbContext
    {
        public ServiciosContext(DbContextOptions<ServiciosContext> options) : base(options) { }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<ServiceProvider> ServiceProviders { get; set; }
    }
}
