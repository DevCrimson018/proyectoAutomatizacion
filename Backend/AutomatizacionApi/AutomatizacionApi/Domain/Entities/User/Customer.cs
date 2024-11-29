using AutomatizacionApi.Domain.Entities;

namespace AutomatizacionApi.Domain.Entities.User
{
    public class Customer : ApplicationUser
    {

        //Navigation Properties
        public ICollection<Reservation>? Reservations { get; set; }
    }
}
