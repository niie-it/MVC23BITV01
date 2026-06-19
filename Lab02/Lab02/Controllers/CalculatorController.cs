using Microsoft.AspNetCore.Mvc;

namespace Lab02.Controllers
{
    public class CalculatorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Calculate(double SoHang01, double SoHang02, string operation)
        {
            double result = 0;
            switch (operation)
            {
                case "add": result = SoHang01 + SoHang02; break;
                case "subtract": result = SoHang01 - SoHang02; break;
                case "multiply": result = SoHang01 * SoHang02; break;
                case "divide":
                    if (SoHang02 == 0)
                    {
                        ViewBag.Error = "Cannot divide by zero.";
                    }
                    else
                    {
                        result = SoHang01 / SoHang02;
                    }
                    break;
                case "mod": result = SoHang01 % SoHang02; break;
                case "exp": result = Math.Pow(SoHang01, SoHang02); break;
            }
            ViewBag.Result = result;
            ViewBag.Operation = operation;
            ViewBag.SoHang01 = SoHang01;
            ViewBag.SoHang02 = SoHang02;
            return View("Index");
        }
    }
}
