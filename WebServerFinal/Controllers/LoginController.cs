using Microsoft.AspNetCore.Mvc;

namespace WebServerFinal.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
