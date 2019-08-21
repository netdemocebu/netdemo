using NetDemo.Models;
using System.Collections.Generic;

namespace NetDemo.Interfaces.Contract
{
    public interface IPersonRepository : IRepository<Person>
    {
        //IEnumerable<Person> GetAllActive();
    }
}
