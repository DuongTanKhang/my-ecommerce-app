using ECommerceBackend.Models.ProductService;
using System;
using System.Collections.Generic;

namespace ECommerceBackend.Models;

public partial class TblVariantAttribute
{
    public int Id { get; set; }

    public int VariantId { get; set; }

    public string AttributeName { get; set; } = null!;

    public string AttributeValue { get; set; } = null!;

    public virtual TblProductVariant Variant { get; set; } = null!;
}
