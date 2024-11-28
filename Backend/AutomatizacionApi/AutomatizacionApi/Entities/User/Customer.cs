namespace AutomatizacionApi.Entities.User
{
    public class Customer  : BaseUser
    {

        //Navigation Properties
        public ICollection<UserTicket>? UserTickets { get; set; }
    }
}
