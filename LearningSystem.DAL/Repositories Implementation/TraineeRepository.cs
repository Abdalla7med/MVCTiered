using LearningSystem.DAL.Context;
using LearningSystem.DAL.Migrations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningSystem.DAL.Repositories_Implementation
{
    public class TraineeRepository :GenericRepository<Trainee>, ITraineeRepository
    {

        public TraineeRepository(LearningPlatformContext context): base(context) { }
        
    }
}
