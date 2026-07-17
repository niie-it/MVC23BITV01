using Buoi07_EStoreDbFirst.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Buoi07_EStoreDbFirst.Controllers
{
    public class ThongKeController : Controller
    {
        private readonly MyeStoreContext _context;

        public ThongKeController(MyeStoreContext context)
        {
            _context = context;
        }

        public IActionResult ThongKeTheoLoai()
        {
            var data = _context.ChiTietHds
                .GroupBy(cthd => new
                {
                    TenLoai = cthd.MaHhNavigation.MaLoaiNavigation.TenLoai,
                    MaLoai = cthd.MaHhNavigation.MaLoai

                })
                .Select(g => new
                {
                    TenLoai = g.Key.TenLoai,
                    MaLoai = g.Key.MaLoai,
                    TongSoLuong = g.Sum(cthd => cthd.SoLuong),
                    TongDoanhThu = g.Sum(cthd => cthd.SoLuong * cthd.DonGia)
                })
                .ToList();
            return Json(data);
        }
    }
}
