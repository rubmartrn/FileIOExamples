using Microsoft.AspNetCore.Mvc;
using UniversityProgram.Mvc.Models;

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
            TempData["StudentName"] = "Պողոս";
            return RedirectToAction(nameof(Index));
        }

        public IActionResult UserPage()
        {
            var user = new UserViewModel() { Age = 20, Name = "Բարդուղեմիոս" };
            return View("User", user);
        }
    }
}
