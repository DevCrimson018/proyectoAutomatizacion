using AutomatizacionApi.Application.DTOs.Auth;
using AutomatizacionApi.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace AutomatizacionApi.Controllers
{
    [Route("Api/[Controller]")]
    [ApiController]
    public class AuthController(IUserService userService) : ControllerBase
    {
        private readonly IUserService _userService = userService;

        [HttpPost]
        public async Task<IActionResult> Login(LoginRequest request)
        {

            var response = await _userService.AuthenticationAsync(request);

            if (!response.IsSuccess)
            {
                return Unauthorized();
            }

            return Ok(response);
        }
    }
}
