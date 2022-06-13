namespace BookMyShow.Entities
{
    public class Theatre
    {
        public int Id { get; set; } 
        public string Name { get; set; }    
        public string Location { get; set; }
        public string CreatedDate { get; set; }
        public string UpdatedDate { get; set; }
        public string DeletedDate { get; set; }
        public bool IsDeleted { get; set; }
    }
}
