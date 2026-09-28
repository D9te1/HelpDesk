using HelpDesk.Domain.TicketState;

namespace HelpDesk.Domain.Models
{
    public class Ticket
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public TicketStatus Status { get; set; } = TicketStatus.New;
        public TicketPriority Priority { get; set; } = TicketPriority.Normal;
        public int AuthorId { get; set; }
        public int? AssignedUserId { get; set; }
        public int CategoryId { get; set; }
        public TicketCategory Category { get; set; } = null!;
        public DateTime CreatedAtUtc { get; set; }
        public DateTime? UpdatedAtUtc { get; set; }
        public DateTime? ClosedAtUtc { get; set; }
        public ICollection<TicketComment> Comments { get; set; } = [];
    }
}
