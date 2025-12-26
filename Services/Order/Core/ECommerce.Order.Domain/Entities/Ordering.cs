namespace ECommerce.Order.Domain.Entities
{
    public class Ordering
    {
        public int OrderingId { get; set; }
        public string? UserId { get; set; }
        public decimal TotalPrice => OrderDetails?.Sum(od => od.ProductPrice * od.Quantity) ?? 0;
        public DateTime OrderDate { get; set; }
        public IList<OrderDetail>? OrderDetails { get; set; }
    }
}
