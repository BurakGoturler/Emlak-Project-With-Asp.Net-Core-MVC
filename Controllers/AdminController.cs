using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Emlak.Controllers
{
	public class AdminController : Controller
	{
		[Authorize(Roles = "1")]
		public IActionResult Index()
		{
			return View();
		}
	}
}