using System;
using System.Collections.Generic;

namespace capstone.Models;

public partial class Token
{
    public int Id { get; set; }

    public DateTime? CreatedAt { get; set; }

    public int? CreatedBy { get; set; }

    public bool? IsActive { get; set; }

    public string Jwttoken { get; set; } = null!;

    public DateTime ExpiryDate { get; set; }

    public bool? IsExpired { get; set; }

    public int UserId { get; set; }

    public virtual User User { get; set; } = null!;
}
