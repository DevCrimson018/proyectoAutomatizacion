namespace AutomatizacionApi.Entities.User
{
    public class Customer  : ApplicationUser
    {

        //Navigation Properties
        public ICollection<Reservation>? Reservations { get; set; }
    }
}
