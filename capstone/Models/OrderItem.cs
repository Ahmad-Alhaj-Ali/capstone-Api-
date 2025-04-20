using System;
using System.Collections.Generic;

namespace capstone.Models;

public partial class OrderItem
{
    public int Id { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public int Quantity { get; set; }

    public decimal Price { get; set; }

    public decimal? Rate { get; set; }

    public string? Review { get; set; }

    public bool? IsDeleted { get; set; }

    public int ItemId { get; set; }

    public int OrderId { get; set; }

    public virtual Item Item { get; set; } = null!;

    public virtual Order Order { get; set; } = null!;
}
