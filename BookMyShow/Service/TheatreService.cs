using BookMyShow.Context;
using BookMyShow.Entities;
using BookMyShow.Contracts;
using Dapper;
using System.Data.SqlClient;
using System.Data;
using AutoMapper;
using BookMyShow.ViewModel;

namespace BookMyShow.Service
{
    public class TheatreService:ITheatreService
    {
        private readonly IDbConnection _context;
        private readonly IMapper _mapper;
        public TheatreService(AutoMapper.IMapper mapper,IConfiguration configuration)
        {
            _mapper = mapper;
            _context = new SqlConnection(configuration.GetConnectionString("SqlConnection"));
               
        }
        public IEnumerable<TheatreViewModel> GetTheatres()
        {
            var query = "SELECT * FROM Theatre";
                var theatreViewModel=_context.Query<Theatre>(query).ToList();
            return _mapper.Map<IEnumerable<TheatreViewModel>>(theatreViewModel);
            
        }
        public bool InsertTheatre(Theatre theatre)
        {
             return (_context.Execute("INSERT INTO Theatre(Name,Location)VALUES(@Name,@Location)", new { Name = theatre.Name, Location = theatre.Location }))==1;
             
           }
        public TheatreViewModel GetTheatreById(int id)
        {
            var query = "SELECT * FROM Theatre where Id=@id";
            var theatreViewModel= _context.Query<Theatre>(query, new { @Id = id }).Single();
            return _mapper.Map<TheatreViewModel>(theatreViewModel);
        }
        public bool UpdateTheatre(Theatre theatre)
        {
            return (_context.Execute("UPDATE Theatre SET Name=@Name,Location=@Location where Id=@Id",theatre)==1);
            
        }
        public bool DeleteTheatre(int id)
        {
            return (_context.Execute( "DELETE FROM Theatre where Id=@id", new {id})==1);
            
        }
        public List<Theatre> GetTheatresByMovie(int Movieid)
        {
            var query = "SELECT t.Id,t.Name,t.Location FROM Theatre t " +
                "JOIN Show s on s.TheatreId=t.Id" +
                " JOIN Movie m on m.Id=s.MovieId " +
                "where m.Id=@Id";
            return _context.Query<Theatre>(query, new {Id=Movieid}).ToList();
        }
    }
}
