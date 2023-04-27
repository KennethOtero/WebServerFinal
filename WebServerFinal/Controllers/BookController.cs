using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebServerFinal.Models;
using WebServerFinal.Models.DataLayer;
using static System.Reflection.Metadata.BlobBuilder;

namespace WebServerFinal.Controllers
{
    public class BookController : Controller
    {
        private Repository<Books> books { get; set; }

        private Repository<Genres> genres { get; set; }

        private BooksDBContext context { get; set; }

        public BookController(BooksDBContext ctx)
        {
            books = new Repository<Books>(ctx);
            genres = new Repository<Genres>(ctx);
            context = ctx;
        }

        public RedirectToActionResult Index() => RedirectToAction("Index","Home");

        [HttpGet]
        public ViewResult Add()
        {
            this.LoadViewBag("Add");
            return View("Add", new Books());
        }

        [HttpPost]
        public IActionResult Add(Books c)
        {
            bool isAdd = c.BookID == 0;

            if (ModelState.IsValid)
            {
                if (isAdd)
                    books.Insert(c);
                else
                    books.Update(c);
                books.Save();
                return RedirectToAction("Index", "Home");
            }
            else
            {
                string operation = (isAdd) ? "Add" : "Edit";
                this.LoadViewBag(operation);
                return View("Add", c);
            }
        }

        [HttpGet]
        public ViewResult Delete(int id)
        {
            var c = this.GetBook(id);
            return View(c);
        }

        [HttpPost]
        public RedirectToActionResult Delete(Books c)
        {
            books.Delete(c);
            books.Save();
            return RedirectToAction("Index", "Home");
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Action = "Edit";
            ViewBag.Genres = context.Genres.OrderBy(g => g.Genre).ToList();
            var c = context.Books.Find(id);
            return View(c);
        }

        [HttpPost]
        public IActionResult Edit(Books c)
        {
           

            if (ModelState.IsValid)
            {
                if (c.BookID == 0)
                    books.Insert(c);
                else
                    books.Update(c);
                    books.Save();
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Action = (c.BookID == 0) ? "Add" : "Edit";
                ViewBag.Genres = context.Genres.OrderBy(g => g.Genre).ToList();
                return View(c);
            }
        }
        private Books GetBook(int id)
        {
            var classOptions = new QueryOptions<Books>
            {
                Includes = "Genres",
                Where = c => c.BookID == id
            };
            return books.Get(classOptions) ?? new Books();
        }
        
            private void LoadViewBag(string operation)
            {
                ViewBag.Genres = genres.List(new QueryOptions<Genres>
            {
                OrderBy = g => g.GenreID
            });
                ViewBag.Operation = operation;
            }
        
    }
}

