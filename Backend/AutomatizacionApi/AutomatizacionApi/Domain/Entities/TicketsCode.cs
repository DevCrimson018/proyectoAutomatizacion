using AutomatizacionApi.Domain.Entities.Common;

namespace AutomatizacionApi.Domain.Entities
{
    public class TicketsCode : BaseEntity<Guid>
    {
        public string? TicketCode { get; set; }

        public Guid ReservationId { get; set; }

        //Navigation Properties
        public Reservation? Reservation { get; set; }
    }
}
