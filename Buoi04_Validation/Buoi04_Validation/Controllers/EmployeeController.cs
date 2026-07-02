using Buoi04_Validation.Models;
using Microsoft.AspNetCore.Mvc;

namespace Buoi04_Validation.Controllers
{
    public class EmployeeController : Controller
    {
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(Employee employee)
        {
            if (ModelState.IsValid)
            {
                // Xử lý dữ liệu hợp lệ
                ModelState.AddModelError("", "Đăng ký thành công!");
            }
            return View(employee);
        }
    }
}
