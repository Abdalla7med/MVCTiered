using LearningSystem.DAL.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningSystem.DAL
{
    public class CourseResultRepository :GenericRepository<CourseResult>, ICourseResultRepository
    {
        public CourseResultRepository(LearningPlatformContext context):base(context) { }    
       

        
    }
}
