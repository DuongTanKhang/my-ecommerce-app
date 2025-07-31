using System;
using System.Collections.Generic;

namespace ECommerceBackend.Models;

public partial class TblUserDetail
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public string Fullname { get; set; } = null!;

    public string PhoneNumber { get; set; } = null!;

    public int Gender { get; set; }

    public DateTime Dob { get; set; }

    public string? AvatarUrl { get; set; }

    public virtual TblUser User { get; set; } = null!;
}
