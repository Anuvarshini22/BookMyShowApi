using BookMyShow.Entities;
using BookMyShow.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace BookMyShow.Contracts
{
    public interface IShowService
    {
        public IEnumerable<ShowViewModel> GetShows();
        public bool InsertShow(Show show);
        public ShowViewModel GetShowById(int id);
        public  bool UpdateShow(Show show);
        public bool DeleteShow(int id);
        public List<ShowViewModel> GetShowsByTheatre(int id);
       // public ActionResult UpdateSeats(int id, int noOfSeats);
    }
}
