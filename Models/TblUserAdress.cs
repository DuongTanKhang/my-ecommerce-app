using System;
using System.Collections.Generic;

namespace ECommerceBackend.Models;

public partial class TblUserAdress
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public string AdressLine { get; set; } = null!;

    public string City { get; set; } = null!;

    public string PostalCode { get; set; } = null!;

    public bool IsDefault { get; set; }

    public virtual TblUser User { get; set; } = null!;
}
