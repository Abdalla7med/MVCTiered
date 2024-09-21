using System.ComponentModel.DataAnnotations.Schema;

namespace LearningSystem.DAL
{
    [Table("Courses")]
    public class Course
    {
        public int Id { set; get; }

        public string Name { set; get; }    

        public int Degree { set; get; }

        public int MinDegree { get; set; }

        public int TotalHours { set;get; }


        // One-to-Many with CourseResult
        public ICollection<CourseResult> CourseResults { get; set; }

        // Many-to-One with Department
        public int? DepartmentId { get; set; }
        public Department Department { get; set; }

        // One-to-Many with Instructor
        public int? InstructorId { set; get; }
        public Instructor Instructor { get; set; }



    }
}
