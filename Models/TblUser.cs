using System;
using System.Collections.Generic;

namespace ECommerceBackend.Models;

public partial class TblUser
{
    public int Id { get; set; }

    public string Email { get; set; } = null!;

    public string PasswordHash { get; set; } = null!;

    public string Role { get; set; } = null!;

    public DateTime? CreatedDate { get; set; }

    public virtual ICollection<TblCart> TblCarts { get; set; } = new List<TblCart>();

    public virtual ICollection<TblUserAdress> TblUserAdresses { get; set; } = new List<TblUserAdress>();

    public virtual ICollection<TblUserDetail> TblUserDetails { get; set; } = new List<TblUserDetail>();
}
