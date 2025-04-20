using System;
using System.Collections.Generic;

namespace capstone.Models;

public partial class Category
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

    public int? OfferId { get; set; }

    public virtual ICollection<Item> Items { get; set; } = new List<Item>();

    public virtual Offer? Offer { get; set; }
}
