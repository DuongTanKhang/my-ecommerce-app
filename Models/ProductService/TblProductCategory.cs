using System;
using System.Collections.Generic;

namespace ECommerceBackend.Models.ProductService;

public partial class TblProductCategory
{
    public int ProductId { get; set; }

    public int CategoryId { get; set; }

    public virtual TblCategory Category { get; set; } = null!;

    public virtual TblProduct Product { get; set; } = null!;
}
