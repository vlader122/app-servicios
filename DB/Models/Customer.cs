namespace DB.Models
{
    public class Customer
    {
        public Guid Id { get; set; }
        public string FirtsName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string? PhoneNumber { get; set; }
        public string? Address { get; set; }
        public string? Country { get; set; }
        public string? City { get; set; }
        public string Status { get; set; } = "active";
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public virtual ICollection<Payment> Payments { get; set;} = new List<Payment>();

        public Customer()
        {
            Id = Guid.NewGuid();
            CreatedAt = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;
        }
    }
}
