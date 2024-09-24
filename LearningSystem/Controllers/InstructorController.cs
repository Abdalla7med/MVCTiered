using LearningSystem.DAL;
using LearningSystem.DAL.Repositories_Implementation;
using Microsoft.AspNetCore.Mvc;

namespace LearningSystem.Controllers
{
    public class InstructorController : Controller
    {
        private readonly IInstructorRepository _instructorRepository;
        private readonly ILogger<InstructorController> _logger;
        public InstructorController(IInstructorRepository instructorRepository, ILogger<InstructorController> logger)
        {
            _instructorRepository = instructorRepository;
            _logger = logger;
        }

            public async Task<IActionResult> Index()
        {
            IEnumerable<Instructor> instructors = await _instructorRepository.GetAllAsync();
            return View(instructors.ToList());
        }
    }
}
