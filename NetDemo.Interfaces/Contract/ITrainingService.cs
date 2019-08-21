using System.Collections.Generic;
using System.Threading.Tasks;
using NetDemo.ViewModels;

namespace NetDemo.Interfaces.Contract
{
    public interface ITrainingService
    {
        Task<IEnumerable<TrainingViewModel>> GetAllAsync();
        Task<TrainingViewModel> GetAsync(int id);
        Task SaveAsync(TrainingViewModel info);
        Task UpdateAsync(TrainingViewModel info);
        Task DeleteAsync(int id);
    }
}
