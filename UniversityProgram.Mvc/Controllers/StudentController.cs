using Microsoft.AspNetCore.Mvc;

namespace UniversityProgram.Mvc.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult Index()
        {
            ViewData["StudentName"] = "John";
            ViewData["StudentAge"] = 20;
            return View();
        }

        public IActionResult New()
        {
            return View();
        }
    }
}
