using NetDemo.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NetDemo.Interfaces.Contract
{
    public interface ITrainingInfoService
    {
        Task<IEnumerable<TrainingInfo>> GetAllAsync();
        Task<TrainingInfo> GetAsync(int id);
        Task SaveAsync(TrainingInfo info);
        Task UpdateAsync(TrainingInfo info);
        Task DeleteAsync(int id);
    }
}
