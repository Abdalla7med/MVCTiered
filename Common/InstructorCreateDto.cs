namespace Common
{
    public class InstructorCreateDto
    {
        public string Name { get; set; }

        public string ImageUrl { set; get; }
        public double Salary { set; get; }
        public string address { set; get; }
        public int? DeptID { set; get; }

        public List<int>? CourseIds { set; get; } 

    }
}
