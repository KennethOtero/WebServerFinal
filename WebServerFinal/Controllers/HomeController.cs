using Microsoft.AspNetCore.Mvc;
using WebServerFinal.Models;
using WebServerFinal.Models.DataLayer;

namespace WebServerFinal.Controllers
{
    public class HomeController : Controller
    {
        private Repository<Books> books { get; set; }

        public HomeController(BooksDBContext ctx)
        {
            books = new Repository<Books>(ctx);
        }

        public ViewResult Index(int id)
        {
            var bookOptions = new QueryOptions<Books>
            {
                Includes = "Genres"
            };
            if (id == 0)
            {
                bookOptions.OrderBy = c => c.BookID;
            }
            else
            {
                bookOptions.Where = c => c.BookID == id;
            }

            var booklist = books.List(bookOptions);

            ViewBag.Id = id;
            return View(booklist);
        }

        public IActionResult About()
        {
            // Display about page
            return View();
        }

    }
}
