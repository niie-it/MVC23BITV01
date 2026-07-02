using Day03_Lab2._2.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace Day03_Lab2._2.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult Create()
        {
            return View();
        }
        string DIR_PATH = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");
        [HttpPost]
        public IActionResult Create(Student student, string btnSave)
        {
            if (ModelState.IsValid)
            {
                if (btnSave == "Save JSON")
                {
                    var jsonStr = JsonSerializer.Serialize(student);
                    var fullPath = Path.Combine(DIR_PATH, "student.json");
                    System.IO.File.WriteAllText(fullPath, jsonStr);
                }
            }
            return View();
        }
    }
}
