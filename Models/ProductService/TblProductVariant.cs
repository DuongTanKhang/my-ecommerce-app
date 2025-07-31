using System;
using System.Collections.Generic;

namespace ECommerceBackend.Models.ProductService;

public partial class TblProductVariant
{
    public int Id { get; set; }

    public int ProductId { get; set; }

    public string Sku { get; set; } = null!;

    public string VariantName { get; set; } = null!;

    public decimal Price { get; set; }

    public int StockQuanity { get; set; }

    public string? ImageUrl { get; set; }

    public int? Active { get; set; }

    public virtual TblProduct Product { get; set; } = null!;

    public virtual ICollection<TblVariantAttribute> TblVariantAttributes { get; set; } = new List<TblVariantAttribute>();
}
