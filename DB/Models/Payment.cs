namespace DB.Models
{
    public class Payment
    {
        public Guid Id { get; set; }
        public Guid CustomerId { get; set; }
        public Guid ServiceProviderId { get; set; }
        public decimal Amount { get; set; }
        public string Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public virtual Customer Customer { get; set; } = null!;
        public virtual ServiceProvider ServiceProvider { get; set; } = null!;

        public Payment()
        {
            Id = Guid.NewGuid();
            Status = "Pendiente";
            CreatedAt = DateTime.Now;
        }

    }
}
