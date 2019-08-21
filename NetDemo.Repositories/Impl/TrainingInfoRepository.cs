using System.Collections.Generic;
using System.Linq;
using NetDemo.Interfaces.Contract;
using NetDemo.Models;

namespace NetDemo.Repositories
{
    public class TrainingInfoRepository : Repository<TrainingInfo>, ITrainingInfoRepository
    {
        public TrainingInfoRepository(MyDbContext context) : base(context)
        {

        }

        //public IEnumerable<TrainingInfo> GetAllActive()
        //{
        //    return _context.TrainingInfo.Where(a => a.IsActive == true).ToList().OrderBy(a => a.Name);
        //}
    }
}
