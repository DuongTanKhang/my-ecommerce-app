using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ECommerceBackend.Models.ProductService;

public partial class TblProductVariant
{
    [Key]
    public int Id { get; set; }

    [Required(ErrorMessage = "ProductId không được trống")]
    [Range(1, int.MaxValue, ErrorMessage = "ProductId không hợp lệ")]
    public int ProductId { get; set; }

    [Required(ErrorMessage = "Sku không được để trống")]
    [StringLength(100, ErrorMessage = "Sku tối đa 100 ký tự")]
    public string Sku { get; set; } = null!;

    [Required(ErrorMessage = "Tên biến thể là bắt buộc")]
    [StringLength(255, ErrorMessage = "Tên biến thể tối đa 255 ký tự")]
    public string VariantName { get; set; } = null!;

    public decimal Price { get; set; }

    public int StockQuanity { get; set; }

    public string? ImageUrl { get; set; }

    public int? Active { get; set; }

    public virtual TblProduct Product { get; set; } = null!;

    public virtual ICollection<TblVariantAttribute> TblVariantAttributes { get; set; } = new List<TblVariantAttribute>();
}
