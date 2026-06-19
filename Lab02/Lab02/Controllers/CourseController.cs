using Lab02.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lab02.Controllers
{
    public class CourseController : Controller
    {
        static List<Course> courses = new List<Course>
        {
            new Course { Id = 1, Name = "Mathematics", Credits = 3, TheoryHours = 45 },
            new Course { Id = 2, Name = "ASP.NET Core MVC", Credits = 3, TheoryHours = 30 },
            new Course { Id = 3, Name = "Windows Form", Credits = 3, TheoryHours = 15 }
        };
        public IActionResult Index()
        {
            return View(courses);
            //return View("Index", courses);
        }


        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Course course)
        {
            if (ModelState.IsValid)
            {
                courses.Add(course);
                return RedirectToAction(nameof(Index));
            }
            return View(course);
        }

        public IActionResult Edit(int id)
        {
            var course = courses.FirstOrDefault(c => c.Id == id);
            if (course == null) return NotFound();
            return View(course);
        }

        [HttpPost]
        public IActionResult Edit(Course course)
        {
            if (ModelState.IsValid)
            {
                //update fields of Course model
                var existingCourse = courses.FirstOrDefault(c => c.Id == course.Id);
                if (existingCourse == null) return NotFound();
                existingCourse.Name = course.Name;
                existingCourse.Credits = course.Credits;
                existingCourse.TheoryHours = course.TheoryHours;
            }
            return View(course);
        }
    }
}
