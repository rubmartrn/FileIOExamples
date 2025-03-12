using Microsoft.AspNetCore.Mvc;
using UniversityProgram.Mvc.Models;

namespace UniversityProgram.Mvc.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult Index()
        {
            TempData["Student"] = "Մարտիրոս";
            var result = new List<UserViewModel>()
            {
                new UserViewModel()
                {
                    Name = "Պողոս",
                    Age = 56,
                    ImageUrl = "https://www.google.com/images/branding/googlelogo/1x/googlelogo_color_272x92dp.png"
,                },
                new UserViewModel()
                {
                    Name = "Մարտիրոս",
                    Age = 23,
                    ImageUrl = "https://plus.unsplash.com/premium_photo-1686245735403-a01147d86b89?q=80&w=1974&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D"
                },
                new UserViewModel()
                {
                    Name = "Անուշ",
                    Age = 45,
                    ImageUrl = "https://images.unsplash.com/photo-1741526798351-50eeb46b2a06?q=80&w=1974&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D"
                },
                new UserViewModel()
                {
                    Name = "Բարդուղեմիոս",
                    Age = 34
                }
            };
            return View(result);
        }

        public IActionResult New()
        {
            return View(8);
        }

        public IActionResult UserPage()
        {
            var user = new UserViewModel() { Age = 20, Name = "Բարդուղեմիոս" };
            return View("User", user);
        }
    }
}
