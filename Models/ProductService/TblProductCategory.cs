using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ECommerceBackend.Models.ProductService;

public partial class TblProductCategory
{
    [Key]
    public int Id { get; set; }
    public int ProductId { get; set; }

    public int CategoryId { get; set; }

    public virtual TblCategory Category { get; set; } = null!;

    public virtual TblProduct Product { get; set; } = null!;
}
