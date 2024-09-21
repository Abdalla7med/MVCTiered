using LearningSystem.DAL.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningSystem.DAL.Repositories_Implementation
{
    public class InstructorRepository : GenericRepository<Instructor>, IInstructorRepository
    {

        public InstructorRepository(LearningPlatformContext context) : base(context) { }
    }
}
