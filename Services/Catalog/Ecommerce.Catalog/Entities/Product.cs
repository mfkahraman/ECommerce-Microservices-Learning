using Ecommerce.Catalog.Entities.Common;

namespace Ecommerce.Catalog.Entities
{
    public class Product : BaseEntity
    {
        public required string ProductName { get; set; }
        public decimal Price { get; set; }
        public string? Description { get; set; }
        public string? CategoryId { get; set; }
    }
}
