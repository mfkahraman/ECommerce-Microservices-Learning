namespace ECommerce.Discount.DTOs
{
    public class ResultCouponDto
    {
        public int CouponId { get; set; }
        public required string Code { get; set; }
        public int DiscountRate { get; set; }
        public DateTime ExpireDate { get; set; }
        public string? ProductId { get; set; }
    }
}
