namespace LearningSystem.ViewModels
{
    public class MainDashboardViewModel
    {
        public int TotalDepartments { set; get; }
        public int TotalInstructor { set; get; }
        public int TotalCourses { set; get; }
        public int TotalTrainee { set; get; }
        public List<string> RecentAddedFeatures { set; get; } = new List<string>();
    }
}
