using NetDemo.Models;
using System.Collections.Generic;
using System.Linq;
using NetDemo.Interfaces.Contract;

namespace NetDemo.Repositories
{
    public class PersonRepository : Repository<Person>, IPersonRepository
    {
        public PersonRepository(demoContext context) : base(context)
        {

        }

        //public IEnumerable<Person> GetAllActive()
        //{
        //    return _context.Person.Where(a => a.IsActive == true).ToList().OrderBy(a => a.Name);
        //}
    }
}
