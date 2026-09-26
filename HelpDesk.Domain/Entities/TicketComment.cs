namespace HelpDesk.Domain.Entities
{
    internal class TicketComment
    {
        public Guid Id { get; set; }
        public Guid TicketId { get; set; }
        public Ticket Ticket { get; set; } = null!;
        public Guid AuthorId { get; set; }
        public string Text { get; set; } = string.Empty;
        public DateTime CreatedAtUtc { get; set; }
    }
}
