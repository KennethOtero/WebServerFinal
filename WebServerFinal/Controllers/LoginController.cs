using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebServerFinal.Models;
using WebServerFinal.Models.DataLayer;

namespace WebServerFinal.Controllers
{
    public class LoginController : Controller
    {
        private BooksDBContext context;
        private readonly IHttpContextAccessor myHttpContext;
        private Repository<Users> Users { get; set; }

        public LoginController(BooksDBContext ctx, IHttpContextAccessor httpContextAccessor)
        {
            Users = new Repository<Users>(ctx);
            context = ctx;
            myHttpContext = httpContextAccessor;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(Users user)
        {
            // Check if user exists
            var userExists = context.Users.FromSqlRaw($"SELECT * FROM dbo.Users WHERE Email = '{user.Email}' AND Password = '{user.Password}'").ToList();

            if (userExists.Count > 0)
            {
                // Create session key with UserID
                HttpContext.Session.SetString("UserID", userExists[0].UserID.ToString());

                // Redirect to homepage
                return RedirectToAction("Index", "Home");
            }

            // Display error message
            ModelState.AddModelError("Email", "This account does not exist.");
            return View("Index");

        }

        [HttpGet]
        public ViewResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(Users user, string confirmPassword)
        {
            // Check if passwords match
            if (!user.Password.Equals(confirmPassword))
            {
                ModelState.AddModelError("Password", "Passwords do not match.");
            }

            // Check if email already exists
            var emailExists = context.Users.FromSqlRaw($"SELECT * FROM dbo.Users WHERE Email = '{user.Email}'").ToList();
            if (emailExists.Count > 0)
            {
                ModelState.AddModelError("Email", "Email already exists.");
            }

            bool isAdd = user.UserID == 0;

            if (ModelState.IsValid)
            {
                if (isAdd)
                    Users.Insert(user);
                else
                    Users.Update(user);
                Users.Save();

                // Get new user ID
                var userExists = context.Users.FromSqlRaw($"SELECT * FROM dbo.Users WHERE Email = '{user.Email}' AND Password = '{user.Password}'").ToList();

                // Create session
                HttpContext.Session.SetString("UserID", userExists[0].UserID.ToString());

                // Go to homepage
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("Email", "Error creating account. Please try again.");
                return View();
            }
        }

        [HttpGet]
        public ViewResult LogOut()
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult LogOutAction()
        {
            // Remove session
            HttpContext.Session.Clear();
            HttpContext.Session.Remove("UserId");

            // Go to homepage
            return RedirectToAction("Index", "Home");
        }
    }
}
