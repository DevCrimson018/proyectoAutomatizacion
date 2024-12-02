using AutomatizacionApi.Application.DTOs.Ticket;
using AutomatizacionApi.Application.Interfaces.Services;
using AutomatizacionApi.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AutomatizacionApi.Controllers
{
    [Authorize]
    [Route("Api/[Controller]")]
    [ApiController]
    public class TicketController(ITicketService ticketService) : ControllerBase
    {
        private readonly ITicketService _ticketService = ticketService;


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await _ticketService.GetAllAsync();

            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var response = await _ticketService.GetByIdAsync(id);

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Create(TicketCreateDTo ticket)
        {
            var response = await _ticketService.CreateAsync(ticket);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Update(Ticket ticket)
        {
            var response = await _ticketService.UpdateAsync(ticket);
            return Ok(response);
        }
    }
}
