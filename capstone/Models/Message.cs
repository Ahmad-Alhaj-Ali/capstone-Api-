using System;
using System.Collections.Generic;

namespace capstone.Models;

public partial class Message
{
    public int Id { get; set; }

    public DateTime? CreatedAt { get; set; }

    public int SenderId { get; set; }

    public int ReceiverId { get; set; }

    public int ConversationId { get; set; }

    public bool? IsDeleted { get; set; }

    public string MessageText { get; set; } = null!;

    public virtual Conversation Conversation { get; set; } = null!;

    public virtual User Sender { get; set; } = null!;
}
