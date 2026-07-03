using Microsoft.AspNetCore.Mvc;

namespace Buoi05_Layout.Controllers
{
    public class SinhVienController : Controller
    {
        public IActionResult KiemTraMaSV(string MaSV)
        {
            if(new[] { "admin", "employee" }.Contains(MaSV))
            {
                return Json($"Mã sinh viên {MaSV} không hợp lệ.");
            }
            else
            {
                return Json(true);
            }
        }

        [HttpGet]
        public IActionResult DangKy()
        {
            return View();
        }

        [HttpPost]
        public IActionResult DangKy(string hoTen)
        {
            return View("DangKyThanhCong");
        }
    }
}
