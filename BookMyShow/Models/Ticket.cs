namespace BookMyShow.Models
{
    public class Ticket
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public int NumberOfSeats { get; set; }
        public string ShowTime { get; set; }
        public int TheatreId { get; set; }  
        public int MovieId { get; set; }
        public string CreatedDate { get; set; }
        public string UpdatedDate { get; set; }
        public string DeletedDate { get; set; }
        public bool IsDeleted { get; set; }
    }
}
