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
    public class TheatresController : ControllerBase
    {
        private readonly ITheatreService _theatreService;
        public TheatresController(ITheatreService theatreService)
        {
            _theatreService = theatreService;
        }
        [HttpGet("all")]
        public IEnumerable<TheatreViewModel> GetTheatres()
        {          
                return _theatreService.GetTheatres();
        }
        [HttpPost]
        public bool InsertTheatre(Theatre theatre)
        {
             return _theatreService.InsertTheatre(theatre);           
        }

        [HttpGet("{id}")]
        public TheatreViewModel GetTheatreById(int id)
        {
            return _theatreService.GetTheatreById(id);
        }
        [HttpPut]
        public bool UpdateTheatre(Theatre theatre)
        {
           return  _theatreService.UpdateTheatre(theatre);
        }
        [HttpDelete("{id}")]
        public bool DeleteTheatre(int id)
        {
             return _theatreService.DeleteTheatre(id);

        }
        [HttpGet("TheatreByMovie{Movieid}")]
        public List<Theatre> GetTheatresByMovie(int Movieid)
        {
            return _theatreService.GetTheatresByMovie(Movieid);
        }


       




    }
}
