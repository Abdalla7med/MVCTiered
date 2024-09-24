using Microsoft.AspNetCore.Mvc;

namespace LearningSystem.Controllers
{
    public class TraineeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
