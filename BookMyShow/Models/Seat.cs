using BookMyShow.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookMyShow.Entities
{
    public class Seat
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public string ShowTime { get; set; }
        public int ShowId { get; set; }
        public int TheatreId { get; set; }
        public int MovieId { get; set; } 
       
        public int TicketId { get; set; }

        [EnumDataType(typeof(SeatStatus))]
       public string Availability { get; set; }
       
    }
}
