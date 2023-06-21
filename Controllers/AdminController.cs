using Microsoft.AspNetCore.Mvc;

namespace Emlak.Controllers
{
	public class AdminController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
