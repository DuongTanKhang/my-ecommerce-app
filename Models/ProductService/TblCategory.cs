using System;
using System.Collections.Generic;

namespace ECommerceBackend.Models.ProductService;

public partial class TblCategory
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Slug { get; set; }

    public int? ParentId { get; set; }

    public string? ImageUrl { get; set; }

    public string? Description { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? Active { get; set; }
}
