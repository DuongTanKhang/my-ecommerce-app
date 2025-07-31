using System;
using System.Collections.Generic;

namespace ECommerceBackend.Models.ProductService;

public partial class TblStockLog
{
    public int Id { get; set; }

    public int ProductId { get; set; }

    public int ChangeAmount { get; set; }

    public string Note { get; set; } = null!;

    public DateTime? CreatedDate { get; set; }

    public virtual TblProduct Product { get; set; } = null!;
}
