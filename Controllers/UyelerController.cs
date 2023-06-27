using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Emlak.Models;

namespace Emlak.Controllers
{
    public class UyelerController : Controller
    {
        private readonly EmlakContext _context;

        public UyelerController( )
        {
            _context = new EmlakContext();
        }

        // GET: Uyeler
        public async Task<IActionResult> Index()
        {
            var emlakContext = _context.Kullanicilars.Include(k => k.Rol);
            return View(await emlakContext.ToListAsync());
        }

        // GET: Uyeler/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Kullanicilars == null)
            {
                return NotFound();
            }

            var kullanicilar = await _context.Kullanicilars
                .Include(k => k.Rol)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (kullanicilar == null)
            {
                return NotFound();
            }

            return View(kullanicilar);
        }

        // GET: Uyeler/Create
        public IActionResult Create()
        {
            ViewData["RolId"] = new SelectList(_context.Rols, "Id", "Ad");
            return View();
        }

        // POST: Uyeler/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([FromForm] Kullanicilar kullanicilar)
        {
            if (ModelState.IsValid)
            {
                _context.Add(kullanicilar);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["RolId"] = new SelectList(_context.Rols, "Id", "Ad", kullanicilar.RolId);
            return View(kullanicilar);
        }

        // GET: Uyeler/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Kullanicilars == null)
            {
                return NotFound();
            }

            var kullanicilar = await _context.Kullanicilars.FindAsync(id);
            if (kullanicilar == null)
            {
                return NotFound();
            }
            ViewData["RolId"] = new SelectList(_context.Rols, "Id", "Ad", kullanicilar.RolId);
            return View(kullanicilar);
        }

        // POST: Uyeler/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Ad,Soyad,KullaniciAdi,Sifre,RolId")] Kullanicilar kullanicilar)
        {
            if (id != kullanicilar.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(kullanicilar);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KullanicilarExists(kullanicilar.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["RolId"] = new SelectList(_context.Rols, "Id", "Id", kullanicilar.RolId);
            return View(kullanicilar);
        }

        // GET: Uyeler/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Kullanicilars == null)
            {
                return NotFound();
            }

            var kullanicilar = await _context.Kullanicilars
                .Include(k => k.Rol)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (kullanicilar == null)
            {
                return NotFound();
            }

            return View(kullanicilar);
        }

        // POST: Uyeler/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Kullanicilars == null)
            {
                return Problem("Entity set 'EmlakContext.Kullanicilars'  is null.");
            }
            var kullanicilar = await _context.Kullanicilars.FindAsync(id);
            if (kullanicilar != null)
            {
                _context.Kullanicilars.Remove(kullanicilar);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KullanicilarExists(int id)
        {
          return (_context.Kullanicilars?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
