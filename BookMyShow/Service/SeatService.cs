using AutoMapper;
using BookMyShow.Context;
using BookMyShow.Contracts;
using BookMyShow.Entities;
using BookMyShow.ViewModel;
using Dapper;
using System.Data;
using System.Data.SqlClient;

namespace BookMyShow.Service
{
    public class SeatService:ISeatService
    {
        private readonly IDbConnection _context;
        private readonly IMapper _mapper;
        public SeatService(IConfiguration configuration, IMapper mapper)
        {
            _context = new SqlConnection(configuration.GetConnectionString("SqlConnection"));
            _mapper = mapper;

        }
        public IEnumerable<SeatViewModel> GetSeat()
        {
            var query = "SELECT * FROM Seat";
            var seatViewModel = _context.Query<Seat>(query).ToList();
            return _mapper.Map<IEnumerable<SeatViewModel>>(seatViewModel);
           }
        public bool InsertSeat(Seat seat)
        {
           return (_context.Execute("INSERT INTO Seat(Number,ShowTime,ShowId,TheatreId,MovieId,TicketId,Availability)VALUES(@Number,@ShowTime,@ShowId,@TheatreId,@MovieId,@TicketId,@Availability)", new { Number=seat.Number, ShowTime=seat.ShowTime,ShowId=seat.ShowId, TheatreId=seat.TheatreId, MovieId=seat.MovieId,TicketId=seat.TicketId,Availability=seat.Availability }))==1;
            
        }
        
        public SeatViewModel GetSeatById(int id)
        {
            var query = "SELECT * FROM Seat where Id=@Id";
            var seatViewModel= _context.Query<Seat>(query, new { Id = id }).Single();
            return _mapper.Map<SeatViewModel>(seatViewModel);
        }
        public bool UpdateSeat(Seat seat)
        {
           return (_context.Execute("UPDATE Seat SET Number=@Number,ShowId=@ShowId,TheatreId=@TheatreId,MovieId=@MovieId,TicketId=@TicketId,Availability=@Availability where Id=@Id",seat)==1);
            
        }
        public bool DeleteSeat(int id)
        {
            return (_context.Execute("DELETE FROM Seat where Id=@id", new {id})==1);
            
        }
        public List<SeatViewModel> GetSeatByShow(int id)
        {
            var query = "SELECT * FROM Seat where ShowId=@ShowId";
            var seatViewModel= _context.Query<Seat>(query, new { ShowId = id }).ToList();
            return _mapper.Map<List<SeatViewModel>>(seatViewModel);
        }
        public void ChangeAvailability(int ticketId,Seat seat)
        {
            seat.Availability = (seat.Availability == "Available") ? "Occupied" : "Available";
            var query = "UPDATE Seat SET Number=@Number,ShowTime=@ShowTime,ShowId=@ShowId,TheatreId=@TheatreId,MovieId=@MovieId,TicketId=@TicketId,Availability=@Availability where Number=@Number and TheatreId=@TheatreId and MovieId=@MovieId";
            _context.Execute(query, new { @Number = seat.Number,@ShowTime=seat.ShowTime,@ShowId=seat.ShowId, @TheatreId = seat.TheatreId, @MovieId = seat.MovieId, @TicketId = seat.TicketId, @Availability = seat.Availability });
        }
    }
}
