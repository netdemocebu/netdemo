using NetDemo.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NetDemo.Interfaces.Contract
{
    public interface IPersonalInfoService
    {
        Task<IEnumerable<PersonalInfo>> GetAllAsync();
        Task<PersonalInfo> GetAsync(int id);
        Task SaveAsync(PersonalInfo info);
        Task UpdateAsync(PersonalInfo info);
        Task DeleteAsync(int id);
    }
}
