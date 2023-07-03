using Emlak.Models;
using Emlak.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Emlak.Controllers
{
	public class AccountController : Controller
	{
		private readonly EmlakContext _context;
		public AccountController()
		{
			_context = new EmlakContext();
		}				

		public IActionResult Login()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Login([FromForm] LoginViewModel entity)
		{
			try
			{
				// view'den gelen model'de bir sıkıntı var mı ? eğer bir sorun varsa başka yere gidecek yoksa devam edecek.
				if (ModelState.IsValid)
				{
					// Alınan veriler doğru ise
					if (CheckUser(entity.KullaniciAdi, entity.Sifre))  // eğer varsa
					{
						var LogedUser = _context.Kullanicilars.FirstOrDefault(X => X.KullaniciAdi == entity.KullaniciAdi && X.Sifre == entity.Sifre);
                        var claims = new List<Claim>
                        {
                             new Claim(ClaimTypes.NameIdentifier, entity.KullaniciAdi), new Claim(ClaimTypes.Role, LogedUser.RolId.ToString())
                        };

                        ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
						ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

						await HttpContext.SignInAsync( CookieAuthenticationDefaults.AuthenticationScheme, claimsPrincipal);

						if (LogedUser.RolId == 1)
						{
                            return RedirectToAction("Index", "Admin");
						}
						else
						{
                            return RedirectToAction("Index", "Kullanici");
                        }
                    }
					else // eğer yoksa
					{
						throw new Exception("Böyle bir kullanıcı bulunamadı.");
					}
				}
				else
				{
					throw new Exception("lütfen form verilerini kontrol edin"); // HATA GÖNDERİYOR.
				}
			}
			catch (Exception ex)
			{
				TempData["msg"] = ex.Message;
			}
			return View(entity);
		}

		public async Task<IActionResult> Logout()
		{
			try
			{
				await HttpContext.SignOutAsync();
			}
			catch (Exception ex)
			{
				TempData["msg"] = ex.Message;
			}
			return RedirectToAction("Login", "Account");
		}

		// GET: Uyeler/Create
		public IActionResult Register()
		{
			return View();
		}

		// POST: Uyeler/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Register([FromForm] Kullanicilar kullanicilar)
		{
			if (ModelState.IsValid)
			{
				kullanicilar.RolId	= 12;

				_context.Add(kullanicilar);
				await _context.SaveChangesAsync();
				return RedirectToAction(nameof(Login));
			}
			return View(kullanicilar);
		}

		private bool CheckUser(string userName, string password)	
		{
			var user = _context.Kullanicilars.FirstOrDefault(x => x.KullaniciAdi == userName && x.Sifre == password);

			return user != null;
		}
	}
}