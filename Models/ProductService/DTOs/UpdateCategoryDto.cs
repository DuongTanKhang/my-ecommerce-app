namespace ECommerceBackend.Models.ProductService.DTOs
{
    public class UpdateCategoryDto
    {
        public string Name { get; set; } = null!;
        public string? Slug { get; set; }
        public int? ParentId { get; set; }
        public string? ImageUrl { get; set; }
        public string? Description { get; set; }
        public int? Active { get; set; }
    }
}
