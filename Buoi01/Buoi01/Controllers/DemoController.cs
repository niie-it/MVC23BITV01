using Microsoft.AspNetCore.Mvc;

namespace Buoi01.Controllers
{
    public class DemoController : Controller
    {
        public string Index()
        {
            return "Demo/Index nhé. Hello, ASP.NET Core!";
        }

        public string Hello(string name = "Tèo")
        {
            return $"Hello {name}!";
        }

        public int LuckyNumber()
        {
            return new Random().Next(1, 1000);
        }
    }
}
