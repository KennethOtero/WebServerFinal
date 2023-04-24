using System.ComponentModel.DataAnnotations;

namespace WebServerFinal.Models
{
    public class Books
    {
        // Primary Key
        public int BookID { get; set; }
        
        [Required(ErrorMessage = "Please enter the title of the book.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Please enter the name of the author.")]
        public string Author { get; set; }

        [Required(ErrorMessage = "Please enter the status of the book.")]
        public bool IsRented { get; set; }

        // Foreign keys and their navigation properties
        [Required(ErrorMessage = "Please enter the genre of the book.")] 
        public int GenreID { get; set; }
        public Genres? Genres { get; set; }

        // FK allows nulls since a book may not be checked out
        public int? UserID { get; set; } 
        public Users? Users { get; set; }
    }
}
