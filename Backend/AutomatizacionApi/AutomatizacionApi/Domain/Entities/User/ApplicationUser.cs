using Microsoft.AspNetCore.Identity;

namespace AutomatizacionApi.Domain.Entities.User
{
    public class ApplicationUser : IdentityUser
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Cedula { get; set; }


        // Navigation Properties
        public ApplicationRole? Role { get; set; }
    }
}
