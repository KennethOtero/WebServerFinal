using System.Security.Claims;

namespace WebServerFinal.Models
{
    public class Genres
    {
        public Genres() => Book = new HashSet<Books>();
        public int GenreID { get; set; }
        public string Genre { get; set; }

        // Navigation Property
        public ICollection<Books> Book { get; set; }
    }
}
