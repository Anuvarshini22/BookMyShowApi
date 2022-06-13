using AutoMapper;
using BookMyShow.Entities;
using BookMyShow.Models;

namespace BookMyShow.ViewModel
{
    public class AutoMapperProfile:Profile
    {
        public AutoMapperProfile()
        {
          
                 CreateMap<Theatre, TheatreViewModel>();
                 CreateMap<Show, ShowViewModel>();
                 CreateMap<Seat, SeatViewModel>();
                 CreateMap<Ticket, TicketViewModel>();
                 CreateMap<Movie, MovieViewModel>();
           
        }
    }
}
