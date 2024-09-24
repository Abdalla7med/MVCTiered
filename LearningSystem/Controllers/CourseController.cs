using Microsoft.AspNetCore.Mvc;

namespace LearningSystem.Controllers
{
    public class CourseController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
