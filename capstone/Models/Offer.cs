using System;
using System.Collections.Generic;

namespace capstone.Models;

public partial class Offer
{
    public int Id { get; set; }

    public DateTime? CreatedAt { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public int? UpdatedBy { get; set; }

    public bool? IsActive { get; set; }

    public string TitleEn { get; set; } = null!;

    public string TitleAr { get; set; } = null!;

    public string DescriptionEn { get; set; } = null!;

    public string DescriptionAr { get; set; } = null!;

    public string OfferStatus { get; set; } = null!;

    public string? ImageUrl { get; set; }

    public int? LimitPersons { get; set; }

    public decimal? LimitAmount { get; set; }

    public int? UserPersons { get; set; }

    public string? Code { get; set; }

    public int? DiscountPercentage { get; set; }

    public DateTime? EndDate { get; set; }

    public DateTime? StartDate { get; set; }

    public virtual ICollection<Category> Categories { get; set; } = new List<Category>();

    public virtual ICollection<Item> Items { get; set; } = new List<Item>();
}
