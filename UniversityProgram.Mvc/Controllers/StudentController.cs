using Microsoft.AspNetCore.Mvc;

namespace UniversityProgram.Mvc.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.StudentName = "John";
            ViewBag.Title = 4;
            ViewBag.dskfjhsdkf = "Բարև ձեզ";
            return View();
        }

        public IActionResult New()
        {
            return View();
        }
    }
}
