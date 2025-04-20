using System;
using System.Collections.Generic;

namespace capstone.Models;

public partial class Bookmark
{
    public int Id { get; set; }

    public DateTime? CreatedAt { get; set; }

    public bool? IsActive { get; set; }

    public int ClientId { get; set; }

    public int ItemId { get; set; }

    public virtual Client Client { get; set; } = null!;

    public virtual Item Item { get; set; } = null!;
}
