namespace BookMyShow.ViewModel
{
    public class ShowViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ShowTime { get; set; }
        
        public int TheatreId { get; set; }
        public int MovieId { get; set; }
        public int Capacity { get; set; }
       
    }
}
