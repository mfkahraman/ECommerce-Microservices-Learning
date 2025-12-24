namespace Ecommerce.Catalog.DTOs.ProductDTOs
{
    public class CreateProductDto
    {
        public required string ProductName { get; set; }
        public decimal Price { get; set; }
        public string? Description { get; set; }
        public string? CategoryId { get; set; }
    }
}
