using System.ComponentModel.DataAnnotations.Schema;

namespace LearningSystem.DAL
{
    [Table("CourseResult")]
    public class CourseResult
    {
        public int Id { get; set; }

        // Grade-related fields
        public decimal Grade { get; set; }  // Numeric grade
        public string GradeLetter { get; set; } // Letter grade (optional)
        public DateTime GradeDate { get; set; } // Date the grade was recorded

        // Many-to-One with Course
        public int? CourseId { get; set; }
        public Course Course { get; set; }

        // Many-to-One with Trainee
        public int? TraineeId { get; set; }
        public Trainee Trainee { get; set; }
    }

}