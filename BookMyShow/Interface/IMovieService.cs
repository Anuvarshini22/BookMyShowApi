using BookMyShow.Entities;
using BookMyShow.ViewModel;

namespace BookMyShow.Contracts
{
    public interface IMovieService
    {
        public IEnumerable<MovieViewModel> GetMovies();
        public bool InsertMovie(Movie movie);
        public MovieViewModel GetMovieById(int id);
        public bool UpdateMovie(Movie movie);
        public bool DeleteMovie(int id);  
    }
}
