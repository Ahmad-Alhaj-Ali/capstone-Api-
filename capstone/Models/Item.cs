using System;
using System.Collections.Generic;

namespace capstone.Models;

public partial class Item
{
    public int Id { get; set; }

    public DateTime? CreatedAt { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public int? UpdatedBy { get; set; }

    public bool? IsActive { get; set; }

    public string ItemNameAr { get; set; } = null!;

    public string ItemNameEn { get; set; } = null!;

    public string ItemDescriptionAr { get; set; } = null!;

    public string ItemDescriptionEn { get; set; } = null!;

    public decimal Price { get; set; }

    public string? ImageUrl { get; set; }

    public int CategoryId { get; set; }

    public int? OfferId { get; set; }

    public int? ItemBadgeId { get; set; }

    public virtual ICollection<Bookmark> Bookmarks { get; set; } = new List<Bookmark>();

    public virtual Category Category { get; set; } = null!;

    public virtual ItemBadge? ItemBadge { get; set; }

    public virtual ICollection<ItemOption> ItemOptions { get; set; } = new List<ItemOption>();

    public virtual Offer? Offer { get; set; }

    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
}
