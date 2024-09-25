using LearningSystem.DAL.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningSystem.DAL.Repositories_Implementation
{
    public class InstructorRepository : GenericRepository<Instructor>, IInstructorRepository
    {

        public InstructorRepository(LearningPlatformContext context) : base(context) { }

        public override async Task<IEnumerable<Instructor>> GetAllAsync()
        {
            return await base._context.Instructors.Include(I => I.Department)
                                            .ThenInclude(I => I.Courses)
                                            .ToListAsync();
        }

    }
}
