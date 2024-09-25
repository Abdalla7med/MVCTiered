using Common;
using LearningSystem.DAL;
using LearningSystem.DAL.Repositories_Implementation;
using LearningSystem.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LearningSystem.Controllers
{
    public class InstructorController : Controller
    {
        private readonly IInstructorRepository _instructorRepository;
        private readonly IDepartmentRepository _departmentRepository;
        private readonly ICourseRepository _courseRepository;
        private readonly ILogger<InstructorController> _logger;

        public InstructorController(IInstructorRepository instructorRepository, ILogger<InstructorController> logger, IDepartmentRepository departmentRepository, ICourseRepository courseRepository)
        {
            _instructorRepository = instructorRepository;
            _logger = logger;
            _departmentRepository = departmentRepository;
            _courseRepository = courseRepository;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<Instructor> instructors = await _instructorRepository.GetAllAsync();
            return View(instructors.ToList());
        }

        public async Task<IActionResult> Details(int id)
        {
            var instructor = await _instructorRepository.GetByIdAsync(id);
            if (instructor == null)
            {
                return NotFound();
            }
            return View(instructor);
        }

        [HttpPost]
        public IActionResult HandleSelectedRows(List<int> selectedIds, string action)
        {
            if (selectedIds == null || selectedIds.Count == 0)
            {
                return RedirectToAction("Index");
            }

            if (action == "edit")
            {
                // Assuming you edit the first selected item
                return RedirectToAction("Edit", new { id = selectedIds.First() });
            }
            else if (action == "delete")
            {
                // Redirect to the Delete action with the selected IDs
                return RedirectToAction("Delete", new { ids = selectedIds });
            }

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Create()
        {
            ViewBag.Departments = await _departmentRepository.GetAllAsync();
                ViewBag.Courses = await _courseRepository.GetAllAsync();
           

                return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(InstructorCreateDto instructorCreateDTO, int[] CourseIds)
        {
            if (ModelState.IsValid)
            {
                var dept = await _departmentRepository.GetByIdAsync(instructorCreateDTO.DeptID ?? 0);
                
                    // Create the instructor
                    var instructor = new Instructor
                    {
                        Name = instructorCreateDTO.Name,
                        ImageURL = instructorCreateDTO.ImageUrl,
                        address = instructorCreateDTO.address,
                        Salary = instructorCreateDTO.Salary,
                        DepartmentId = instructorCreateDTO.DeptID,
                        Department = dept,
                        Courses = new List<Course>() // Initialize the Courses property
                    };

                    // Fetch the selected courses and assign them to the instructor's Courses collection
                    foreach (var courseId in CourseIds)
                    {
                        var course = await _courseRepository.GetByIdAsync(courseId);
                        if (course != null)
                        {
                            instructor.Courses.Add(course);
                        }
                    }

                    // Add instructor to the database
                    await _instructorRepository.AddAsync(instructor);
                    /* await _unitOfWork.SaveAsync();*/

                    return RedirectToAction(nameof(Index));
            }

            // If model state is invalid, return the view with the necessary data
            ViewBag.Departments = await _departmentRepository.GetAllAsync();
            ViewBag.Courses = await _courseRepository.GetAllAsync();
          
            return View(instructorCreateDTO);
        }


        public async Task<IActionResult> Edit(int id)
        {
            var instructor = await _instructorRepository.GetByIdAsync(id);
            if (instructor == null)
            {
                return NotFound();
            }

            var model = new InstructorEditDto
            {
                Id = instructor.Id,
                Name = instructor.Name,
                Salary = instructor.Salary,
                DeptID = instructor.DepartmentId,
                address = instructor.address,
                ImageUrl = instructor.ImageURL,
                CourseIds = instructor.Courses.Select(c => c.Id).ToList()
            };

            ViewBag.Departments = await _departmentRepository.GetAllAsync(); // List of Departments
            ViewBag.Courses = await _courseRepository.GetAllAsync(); // List of Courses

            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(InstructorEditDto model)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Departments = await _departmentRepository.GetAllAsync();
                ViewBag.Courses = await _courseRepository.GetAllAsync();
                return View(model);
            }

            Instructor instructor = await _instructorRepository.GetByIdAsync(model.Id);
            if (instructor == null)
            {
                return NotFound();
            }

            // Update instructor details
            instructor.Name = model.Name;
            instructor.Salary = model.Salary;
            instructor.DepartmentId = model.DeptID;
            instructor.address = model.address;
            instructor.ImageURL = model.ImageUrl;

            // Update courses (remove old, add new)
            instructor.Courses.Clear();
            foreach (var courseId in model?.CourseIds)
            {
                var course = await _courseRepository.GetByIdAsync(courseId);
                if (course != null)
                {
                    instructor.Courses.Add(course);
                }
            }

            await _instructorRepository.UpdateAsync(instructor);

            return RedirectToAction("Index");
        }

       /* // Delete Action (GET) to confirm deletion
        public async Task<IActionResult> Delete(int id)
        {
            var instructor = await _instructorRepository.GetByIdAsync(id);
            if (instructor == null)
            {
                return NotFound();
            }
            return View(instructor);
        }
*/
        // Delete Action (POST) to handle deletion, using the selection boxes on the left of dashboard now need to display instructor agian  
       
        public async Task<IActionResult> Delete(List<int> ids)
        {
            if (ids == null || ids.Count == 0)
            {
                return RedirectToAction("Index");
            }

            foreach (var id in ids)
            {
                try
                {
                    // Get the instructor by ID
                    var instructor = await _instructorRepository.GetByIdAsync(id);
                    if (instructor != null)
                    {
                        // Delete the instructor
                        await _instructorRepository.DeleteAsync(id);
                    }
                }
                catch (Exception ex)
                {
                    // Log the exception or show a message
                    ViewBag.Error = $"Error deleting instructor with ID {id}: {ex.Message}";
                    return View("Error"); // Show an error view if needed
                }
            }

            // After deletion, redirect back to the index
            return RedirectToAction("Index");
        }


    }
}
