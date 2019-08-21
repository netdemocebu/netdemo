using NetDemo.Models;
using NetDemo.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NetDemo.Interfaces.Contract
{
    public interface IPersonService
    {
        Task<IEnumerable<PersonViewModel>> GetAllAsync();
        Task<Person> GetAsync(int id);
        Task SaveAsync(PersonViewModel info);
        Task UpdateAsync(PersonViewModel info);
        Task DeleteAsync(int id);
    }
}
