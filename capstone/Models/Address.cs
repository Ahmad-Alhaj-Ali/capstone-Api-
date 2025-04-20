using System;
using System.Collections.Generic;

namespace capstone.Models;

public partial class Address
{
    public int Id { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public bool? IsActive { get; set; }

    public string AddressName { get; set; } = null!;

    public string? Hint { get; set; }

    public string Region { get; set; } = null!;

    public string Province { get; set; } = null!;

    public decimal Latitude { get; set; }

    public decimal Longitude { get; set; }

    public int ClientId { get; set; }

    public virtual Client Client { get; set; } = null!;

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
