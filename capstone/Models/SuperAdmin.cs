using System;
using System.Collections.Generic;

namespace capstone.Models;

public partial class SuperAdmin
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public virtual User User { get; set; } = null!;
}
