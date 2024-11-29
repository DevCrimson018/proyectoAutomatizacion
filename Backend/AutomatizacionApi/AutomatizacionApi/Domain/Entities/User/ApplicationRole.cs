using Microsoft.AspNetCore.Identity;

namespace AutomatizacionApi.Domain.Entities.User
{
    public class ApplicationRole : IdentityRole
    {

        //Navigation Properties
        public ICollection<ApplicationUser>? UserRoles { get; set; }
    }
}
