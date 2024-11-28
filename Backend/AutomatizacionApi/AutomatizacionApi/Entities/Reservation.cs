using AutomatizacionApi.Entities.Common;
using AutomatizacionApi.Entities.User;

namespace AutomatizacionApi.Entities
{
    public class Reservation : BaseEntity<Guid>
    {
        public string? CustomerId { get; set; }
        public Customer? Customer { get; set; }
        public int TicketId { get; set; }
        public Ticket? Ticket { get; set; }
        public 
    }
}
