using Microsoft.AspNetCore.Identity;

namespace AutomatizacionApi.Entities
{
    public class ApplicationUser : IdentityUser
    {


        //Navigation Properties
        public ICollection<UserTicket>? UserTickets { get; set; }
    }
}
