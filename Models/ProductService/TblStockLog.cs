using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ECommerceBackend.Models.ProductService;

public partial class TblStockLog
{
    [Key]
    public int Id { get; set; }

    [Required(ErrorMessage = "ProductId không được trống")]
    [Range(1, int.MaxValue, ErrorMessage = "ProductId không hợp lệ")]
    public int ProductId { get; set; }


    public int ChangeAmount { get; set; }

    [Required(ErrorMessage = "Note không được trống")]
    public string Note { get; set; } = null!;

    public DateTime? CreatedDate { get; set; }

    public virtual TblProduct Product { get; set; } = null!;
}
