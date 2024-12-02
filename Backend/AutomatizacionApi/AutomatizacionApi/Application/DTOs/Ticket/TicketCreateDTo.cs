namespace AutomatizacionApi.Application.DTOs.Ticket
{
    public class TicketCreateDTo
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public int LocationId { get; set; }
    }
}
