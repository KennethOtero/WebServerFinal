namespace WebServerFinal.Models
{
    public class Genres
    {
        public int GenreID { get; set; }
        public string Genre { get; set; }

        // Navigation Property
        public ICollection<Books> Books { get; set; }
    }
}
