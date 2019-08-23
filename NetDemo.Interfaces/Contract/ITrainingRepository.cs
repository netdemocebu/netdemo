using System;
using NetDemo.Models;
using System.Collections.Generic;

namespace NetDemo.Interfaces.Contract
{
    public interface ITrainingRepository : IRepository<Training>
    {
        IEnumerable<Training> GetAllActive();
        IEnumerable<Training> GetAllInactive();
        IEnumerable<Training> GetAllWithPerson();
        IEnumerable<Training> FindWithPerson(Func<Training, bool> predicate);
    }
}
