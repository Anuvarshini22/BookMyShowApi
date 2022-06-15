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
    public class MovieService: IMovieService
    {
        private IDbConnection _context;
        private readonly IMapper _mapper;

        public MovieService(IConfiguration configuration,IMapper mapper)
        {
            _context = new SqlConnection(configuration.GetConnectionString("SqlConnection"));
            _mapper = mapper;
        }
        public IEnumerable<MovieViewModel> GetMovies()
            {
                var query = "SELECT * FROM Movie";
                var movieViewModel= _context.Query<Movie>(query).ToList();
                return _mapper.Map<IEnumerable<MovieViewModel>>(movieViewModel);
            }
        public MovieViewModel GetMovieById(int id)
        {
            var query = "SELECT * FROM Movie where Id=@Id";
            var movieViewModel= _context.Query<Movie>(query, new { @Id = id }).Single();
            return _mapper.Map<MovieViewModel>(movieViewModel); 
        }

            public bool InsertMovie(Movie movie)
            {
                    return (_context.Execute("INSERT INTO Movie(Title,Language,Genre,ImageUrl,Description,Price,CreatedDate,UpdatedDate,DeletedDate,IsDeleted)VALUES(@Title,@Language,@Genre,@ImageUrl,@Description,@Price,@CreatedDate,@UpdatedDate,@DeletedDate,@IsDeleted)", new { Title = movie.Title, Language = movie.Language, Genre = movie.Genre, ImageUrl=movie.ImageUrl, Description=movie.Description, Price=movie.price, CreatedDate=movie.CreatedDate, UpdatedDate=movie.UpdatedDate, DeletedDate=movie.DeletedDate, IsDeleted=movie.IsDeleted }))==1;
            }
        public bool UpdateMovie(Movie movie)
        {
          return  (_context.Execute("UPDATE Movie SET Title=@Title,Language=@Language,Genre=@Genre,ImageUrl=@ImageUrl,Description=@Description,Price=@Price where Id=@Id",movie)==1);
            
        }
        public bool DeleteMovie(int id)
        {
            return(_context.Execute("DELETE FROM Movie where Id=@id", new {id})==1);
           
        }
       
    }
}
