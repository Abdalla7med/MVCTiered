using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class InstructorEditDto
    {
        public int Id { set; get; }
        public string Name { get; set; }
        public string ImageUrl { set; get; }
        public double Salary { set; get; }
        public string address { set; get; }
        public int? DeptID { set; get; }

        public List<int>? CourseIds { set; get; }
    }
}
