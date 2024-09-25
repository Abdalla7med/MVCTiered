using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LearningSystem.DAL
{
    [Table("Instructors")]
    public class Instructor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImageURL { get; set; }

        [DataType(DataType.Currency)]
        public double Salary { set; get; }
        public string address { set; get; }

        // Foreign key and navigation property
        public int? DepartmentId { get; set; }  // Explicit foreign key for Department
        public Department Department { get; set; }

        // Navigation property for courses
        // one-to-many with course
        public ICollection<Course> Courses { get; set; } = new List<Course>();
    }
}