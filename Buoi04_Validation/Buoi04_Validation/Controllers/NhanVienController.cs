using Buoi04_Validation.Models;
using Microsoft.AspNetCore.Mvc;

namespace Buoi04_Validation.Controllers
{
    public class NhanVienController : Controller
    {
        [HttpGet]
        public IActionResult DangKy()
        {
            return View();
        }

        [HttpPost]
        public IActionResult DangKy(NhanVien nhanVien)
        {
            if (ModelState.IsValid)
            {
                // Xử lý dữ liệu hợp lệ
                ModelState.AddModelError("", "Đăng ký thành công!");
            }
            return View(nhanVien);
        }
    }
}
