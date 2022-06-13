using AutoMapper;
using BookMyShow.Context;
using BookMyShow.Contracts;
using BookMyShow.Models;
using BookMyShow.ViewModel;
using Dapper;
using System.Data;
using System.Data.SqlClient;

namespace BookMyShow.Service
{
    public class TicketService : ITicketService
    {
        private readonly IDbConnection _context;
        private readonly IMapper _mapper;
        public TicketService(IConfiguration configuration, IMapper mapper)
        {
            _context = new SqlConnection(configuration.GetConnectionString("SqlConnection"));
            _mapper = mapper;

        }
        public IEnumerable<TicketViewModel> GetTickets()
        {
            var query = "SELECT * FROM Ticket";
            var ticketViewModel= _context.Query<Ticket>(query).ToList();
            return _mapper.Map<IEnumerable<TicketViewModel>>(ticketViewModel);
        }
        public bool InsertTicket(Ticket ticket)
        {
            var affectedRowsCount = _context.Execute("INSERT INTO Ticket(UserName,NumberOfSeats,ShowTime,TheatreId,MovieId,CreatedDate,UpdatedDate,DeletedDate,IsDeleted)VALUES(@UserName,@NumberOfSeats,@ShowTime,@TheatreId,@MovieId,@CreatedDate,@UpdatedDate,@DeletedDate,@IsDeleted)", new { UserName = ticket.UserName, NumberOfSeats = ticket.NumberOfSeats, ShowTime = ticket.ShowTime, TheatreId = ticket.TheatreId, MovieId = ticket.MovieId,CreatedDate=ticket.CreatedDate,UpdatedDate=ticket.UpdatedDate,DeletedDate=ticket.DeletedDate,IsDeleted=ticket.IsDeleted});
            if (affectedRowsCount == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool UpdateTicket(Ticket ticket)
        {
           return (_context.Execute("UPDATE Theatre SET (UserName=@UserName,NumberOfSeats=@NumberOfSeats,ShowTime=@ShowTime,TheatreId=@TheatreId,MovieId=@MovieId where Id=@Id", ticket)==1);

        }
        public bool DeleteTicket(int id)
        {
            return (_context.Execute("DELETE FROM Ticket where Id=@id", new { id })==1);

        }

    }
}
