using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ECommerceBackend.Models.ProductService;

public partial class TblProductCategory
{
    [Key]
    public int Id { get; set; }

    [Range(1, int.MaxValue, ErrorMessage = "ProductId không hợp lệ")]
    public int ProductId { get; set; }
    [Range(1, int.MaxValue, ErrorMessage = "CategoryId không hợp lệ")]
    public int CategoryId { get; set; }

    public virtual TblCategory Category { get; set; } = null!;

    public virtual TblProduct Product { get; set; } = null!;
}
