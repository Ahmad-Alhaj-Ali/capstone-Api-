using System;
using System.Collections.Generic;

namespace capstone.Models;

public partial class Option
{
    public int Id { get; set; }

    public DateTime? CreatedAt { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public int? UpdatedBy { get; set; }

    public bool? IsActive { get; set; }

    public string NameAr { get; set; } = null!;

    public string NameEn { get; set; } = null!;

    public bool? IsRequired { get; set; }

    public int CategoryId { get; set; }

    public virtual OptionCategory Category { get; set; } = null!;

    public virtual ICollection<ItemOption> ItemOptions { get; set; } = new List<ItemOption>();
}
