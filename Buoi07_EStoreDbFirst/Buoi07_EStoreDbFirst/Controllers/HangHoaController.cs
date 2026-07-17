using Buoi07_EStoreDbFirst.Entities;
using Buoi07_EStoreDbFirst.Models;
using Microsoft.AspNetCore.Mvc;

namespace Buoi07_EStoreDbFirst.Controllers
{
    public class HangHoaController : Controller
    {
        private readonly MyeStoreContext _context;
        public HangHoaController(MyeStoreContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Search()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Search(string Keyword, double? MinPrice, double? MaxPrice)
        {
            var query = _context.HangHoas.AsQueryable();
            if (!string.IsNullOrEmpty(Keyword))
            {
                query = query.Where(h => h.TenHh.Contains(Keyword));
            }
            if (MinPrice.HasValue)
            {
                query = query.Where(h => h.DonGia >= MinPrice.Value);
            }
            if (MaxPrice.HasValue)
            {
                query = query.Where(h => h.DonGia <= MaxPrice.Value);
            }

            var data = query.Select(h => new HangHoaVM
            {
                MaHh = h.MaHh,
                TenHh = h.TenHh,
                Hinh = h.Hinh,
                DonGia = h.DonGia ?? 0,
                TenLoai = h.MaLoaiNavigation.TenLoai,
                TenNhaCungCap = h.MaNccNavigation.TenCongTy
            }).ToList();
            return View(data);
        }
    }
}
