using BookMyShow.Entities;
using BookMyShow.ViewModel;

namespace BookMyShow.Contracts
{
    public interface ISeatService
    {
        public IEnumerable<SeatViewModel> GetSeat();
        public bool InsertSeat(Seat seat);
       
        public SeatViewModel GetSeatById(int id);
        public bool UpdateSeat(Seat seat);  
        public bool DeleteSeat(int id);
        public List<SeatViewModel> GetSeatByShow(int id);
        public void ChangeAvailability(int ticketId, Seat seat);
    }
}
