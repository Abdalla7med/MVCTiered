using System.ComponentModel.DataAnnotations.Schema;

namespace LearningSystem.DAL
{
    [Table("Trainees")]
    public class Trainee
    {
        public int Id { set; get; }

        public string Name { set; get; }    

        public string ImageUrl { set; get; }    

        public string Address { set; get; }


        // Many-to-One with Department
        public int? DepartmentId { get; set; }
        public Department Department { get; set; }

        // One-to-Many with CourseResult
        public ICollection<CourseResult> CourseResults { get; set; }

    }
}