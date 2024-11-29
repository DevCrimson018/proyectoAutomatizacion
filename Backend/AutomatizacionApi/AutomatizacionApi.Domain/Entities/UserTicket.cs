using AutomatizacionApi.Entities.User;

namespace AutomatizacionApi.Entities
{
    public class UserTicket
    {
        public string? CustomerId { get; set; }
        public Customer? User { get; set; }
        public int TicketId { get; set; }
        public Ticket? Ticket { get; set; }
    }
}
