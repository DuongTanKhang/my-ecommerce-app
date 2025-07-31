using System;
using System.Collections.Generic;

namespace ECommerceBackend.Models.ProductService;

public partial class TblProductDescription
{
    public int ProductId { get; set; }

    public string? Description { get; set; }

    public virtual TblCategory Product { get; set; } = null!;
}
