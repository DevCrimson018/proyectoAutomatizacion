using Microsoft.AspNetCore.Identity;

namespace AutomatizacionApi.Entities.User
{
    public class ApplicationRole : IdentityRole
    {

        //Navigation Properties
        public ICollection<ApplicationUser>? UserRoles { get; set; }
    }
}
