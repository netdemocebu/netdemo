using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using NetDemo.Interfaces.Contract;
using NetDemo.Models;

namespace NetDemo.Repositories
{
    public class TrainingRepository : Repository<Training>, ITrainingRepository
    {
        public TrainingRepository(DemoContext context) : base(context)
        {

        }

        public IEnumerable<Training> GetAllActive()
        {
            return _context.Training.Where(a => a.IsActive == true).ToList().OrderBy(a => a.Name);
        }

        public IEnumerable<Training> GetAllInactive()
        {
            return _context.Training.Where(a => a.IsActive == false).ToList().OrderBy(a => a.Name);
        }

        public IEnumerable<Training> GetAllWithPerson()
        {
            return _context.Training.Include(a => a.Person);
        }

        public IEnumerable<Training> FindWithPerson(Func<Training, bool> predicate)
        {
            return _context.Training.Include(a => a.Person).Where(predicate);
        }
    }
}
