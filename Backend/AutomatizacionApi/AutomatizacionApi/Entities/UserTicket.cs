namespace AutomatizacionApi.Entities
{
    public class UserTicket
    {
        public string UserId { get; set; }
        public ApplicationUser? User { get; set; }
        public int TicketId { get; set; }
        public Ticket? Ticket { get; set; }
    }
}
