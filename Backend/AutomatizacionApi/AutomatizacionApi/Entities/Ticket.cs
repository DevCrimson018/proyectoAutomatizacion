namespace AutomatizacionApi.Entities
{
    public class Ticket : BaseEntity<int>
    {


        //Navigation Properties
        public ICollection<UserTicket>? UserTicket { get; set; }
    }
}
