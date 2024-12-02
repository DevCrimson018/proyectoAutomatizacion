using System.Security.Claims;

namespace AutomatizacionApi.NewFolder
{
    public class ClaimsHelper
    {
        private readonly ClaimsPrincipal _user;

        public ClaimsHelper(ClaimsPrincipal user)
        {
            _user = user;
        }

        public string? GetUserId()
        {
            return _user.Claims.FirstOrDefault()!.Value.ToString();
          
        }

        public string? GetEmail()
        {
            return _user.FindFirst(ClaimTypes.Email)?.Value;
        }

        public List<string> GetRoles()
        {
            return _user.FindAll(ClaimTypes.Role).Select(c => c.Value).ToList();
        }

        public string? GetClaimValue(string claimType)
        {
            return _user.FindFirst(claimType)?.Value;
        }
    }
}