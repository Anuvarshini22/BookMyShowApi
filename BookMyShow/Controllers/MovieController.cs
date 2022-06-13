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
    public class MovieController : ControllerBase
    {
        private readonly IMovieService _movieService;
        public MovieController(IMovieService movieService)
        {
            _movieService = movieService;
        }
        [HttpGet("all")]
        public IEnumerable<MovieViewModel> GetMovies()
        {
            return _movieService.GetMovies();  
        }

        [HttpPost]
        public bool InsertMovie(Movie movie)
        {
            return _movieService.InsertMovie(movie);
        }

        [HttpGet("{id}")]
        public MovieViewModel GetMovieById(int id)
        {
           return _movieService.GetMovieById(id);
        }
        [HttpPut]
        public bool UpdateMovie(Movie movie)
        {
           return _movieService.UpdateMovie(movie);
        }
        [HttpDelete("{id}")]
        public bool DeleteMovie(int id)
        {
            return _movieService.DeleteMovie(id);
            
        }
    }
}
