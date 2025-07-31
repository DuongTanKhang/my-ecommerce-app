using ECommerceBackend.Models.ProductService;
using System;
using System.Collections.Generic;

namespace ECommerceBackend.Models;

public partial class TblCart
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public int ProductId { get; set; }

    public int? Quanity { get; set; }

    public DateTime? AddedDate { get; set; }

    public virtual TblProduct Product { get; set; } = null!;

    public virtual TblUser User { get; set; } = null!;
}
