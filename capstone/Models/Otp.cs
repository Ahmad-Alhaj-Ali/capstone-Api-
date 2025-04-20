using System;
using System.Collections.Generic;

namespace capstone.Models;

public partial class Otp
{
    public int Id { get; set; }

    public DateTime? CreatedAt { get; set; }

    public int? CreatedBy { get; set; }

    public bool? IsActive { get; set; }

    public string Otpcode { get; set; } = null!;

    public DateTime ExpiryDate { get; set; }

    public int? Attempt { get; set; }

    public bool? IsUsed { get; set; }

    public int UserId { get; set; }

    public virtual User User { get; set; } = null!;
}
