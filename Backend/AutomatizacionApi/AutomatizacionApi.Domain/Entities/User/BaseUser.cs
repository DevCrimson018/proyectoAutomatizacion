using Microsoft.AspNetCore.Identity;

namespace AutomatizacionApi.Entities.User
{
    public class BaseUser : IdentityUser
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Cedula { get; set; }
    }
}
