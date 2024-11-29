using AutomatizacionApi.Entities.Common;

namespace AutomatizacionApi.Entities
{
    public class TicketsCode : BaseEntity<Guid>
    {
        public string? TicketCode { get; set; }

        public Guid ReservationId { get; set; }

        //Navigation Properties
        public Reservation? Reservation { get; set; }
    }
}
