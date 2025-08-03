using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ECommerceBackend.Models.ProductService;

public partial class TblProductImage
{
    [Key]
    public int Id { get; set; }

    [Required(ErrorMessage = "ProductId không được trống")]
    [Range(1, int.MaxValue, ErrorMessage = "ProductId không hợp lệ")]
    public int ProductId { get; set; }

    public string? ImageUrl { get; set; }

    public DateTime? UploadDate { get; set; }

    public virtual TblProduct Product { get; set; } = null!;
}
