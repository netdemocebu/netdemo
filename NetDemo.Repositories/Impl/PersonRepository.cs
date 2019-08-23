using NetDemo.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using NetDemo.Interfaces.Contract;

namespace NetDemo.Repositories
{
    public class PersonRepository : Repository<Person>, IPersonRepository
    {
        public PersonRepository(DemoContext context) : base(context)
        {

        }

        public IEnumerable<Person> GetAllActive()
        {
            return _context.Person.Where(a => a.IsActive == true).ToList().OrderBy(a => a.LastName);
        }

        public IEnumerable<Person> GetAllInactive()
        {
            return _context.Person.Where(a => a.IsActive == false).ToList().OrderBy(a => a.LastName);
        }

        public IEnumerable<Person> GetAllWithTrainings()
        {
            return _context.Person.Include(a => a.Training);
        }

        public Person GetWithTrainings(int id)
        {
            return _context.Person.Where(a => a.Id == id).Include(a => a.Training).FirstOrDefault();
        }

        public override void Delete(Person entity)
        {
            var trainingsToRemove = _context.Training.Where(a => a.Person == entity);

            base.Delete(entity);

            _context.RemoveRange(entity);

            Save();
        }
    }
}
