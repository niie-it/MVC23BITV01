using Buoi04_Validation.Models;
using Microsoft.AspNetCore.Mvc;

namespace Buoi04_Validation.Controllers
{
    public class EmployeeController : Controller
    {
        public IActionResult CheckEmployeeNo(string EmployeeNo)
        {
            var emps = new List<string> { string.Empty, "admin", "employee", "EMP003" }; //fake data
            if (emps.Contains(EmployeeNo))
            {
                return Json($"Mã nhân viên {EmployeeNo} đã tồn tại");
            }
            return Json(true);
        }

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
