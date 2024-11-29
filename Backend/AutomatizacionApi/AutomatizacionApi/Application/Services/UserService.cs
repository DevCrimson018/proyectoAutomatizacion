using AutomatizacionApi.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Security.Claims;
using AutomatizacionApi.Application.Interfaces.Repositories;
using AutomatizacionApi.Application.Interfaces.Services;
using AutomatizacionApi.Application.Common;
using AutomatizacionApi.Application.DTOs.Auth;
using AutomatizacionApi.Domain.Entities.User;
namespace AutomatizacionApi.Application.Services
{
    public class UserService(IUserRepository userRepository,
        UserManager<ApplicationUser> userManager,
        SignInManager<ApplicationUser> signInManager) : IUserService
    {
        private readonly IUserRepository _userRepository = userRepository;
        private readonly UserManager<ApplicationUser> _userManager = userManager;
        private readonly SignInManager<ApplicationUser> _signInManager = signInManager;

        public async Task<ApplicationUser> RegisterAsync(ApplicationUser user, string password)
        {
            return await _userRepository.Add(user, password);
        }

        public async Task<Result<LoginResponse>> AuthenticationAsync(LoginRequest request)
        {

            var user = await _userManager.FindByEmailAsync(request.Email!);

            if (user is null)
                return Result<LoginResponse>.Failure("User doesn't exist");

            var result = await _signInManager.PasswordSignInAsync(user, request.Password!, false, false);
            if (!result.Succeeded)
                return Result<LoginResponse>.Failure("Invalid password");


            var token = await GenerateTokenAsync(user);
            return new Result<LoginResponse>
            {
                IsSuccess = true,
                Data = new LoginResponse
                {
                    Token = token
                }
            };
        }


        private async Task<string> GenerateTokenAsync(ApplicationUser user)
        {
            #region Header
            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("poifjow;gqti;oihj4ogo43phig3oi4hgi43i4hg3gih43oigh4goi4hgoigh4gihi4gh4i3gh4gih43giofkvlfdnvlkbn"));
            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);
            var header = new JwtHeader(signingCredentials);

            #region claims
            var userClaims = await _userManager.GetClaimsAsync(user);
            var claims = new[]
            {
              new Claim(JwtRegisteredClaimNames.Name, user.UserName!),
              new Claim(JwtRegisteredClaimNames.Email, user.Email!),
              new Claim("userId", user.Id),
            }.Union(userClaims);
            #endregion

            #region Payload
            var payload = new JwtPayload(
                issuer: "localhost",
                audience: "localhost",
                claims: claims,
                notBefore: DateTime.UtcNow,
                expires: DateTime.UtcNow.AddMinutes(30)
            );
            #endregion
            var token = new JwtSecurityToken(header, payload);
            return new JwtSecurityTokenHandler().WriteToken(token);
            #endregion
        }
    }
}

