using System;
using System.Collections.Generic;

namespace capstone.Models;

public partial class ItemOption
{
    public int Id { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public bool? IsActive { get; set; }

    public int? CreatedBy { get; set; }

    public int ItemId { get; set; }

    public int OptionId { get; set; }

    public virtual Item Item { get; set; } = null!;

    public virtual Option Option { get; set; } = null!;
}
