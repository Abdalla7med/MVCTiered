using LearningSystem.DAL.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningSystem.DAL.Repositories_Implementation
{
    public class CourseRepository :  GenericRepository<Course>, ICourseRepository
    {
        /// <summary>
        /// will passed through DI
        /// </summary>
        /// <param name="context"></param>
        public CourseRepository(LearningPlatformContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Course>> GetCoursesByInstructorIdAsync(int instructorId)
        {
            return await base._context.Courses
                               .Where(c => c.InstructorId == instructorId)
                               .ToListAsync();
        }
    }
}
