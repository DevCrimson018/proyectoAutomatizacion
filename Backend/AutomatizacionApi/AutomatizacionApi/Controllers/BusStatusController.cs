using AutomatizacionApi.Application.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AutomatizacionApi.Controllers
{
    [Authorize]
    [Route("Api/[Controller]")]
    [ApiController]
    public class BusStatusController(IBusStatusServices busStatusServices) : ControllerBase
    {
        private readonly IBusStatusServices _busStatusServices = busStatusServices;

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await _busStatusServices.GetAllAsync();

            return Ok(response);
        }
    }
}
