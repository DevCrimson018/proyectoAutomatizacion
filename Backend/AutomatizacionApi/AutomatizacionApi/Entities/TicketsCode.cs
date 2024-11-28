using AutomatizacionApi.Entities.Common;

namespace AutomatizacionApi.Entities
{
    public class TicketsCode : BaseEntity<Guid>
    {
        public int ReservationId { get; set; }
        public Reservation? Reservation { get; set; }
        public string? TicketCode { get; set; }
    }
}
