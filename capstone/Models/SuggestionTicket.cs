using System;
using System.Collections.Generic;

namespace capstone.Models;

public partial class SuggestionTicket
{
    public int Id { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public DateTime? EndDate { get; set; }

    public bool? IsActive { get; set; }

    public string Title { get; set; } = null!;

    public string TicketDescription { get; set; } = null!;

    public string TicketStatus { get; set; } = null!;

    public int ClientId { get; set; }

    public virtual Client Client { get; set; } = null!;
}
