using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ECommerceBackend.Models.ProductService;

public partial class TblProduct
{
    [Key]
    public int Id { get; set; }

    [Required(ErrorMessage ="Name không được để trống")]
    [StringLength(255, ErrorMessage = "Tên product tối đa 255 ký tự")]
    public string Name { get; set; } = null!;

    [Required(ErrorMessage = "Sku không được để trống")]
    [StringLength(100, ErrorMessage = "Sku tối đa 100 ký tự")]
    public string Sku { get; set; } = null!;

    public decimal Price { get; set; }

    public int StockQuanity { get; set; }

    public DateTime? CreatedDate { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public int? Active { get; set; }

    public virtual ICollection<TblCart> TblCarts { get; set; } = new List<TblCart>();

    public virtual ICollection<TblProductImage> TblProductImages { get; set; } = new List<TblProductImage>();

    public virtual ICollection<TblProductVariant> TblProductVariants { get; set; } = new List<TblProductVariant>();

    public virtual ICollection<TblStockLog> TblStockLogs { get; set; } = new List<TblStockLog>();
}
