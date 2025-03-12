using Microsoft.AspNetCore.Mvc;

namespace UniversityProgram.Mvc.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult Index()
        {
            TempData["Student"] = "Մարտիրոս";
            return View();
        }

        public IActionResult New()
        {
            return View();
        }
    }
}
