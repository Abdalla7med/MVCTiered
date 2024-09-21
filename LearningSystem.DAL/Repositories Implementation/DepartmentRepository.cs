using LearningSystem.DAL.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningSystem.DAL.Repositories_Implementation
{
    public class DepartmentRepository:GenericRepository<Department>
    {
        public DepartmentRepository(LearningPlatformContext context):base(context) { }
    }
}
