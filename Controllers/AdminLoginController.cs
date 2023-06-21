using Microsoft.AspNetCore.Mvc;

namespace Emlak.Controllers
{
    public class AdminLoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
