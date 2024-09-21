using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningSystem.DAL
{
    public interface ICourseRepository:IRepository<Course>
    {
        Task<IEnumerable<Course>> GetCoursesByInstructorIdAsync(int instructorId);
    }

}
