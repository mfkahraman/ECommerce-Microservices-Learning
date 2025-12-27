using System.ComponentModel.DataAnnotations;

namespace ECommerce.Discount.DTOs
{
    public class CreateCouponDto
    {
        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Code { get; set; } = null!;

        [Range(1, 100)]
        public int DiscountRate { get; set; }

        [Required]
        public DateTime ExpireDate { get; set; }

        [StringLength(100)]
        public string? ProductId { get; set; }
    }
}
