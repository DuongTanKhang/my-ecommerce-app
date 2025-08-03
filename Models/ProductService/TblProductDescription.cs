using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ECommerceBackend.Models.ProductService;

public partial class TblProductDescription
{
    [Key]
    public int Id { get; set; }

    [Range(1, int.MaxValue, ErrorMessage = "ProductId không hợp lệ")]
    public int ProductId { get; set; }

    public string? Description { get; set; }

    public virtual TblProduct Product { get; set; } = null!;
}
