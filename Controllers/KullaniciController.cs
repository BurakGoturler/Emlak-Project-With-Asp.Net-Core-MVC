using Emlak.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Emlak.Controllers
{
    public class KullaniciController : Controller
    {

        private readonly EmlakContext _context;

        public KullaniciController()
        {
            _context = new EmlakContext();
        }

        public async Task<IActionResult> Index()
        {
            var emlakContext = _context.Ilans.Include(i => i.DurumNavigation).Include(i => i.MahalleNavigation).Include(i => i.ResimNavigation).Include(i => i.SehirNavigation).Include(i => i.SemtNavigation).Include(i => i.TipNavigation);
            return View(await emlakContext.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Ilans == null)
            {
                return NotFound();
            }

            var ilan = await _context.Ilans
                .Include(i => i.DurumNavigation)
                .Include(i => i.MahalleNavigation)
                .Include(i => i.ResimNavigation)
                .Include(i => i.SehirNavigation)
                .Include(i => i.SemtNavigation)
                .Include(i => i.TipNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ilan == null)
            {
                return NotFound();
            }
            return View(ilan);
        }
    }
}