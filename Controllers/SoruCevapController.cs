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
    public class SoruCevapController : Controller
    {
        private readonly EmlakContext _context;

        public SoruCevapController()
        {
            _context = new EmlakContext();
        }

        // GET: SoruCevap
        public async Task<IActionResult> Index()
        {
              return _context.SoruCevaps != null ? 
                          View(await _context.SoruCevaps.ToListAsync()) :
                          Problem("Entity set 'EmlakContext.SoruCevaps'  is null.");
        }

        // GET: SoruCevap/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.SoruCevaps == null)
            {
                return NotFound();
            }

            var soruCevap = await _context.SoruCevaps
                .FirstOrDefaultAsync(m => m.Id == id);
            if (soruCevap == null)
            {
                return NotFound();
            }

            return View(soruCevap);
        }

        // GET: SoruCevap/Create
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

        // GET: SoruCevap/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.SoruCevaps == null)
            {
                return NotFound();
            }

            var soruCevap = await _context.SoruCevaps.FindAsync(id);
            if (soruCevap == null)
            {
                return NotFound();
            }
            return View(soruCevap);
        }

        // POST: SoruCevap/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [FromForm] SoruCevap soruCevap)
        {
            if (id != soruCevap.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(soruCevap);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SoruCevapExists(soruCevap.Id))
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
            return View(soruCevap);
        }

        // GET: SoruCevap/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.SoruCevaps == null)
            {
                return NotFound();
            }

            var soruCevap = await _context.SoruCevaps
                .FirstOrDefaultAsync(m => m.Id == id);
            if (soruCevap == null)
            {
                return NotFound();
            }

            return View(soruCevap);
        }

        // POST: SoruCevap/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.SoruCevaps == null)
            {
                return Problem("Entity set 'EmlakContext.SoruCevaps'  is null.");
            }
            var soruCevap = await _context.SoruCevaps.FindAsync(id);
            if (soruCevap != null)
            {
                _context.SoruCevaps.Remove(soruCevap);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SoruCevapExists(int id)
        {
          return (_context.SoruCevaps?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
