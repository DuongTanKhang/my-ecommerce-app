using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ECommerceBackend.Models.ProductService;

public partial class TblCategory
{
    [Key]
    public int Id { get; set; }

    [Required(ErrorMessage = "Tên category là bắt buộc")]
    [StringLength(255, ErrorMessage ="Tên category tối đa 255 ký tự")]
    public string Name { get; set; } = null!;

    [StringLength(255, ErrorMessage = "Slug tối đa 255 ký tự")]
    public string? Slug { get; set; }

    public int? ParentId { get; set; }


    public string? ImageUrl { get; set; }

    public string? Description { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? Active { get; set; }
}
