using AutomatizacionApi.Entities.Common;
using AutomatizacionApi.Entities.User;
using AutomatizacionApi.Enum;

namespace AutomatizacionApi.Entities
{
    public class Reservations: BaseEntity<int>
    {
        public string? CustomerId { get; set; }
        public Customer? Customer { get; set; }
        public int TicketId { get; set; }
        public Ticket? Ticket { get; set; }
        public int Quantity { get; set; }
        public ReservationStatus Status { get; set; } = ReservationStatus.Pending;
    }
}
