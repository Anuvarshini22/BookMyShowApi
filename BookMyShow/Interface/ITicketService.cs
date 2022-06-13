using BookMyShow.Models;
using BookMyShow.ViewModel;

namespace BookMyShow.Contracts
{
    public interface ITicketService
    {
        public IEnumerable<TicketViewModel> GetTickets();
        public bool InsertTicket(Ticket ticket);
        public bool UpdateTicket(Ticket ticket);
        public bool DeleteTicket(int id);
    }
}
