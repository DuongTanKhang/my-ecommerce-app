namespace ECommerceBackend.Models.ProductService.DTOs
{
    public class ProductDto
    {
        public string Name { get; set; } = null!;
        public string Sku { get; set; } = null!;
        public decimal Price { get; set; }
        public int StockQuanity { get; set; }
        public int? Active { get; set; }
    }
}
