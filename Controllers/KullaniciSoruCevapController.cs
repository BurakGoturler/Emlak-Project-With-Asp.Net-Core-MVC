using Emlak.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Emlak.Controllers
{
    public class KullaniciSoruCevapController : Controller
    {
        private readonly EmlakContext _context;

        public KullaniciSoruCevapController()
        {
            _context = new EmlakContext();
        }

        public async Task<IActionResult> Index()
        {
            return _context.SoruCevaps != null ? // context.SoruCevaps eğer boş değilse döndür.
						View(await _context.SoruCevaps.Where(x => x.Cevap != null).ToListAsync()) : // cevabı olmayan soruları listeleme
                        Problem("Entity set 'EmlakContext.SoruCevaps'  is null.");
        }

        public IActionResult Create()
        {
            return View();
        }

        // POST: SoruCevap/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Ad,Tarih,Soru")] SoruCevap soruCevap)
        {
            if (ModelState.IsValid)
            {
                _context.Add(soruCevap);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(soruCevap);
        }
    }
}