using System.ComponentModel.DataAnnotations;

namespace DB.Models
{
    public class CreatePaymentRequestDto
    {
        [Required(ErrorMessage = "El customerId es obligatorio.")]
        public Guid CustomerId { get; set; }

        [Required(ErrorMessage = "El serviceProvider es obligatorio.")]
        [StringLength(255)]
        public string ServiceProvider { get; set; } = string.Empty;

        [Required(ErrorMessage = "El amount es obligatorio.")]
        [Range(0.01, 1500.00, ErrorMessage = "El monto debe ser mayor a 0 y no puede exceder 1500 Bs.")]
        public decimal Amount { get; set; }
    }
}
