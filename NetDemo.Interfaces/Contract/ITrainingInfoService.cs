using NetDemo.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NetDemo.Interfaces.Contract
{
    public interface ITrainingService
    {
        Task<IEnumerable<Training>> GetAllAsync();
        Task<Training> GetAsync(int id);
        Task SaveAsync(Training info);
        Task UpdateAsync(Training info);
        Task DeleteAsync(int id);
    }
}
