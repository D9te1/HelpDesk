namespace HelpDesk.Domain.Models
{
    public class TicketCategory
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public bool IsActive { get; set; } = true;
        public ICollection<Ticket> Tickets { get; set; } = [];
    }
}
