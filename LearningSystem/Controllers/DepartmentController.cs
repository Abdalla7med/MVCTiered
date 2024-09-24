using Microsoft.AspNetCore.Mvc;

namespace LearningSystem.Controllers
{
    public class DepartmentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
