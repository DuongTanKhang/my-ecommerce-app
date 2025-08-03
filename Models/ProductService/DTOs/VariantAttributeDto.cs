namespace ECommerceBackend.Models.ProductService.DTOs
{
    public class VariantAttributeDto
    {
        public int VariantId { get; set; }

        public string AttributeName { get; set; } = null!;

        public string AttributeValue { get; set; } = null!;

    }
}