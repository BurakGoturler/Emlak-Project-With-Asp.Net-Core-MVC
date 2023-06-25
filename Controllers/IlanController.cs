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
    public class IlanController : Controller
    {
        private readonly EmlakContext _context;

        public IlanController()
        {
            _context = new EmlakContext();
        }

        // GET: Ilan
        public async Task<IActionResult> Index()
        {
            var emlakContext = _context.Ilans.Include(i => i.DurumNavigation).Include(i => i.MahalleNavigation).Include(i => i.Resims).Include(i => i.SehirNavigation).Include(i => i.SemtNavigation).Include(i => i.TipNavigation);
            return View(await emlakContext.ToListAsync());
        }

        // GET: Ilan/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Ilans == null)
            {
                return NotFound();
            }

            var ilan = await _context.Ilans
                .Include(i => i.DurumNavigation)
                .Include(i => i.MahalleNavigation)
                .Include(i => i.Resims)
                .Include(i => i.SehirNavigation)
                .Include(i => i.SemtNavigation)
                .Include(i => i.TipNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ilan == null)
            {
                return NotFound();
            }
            ViewBag.resim=_context.Resims.Where(x=>x.IlanId == id).ToList();
            return View(ilan);
        }

        // GET: Ilan/Create
        public IActionResult Create()
        {
            ViewData["Durum"] = new SelectList(_context.Durums, "Id", "Durum1");
            ViewData["Mahalle"] = new SelectList(_context.Mahalles, "Id", "Ad");
            ViewData["Resim"] = new SelectList(_context.Resims, "Id", "Id");
            ViewData["Sehir"] = new SelectList(_context.Sehirs, "Id", "Ad");
            ViewData["Semt"] = new SelectList(_context.Semts, "Id", "Ad");
            ViewData["Tip"] = new SelectList(_context.Tips, "Id", "Tip1");
            return View();
        }

        // POST: Ilan/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([FromForm] Ilan ilan)
        {



            if (ModelState.IsValid)
            {
                _context.Add(ilan);
                if (ilan.ImageFile != null && ilan.ImageFile.Count> 0)
					{
                    foreach (var item in ilan.ImageFile) { 
						var uniqueFileName = Guid.NewGuid().ToString() + "_" + item.FileName;
						var filePath = Path.Combine(Directory.GetCurrentDirectory(), "image", uniqueFileName);

						using (var fileStream = new FileStream(filePath, FileMode.Create))
						{
							await item.CopyToAsync(fileStream);
						}

						// Resim dosyasının yolunu veritabanına kaydet
						var resim = new Resim
						{
							Resim1= filePath // veya sadece resim dosyasının adını kaydetmek isterseniz: uniqueFileName
											// Diğer özellikler
						};

						// DbContext üzerinden veritabanına ekleme işlemini gerçekleştirin
                        ilan.Resims.Add(resim);
					}
                }

                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Durum"] = new SelectList(_context.Durums, "Id", "Durum1", ilan.Durum);
            ViewData["Mahalle"] = new SelectList(_context.Mahalles, "Id", "Ad", ilan.Mahalle);
            ViewData["Sehir"] = new SelectList(_context.Sehirs, "Id", "Ad", ilan.Sehir);
            ViewData["Semt"] = new SelectList(_context.Semts, "Id", "Ad", ilan.Semt);
            ViewData["Tip"] = new SelectList(_context.Tips, "Id", "Tip1", ilan.Tip);
            return View(ilan);
        }

        // GET: Ilan/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Ilans == null)
            {
                return NotFound();
            }

            var ilan = await _context.Ilans.FindAsync(id);
            if (ilan == null)
            {
                return NotFound();
            }
            ViewData["Durum"] = new SelectList(_context.Durums, "Id", "Durum1", ilan.Durum);
            ViewData["Mahalle"] = new SelectList(_context.Mahalles, "Id", "Ad", ilan.Mahalle);
            ViewData["Sehir"] = new SelectList(_context.Sehirs, "Id", "Ad", ilan.Sehir);
            ViewData["Semt"] = new SelectList(_context.Semts, "Id", "Ad", ilan.Semt);
            ViewData["Tip"] = new SelectList(_context.Tips, "Id", "Tip1", ilan.Tip);
            return View(ilan);
        }

        // POST: Ilan/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Fiyat,Durum,Tip,Alan,OdaSayisi,BanyoSayisi,Kat,Adres,Mahalle,Semt,Sehir,Telefon,Tarih,Aciklama,Resim")] Ilan ilan)
        {
            if (id != ilan.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ilan);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!IlanExists(ilan.Id))
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
            ViewData["Durum"] = new SelectList(_context.Durums, "Id", "Durum1", ilan.Durum);
            ViewData["Mahalle"] = new SelectList(_context.Mahalles, "Id", "Ad", ilan.Mahalle);
            ViewData["Sehir"] = new SelectList(_context.Sehirs, "Id", "Ad", ilan.Sehir);
            ViewData["Semt"] = new SelectList(_context.Semts, "Id", "Ad", ilan.Semt);
            ViewData["Tip"] = new SelectList(_context.Tips, "Id", "Tip1", ilan.Tip);
            return View(ilan);
        }

        // GET: Ilan/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Ilans == null)
            {
                return NotFound();
            }

            var ilan = await _context.Ilans
                .Include(i => i.DurumNavigation)
                .Include(i => i.MahalleNavigation)
                .Include(i => i.Resims)
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

        // POST: Ilan/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Ilans == null)
            {
                return Problem("Entity set 'EmlakContext.Ilans'  is null.");
            }
            var ilan = await _context.Ilans.FindAsync(id);
            if (ilan != null)
            {
                _context.Ilans.Remove(ilan);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool IlanExists(int id)
        {
          return (_context.Ilans?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
