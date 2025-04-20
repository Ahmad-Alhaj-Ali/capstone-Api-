using System;
using System.Collections.Generic;

namespace capstone.Models;

public partial class Person
{
    public int Id { get; set; }

    public string PhoneNumber { get; set; } = null!;

    public string? ProfileImageUrl { get; set; }

    public int UserId { get; set; }

    public virtual User User { get; set; } = null!;
}
