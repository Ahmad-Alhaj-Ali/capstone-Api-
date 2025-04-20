using System;
using System.Collections.Generic;

namespace capstone.Models;

public partial class Driver
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public virtual ICollection<Conversation> Conversations { get; set; } = new List<Conversation>();

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual User User { get; set; } = null!;
}
