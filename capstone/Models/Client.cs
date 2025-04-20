using System;
using System.Collections.Generic;

namespace capstone.Models;

public partial class Client
{
    public int Id { get; set; }

    public DateTime Birthdate { get; set; }

    public string ClientStatus { get; set; } = null!;

    public int UserId { get; set; }

    public virtual ICollection<Address> Addresses { get; set; } = new List<Address>();

    public virtual ICollection<Authentication> Authentications { get; set; } = new List<Authentication>();

    public virtual ICollection<Bookmark> Bookmarks { get; set; } = new List<Bookmark>();

    public virtual ICollection<Conversation> Conversations { get; set; } = new List<Conversation>();

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual ICollection<PaymentMethod> PaymentMethods { get; set; } = new List<PaymentMethod>();

    public virtual ICollection<ProblemTicket> ProblemTickets { get; set; } = new List<ProblemTicket>();

    public virtual ICollection<SuggestionTicket> SuggestionTickets { get; set; } = new List<SuggestionTicket>();

    public virtual User User { get; set; } = null!;
}
