using System.Collections.Generic;
using System.Linq;
using NetDemo.Interfaces.Contract;
using NetDemo.Models;

namespace NetDemo.Repositories
{
    public class TrainingRepository : Repository<Training>, ITrainingRepository
    {
        public TrainingRepository(DemoContext context) : base(context)
        {

        }

        //public IEnumerable<Training> GetAllActive()
        //{
        //    return _context.Training.Where(a => a.IsActive == true).ToList().OrderBy(a => a.Name);
        //}
    }
}
