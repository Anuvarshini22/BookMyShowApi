using BookMyShow.Entities;
using BookMyShow.ViewModel;

namespace BookMyShow.Contracts
{
    public interface ITheatreService
    {
        public IEnumerable<TheatreViewModel> GetTheatres();
        public bool InsertTheatre(Theatre theatre);
        public TheatreViewModel GetTheatreById(int id);
        public bool UpdateTheatre(Theatre theatre);
        public bool DeleteTheatre(int id);
        public List<Theatre> GetTheatresByMovie(int Movieid);  
    }
}
