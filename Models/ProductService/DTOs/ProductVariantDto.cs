namespace ECommerceBackend.Models.ProductService.DTOs
{
    public class ProductVariantDto
    {
        public int ProductId { get; set; }

        public string Sku { get; set; } = null!;

        public string VariantName { get; set; } = null!;

        public decimal Price { get; set; }

        public int StockQuanity { get; set; }

        public string? ImageUrl { get; set; }

        public int? Active { get; set; }
    }
}
