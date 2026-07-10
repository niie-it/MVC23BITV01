using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Buoi06_EFCore_CodeFirst.Models;

namespace Buoi06_EFCore_CodeFirst.Controllers
{
    public class HangHoasController : Controller
    {
        private readonly MyDbContext _context;

        public HangHoasController(MyDbContext context)
        {
            _context = context;
        }

        // GET: HangHoas
        public async Task<IActionResult> Index()
        {
            var myDbContext = _context.HangHoas.Include(h => h.Loai);
            return View(await myDbContext.ToListAsync());
        }

        // GET: HangHoas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hangHoa = await _context.HangHoas
                .Include(h => h.Loai)
                .FirstOrDefaultAsync(m => m.MaHh == id);
            if (hangHoa == null)
            {
                return NotFound();
            }

            return View(hangHoa);
        }

        // GET: HangHoas/Create
        public IActionResult Create()
        {
            ViewData["MaLoai"] = new SelectList(_context.Loais, "MaLoai", "TenLoai");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaHh,TenHh,DonGia,SoLuong,MaLoai")] HangHoa hangHoa, IFormFile Hinh)
        {
            if (ModelState.IsValid)
            {
                if (Hinh != null)
                {
                    hangHoa.Hinh = await MyTool.UploadFileToFolder(Hinh, "products");
                }
                _context.Add(hangHoa);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MaLoai"] = new SelectList(_context.Loais, "MaLoai", "TenLoai", hangHoa.MaLoai);
            return View(hangHoa);
        }

        // GET: HangHoas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hangHoa = await _context.HangHoas.FindAsync(id);
            if (hangHoa == null)
            {
                return NotFound();
            }
            ViewData["MaLoai"] = new SelectList(_context.Loais, "MaLoai", "TenLoai", hangHoa.MaLoai);
            return View(hangHoa);
        }

        // POST: HangHoas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MaHh,TenHh,DonGia,SoLuong,Hinh,MaLoai")] HangHoa hangHoa, IFormFile HinhEdit)
        {
            if (id != hangHoa.MaHh)
            {
                return NotFound();
            }

            if (HinhEdit != null)
            {
                var urlTmp = await MyTool.UploadFileToFolder(HinhEdit, "products");
                if (!string.IsNullOrEmpty(urlTmp))
                {
                    hangHoa.Hinh = urlTmp;
                }
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hangHoa);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HangHoaExists(hangHoa.MaHh))
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
            ViewData["MaLoai"] = new SelectList(_context.Loais, "MaLoai", "TenLoai", hangHoa.MaLoai);
            return View(hangHoa);
        }

        // GET: HangHoas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hangHoa = await _context.HangHoas
                .Include(h => h.Loai)
                .FirstOrDefaultAsync(m => m.MaHh == id);
            if (hangHoa == null)
            {
                return NotFound();
            }

            return View(hangHoa);
        }

        // POST: HangHoas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var hangHoa = await _context.HangHoas.FindAsync(id);
            if (hangHoa != null)
            {
                _context.HangHoas.Remove(hangHoa);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HangHoaExists(int id)
        {
            return _context.HangHoas.Any(e => e.MaHh == id);
        }
    }
}
