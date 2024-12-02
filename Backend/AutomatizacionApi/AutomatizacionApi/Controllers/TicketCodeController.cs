using AutomatizacionApi.Application.DTOs.TicketCode;
using AutomatizacionApi.Application.Interfaces.Services;
using AutomatizacionApi.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AutomatizacionApi.Controllers
{
    [Authorize]
    [Route("Api/[Controller]")]
    [ApiController]
    public class TicketCodeController(ITicketCodeService ticketCodeService) : ControllerBase
    {
        private readonly ITicketCodeService _ticketCodeServices = ticketCodeService;

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await _ticketCodeServices.GetAllAsync();
            return Ok(response);
        }

        [HttpGet("/codes")]
        public async Task<IActionResult> GetByReservationId(Guid reservationId)
        {
            var response = await _ticketCodeServices.GetByReservationId(reservationId);
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var response = await _ticketCodeServices.GetByIdAsync(id);
            return Ok(response);
        }

       
    }
}
