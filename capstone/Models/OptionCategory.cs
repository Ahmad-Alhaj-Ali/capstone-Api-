using System;
using System.Collections.Generic;

namespace capstone.Models;

public partial class OptionCategory
{
    public int Id { get; set; }

    public DateTime? CreatedAt { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public int? UpdatedBy { get; set; }

    public bool? IsActive { get; set; }

    public string NameAr { get; set; } = null!;

    public string NameEn { get; set; } = null!;

    public string? ImageUrl { get; set; }

    public virtual ICollection<Option> Options { get; set; } = new List<Option>();
}
