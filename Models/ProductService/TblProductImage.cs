using System;
using System.Collections.Generic;

namespace ECommerceBackend.Models.ProductService;

public partial class TblProductImage
{
    public int Id { get; set; }

    public int ProductId { get; set; }

    public string? ImageUrl { get; set; }

    public DateTime? UploadDate { get; set; }

    public virtual TblProduct Product { get; set; } = null!;
}
