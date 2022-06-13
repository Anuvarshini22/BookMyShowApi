using AutoMapper;
using BookMyShow.Contracts;
using BookMyShow.Models;
using BookMyShow.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using IMapper = AutoMapper.IMapper;

namespace BookMyShow.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketController : ControllerBase
    {
        private readonly ITicketService _ticketService;

        public TicketController(ITicketService ticketService)
        {
            _ticketService = ticketService;

        }
        [HttpGet("all")]
        public IEnumerable<TicketViewModel> GetTickets()
        {
            return _ticketService.GetTickets();
        }

        [HttpPost]
        public bool InsertTicket(Ticket ticket)
        { 
                return _ticketService.InsertTicket(ticket);            
        }
        [HttpPut]
        public bool UpdateTicket(Ticket ticket)
        {
           return  _ticketService.UpdateTicket(ticket);
        }
        [HttpDelete("{id}")]
        public bool DeleteTicket(int id)
        {
            return _ticketService.DeleteTicket(id);

        }
    }
}
