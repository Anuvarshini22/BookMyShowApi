using AutoMapper;
using BookMyShow.Context;
using BookMyShow.Contracts;
using BookMyShow.Entities;
using BookMyShow.ViewModel;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;

namespace BookMyShow.Service
{
    public class ShowService:IShowService
    {
       
            private readonly IDbConnection _context;
            private readonly IMapper _mapper;
        public ShowService(IConfiguration configuration,IMapper mapper)
        {
            _context = new SqlConnection(configuration.GetConnectionString("SqlConnection"));
            _mapper = mapper;
        }



        public IEnumerable<ShowViewModel> GetShows()
            {
                var query = "SELECT * FROM Show";
                var showViewModel= _context.Query<Show>(query).ToList();
            return _mapper.Map<IEnumerable<ShowViewModel>>(showViewModel);
               }
            public bool InsertShow(Show show)
            {
                return (_context.Execute("INSERT INTO Show(Name,ShowTime,TheatreId,MovieId,Capacity,CreatedDate,UpdatedDate,DeletedDate,IsDeleted)VALUES(@Name,@ShowTime,@TheatreId,@MovieId,@Capacity,@CreatedDate,@UpdatedDate,@DeletedDate,@IsDeleted)", new { Name = show.Name, ShowTime = show.ShowTime,  TheatreId = show.TheatreId , MovieId=show.MovieId, Capacity=show.Capacity, CreatedDate=show.CreatedDate, UpdatedDate=show.UpdatedDate, DeletedDate=show.DeletedDate, IsDeleted=show.IsDeleted })==1);
            }
        public ShowViewModel GetShowById(int id)
        {
            var query = "SELECT * FROM Show where Id=@Id";
            var showViewModel= _context.Query<Show>(query, new { Id = id }).Single();
            return _mapper.Map<ShowViewModel>(showViewModel);
        }
        public bool UpdateShow(Show show)
        {
            return (_context.Execute("UPDATE Show SET Name=@Name,ShowTime=@ShowTime,TheatreId=@TheatreId,MovieId=@MovieId,Capacity=@Capacity where Id=@Id",show)==1);
           

        }
        public bool DeleteShow(int id)
        {
           return (_context.Execute("DELETE FROM Show where Id=@id", new {id})==1);
            
        }
        public List<ShowViewModel> GetShowsByTheatre(int id)
        {
            var query = "SELECT * FROM Show where TheatreId=@TheatreId";
            var showViewModel= _context.Query<Show>(query, new {TheatreId = id }).ToList();
            return _mapper.Map<List<ShowViewModel>>(showViewModel);
        }
       
       /* public ActionResult UpdateSeats(int id,int noOfSeats)
        {
            var query = "UPDATE Show SET SeatsAvailable=seatsAvailable-@noOfSeats WHERE Id=@id";
            _context.Execute(query, new {Id = id,noOfSeats=noOfSeats});
            return null;
        }*/

    }
}
