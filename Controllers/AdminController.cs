using Emlak.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Emlak.Controllers
{
	public class AdminController : Controller
	{
		[Authorize(Roles = "1")] // Index metoduna sadece 1 id'sine sahip rol erişebilir. Yetkinlendirme yapıyoruz. Sadece Admin rolünün admnin paneline erişmesini sağladık.
		public IActionResult Index()
		{
			return View();
		}
    }
}