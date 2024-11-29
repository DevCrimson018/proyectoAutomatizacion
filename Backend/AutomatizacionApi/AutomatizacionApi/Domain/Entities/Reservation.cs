using AutomatizacionApi.Domain.Entities.Common;
using AutomatizacionApi.Domain.Entities.User;
using AutomatizacionApi.Domain.Enum;

namespace AutomatizacionApi.Domain.Entities
{
    public class Reservation : BaseEntity<Guid>
    {
        public string? CustomerId { get; set; }
        public Customer? Customer { get; set; }
        public int TicketId { get; set; }
        public Ticket? Ticket { get; set; }
        public int Quantity { get; set; }
        public ReservationStatus Status { get; set; } = ReservationStatus.Pending;

        //Navigation Properties
        public ICollection<TicketsCode>? TicketsCodes { get; set; }
    }
}
