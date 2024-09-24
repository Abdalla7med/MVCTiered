
using LearningSystem.DAL;
using LearningSystem.DAL.Repositories_Implementation;
using LearningSystem.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace LearningSystem.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICourseRepository _courseRepository;
        private readonly IInstructorRepository _instructorRepository;
        private readonly IDepartmentRepository _departmentRepository;
        private readonly ITraineeRepository _traineeRepository;
        /// there's no need to add CourseResultRepo thus becuase we just need it trainee BLL to adjust some information about trainee transcript
        public HomeController(
                                ILogger<HomeController> logger,
                                ITraineeRepository traineeRepository, 
                                IInstructorRepository instructorRepository, 
                                IDepartmentRepository departmentRepository, 
                                ICourseRepository courseRepository
                            )
        {

            _logger = logger;
            _instructorRepository = instructorRepository;
            _departmentRepository = departmentRepository;
            _courseRepository = courseRepository;
            _traineeRepository = traineeRepository;

        }

        public async Task<IActionResult> Index()
        {


            var DashboardMode = new MainDashboardViewModel()
            {
                TotalCourses =await  _courseRepository.NumberOfEntitiesAsync(),
                TotalDepartments = await _departmentRepository.NumberOfEntitiesAsync(),
                TotalInstructor = await _instructorRepository.NumberOfEntitiesAsync(),
                TotalTrainee = await _traineeRepository.NumberOfEntitiesAsync()
            };
            return View(DashboardMode);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View();
        }
    }
}
