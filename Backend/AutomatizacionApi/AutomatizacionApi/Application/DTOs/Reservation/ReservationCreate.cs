namespace AutomatizacionApi.Application.DTOs.Reservation
{
    public class ReservationCreate
    {
        public int TicketId { get; set; }
        public int Quantity { get; set; }
        public string? CustomerId { get; set; }
    }
}
