using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ECommerceBackend.Models.ProductService;

public partial class TblVariantAttribute
{
    [Key]
    public int Id { get; set; }

    [Required(ErrorMessage = "ProductId không được trống")]
    [Range(1, int.MaxValue, ErrorMessage = "ProductId không hợp lệ")]
    public int VariantId { get; set; }

    public string AttributeName { get; set; } = null!;

    public string AttributeValue { get; set; } = null!;

    public virtual TblProductVariant Variant { get; set; } = null!;
}
