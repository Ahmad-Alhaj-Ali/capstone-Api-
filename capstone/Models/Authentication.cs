using System;
using System.Collections.Generic;

namespace capstone.Models;

public partial class Authentication
{
    public int Id { get; set; }

    public DateTime? CreatedAt { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public int? UpdatedBy { get; set; }

    public bool? IsActive { get; set; }

    public string ProviderName { get; set; } = null!;

    public string ProviderLoginId { get; set; } = null!;

    public int ClientId { get; set; }

    public virtual Client Client { get; set; } = null!;
}
