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
    public class ShowsController : ControllerBase
    {

        private readonly IShowService _showService;
        public ShowsController(IShowService showService)
        {
            _showService = showService;
        }
        [HttpGet("all")] 
        public IEnumerable<ShowViewModel> GetShows()
        {           
              return _showService.GetShows();  
        }
        [HttpPost]
        public bool InsertShow(Show show)
        {           
                return  _showService.InsertShow(show);     
        }

        [HttpGet("{id}")]
        public ShowViewModel GetShowById(int id)
        {
            return _showService.GetShowById(id);
        }
        [HttpPut]
        public bool UpdateShow(Show show)
        {
             return _showService.UpdateShow(show);
        }
        [HttpDelete("{id}")]
        public bool DeleteShow(int id)
        {
            return _showService.DeleteShow(id);

        }
        [HttpGet("showByTheatre{id}")]
        public List<ShowViewModel>GetShowsByTheatre(int id)
        {
            return _showService.GetShowsByTheatre(id);
        }
        /*[HttpGet("Availabilty{id}/{noOfSeats}")]
        public ActionResult UpdateSeats(int id,int noOfSeats)
        {
            return Ok(_showService.UpdateSeats(id,noOfSeats));
        }*/
    }
}
