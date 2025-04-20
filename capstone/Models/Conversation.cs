using System;
using System.Collections.Generic;

namespace capstone.Models;

public partial class Conversation
{
    public int Id { get; set; }

    public DateTime? CreatedAt { get; set; }

    public int DriverId { get; set; }

    public int ClientId { get; set; }

    public virtual Client Client { get; set; } = null!;

    public virtual Driver Driver { get; set; } = null!;

    public virtual ICollection<Message> Messages { get; set; } = new List<Message>();
}
