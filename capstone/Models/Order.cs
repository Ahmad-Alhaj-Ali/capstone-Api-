using System;
using System.Collections.Generic;

namespace capstone.Models;

public partial class Order
{
    public int Id { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? EndDate { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public string OrderStatus { get; set; } = null!;

    public decimal? DriverRate { get; set; }

    public decimal? ClientRate { get; set; }

    public string? ClientReview { get; set; }

    public string? DriverReview { get; set; }

    public int ClientId { get; set; }

    public int? DriverId { get; set; }

    public int DeliveryAddressId { get; set; }

    public int? PaymentMethodId { get; set; }

    public string PaymentStatus { get; set; } = null!;

    public virtual Client Client { get; set; } = null!;

    public virtual Address DeliveryAddress { get; set; } = null!;

    public virtual Driver? Driver { get; set; }

    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

    public virtual PaymentMethod? PaymentMethod { get; set; }
}
