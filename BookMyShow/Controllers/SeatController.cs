using AutoMapper;
using BookMyShow.Contracts;
using BookMyShow.Entities;
using BookMyShow.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookMyShow.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeatController : ControllerBase
    {
        private readonly ISeatService _seatService;
        public SeatController(ISeatService seatService)
        {
            _seatService = seatService;
         }
        [HttpGet("all")]
        public IEnumerable<SeatViewModel> GetSeats()  
        {
             return _seatService.GetSeat();

        }
        [HttpPost]
        public bool InsertSeat(Seat seat)
        {
             return _seatService.InsertSeat(seat);
             
        }


      
        [HttpGet("{id}")]
        public SeatViewModel GetSeatById(int id)
        {
            return _seatService.GetSeatById(id);
        }
        [HttpPut]
        public bool UpdateSeat(Seat seat)
        {
            return _seatService.UpdateSeat(seat);
        }
        [HttpDelete("{id}")]
        public bool DeleteSeat(int id)
        {
            return _seatService.DeleteSeat(id);

        }
        [HttpGet("SeatByShow/{id}")]
        public List<SeatViewModel> GetSeatsByShow(int id)
        {
            return _seatService.GetSeatByShow(id);
        }
        [HttpPut("ticket/{ticketId}")]
        public JsonResult Put([FromRoute()] int ticketId, [FromBody()]Seat seat)
        {
            _seatService.ChangeAvailability(ticketId, seat);
            return new JsonResult("Updated Successfully");
        }

    }
}
