using NetDemo.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NetDemo.Interfaces.Contract
{
    public interface IPersonService
    {
        Task<IEnumerable<Person>> GetAllAsync();
        Task<Person> GetAsync(int id);
        Task SaveAsync(Person info);
        Task UpdateAsync(Person info);
        Task DeleteAsync(int id);
    }
}
