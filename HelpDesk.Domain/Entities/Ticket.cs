using HelpDesk.Domain.Enums;

namespace HelpDesk.Domain.Entities
{
    public class Ticket
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public TicketStatus Status { get; set; } = TicketStatus.New;
        public TicketPriority Priority { get; set; } = TicketPriority.Normal;
        public Guid AuthorId { get; set; }
        public Guid? AssignedUserId { get; set; }
        public Guid CategoryId { get; set; }
        public TicketCategory Category { get; set; } = null!;
        public DateTime CreatedAtUtc { get; set; }
        public DateTime? UpdatedAtUtc { get; set; }
        public DateTime? ClosedAtUtc { get; set; }
        public ICollection<TicketComment> Comments { get; set; } = [];
    }
}
