namespace ECommerce.Discount.DTOs
{
    public class CreateCouponDto
    {
        public required string Code { get; set; }
        public int DiscountRate { get; set; }
        public DateTime ExpireDate { get; set; }
        public string? ProductId { get; set; }
    }
}
