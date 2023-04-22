using System.ComponentModel.DataAnnotations;

namespace WebServerFinal.Models
{
    public class Users
    {
        public int UserID { get; set; }

        [Required(ErrorMessage = "Please enter your name.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter the your email address.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please enter the your password.")]
        public string Password { get; set; }

        // Navigation Property
        public ICollection<Books> Books { get; set; }
    }
}
