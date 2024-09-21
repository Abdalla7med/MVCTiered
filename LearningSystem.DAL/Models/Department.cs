using System.ComponentModel.DataAnnotations.Schema;

namespace LearningSystem.DAL
{
    [Table("Departments")]
    public class Department
    {

        public int Id { get; set; } 

        public string Name { get; set; }


        // one-to-one With Instructor with manager role 
        // Manager as an Instructor (assuming an Instructor is a Manager)
        public int? ManagerId { get; set; }  // Nullable in case there's no manager assigned
        
        // One-to-Many with Instructor
        public ICollection<Instructor> Instructors { get; set; }

        // One-to-Many with Trainee
        public ICollection<Trainee> Trainees { get; set; }

        // One-to-Many with Course
        public ICollection<Course> Courses { get; set; }
    }
}