using System.Collections.Generic;
using System.Threading.Tasks;
using NetDemo.Models;
using NetDemo.ViewModels;

namespace NetDemo.Interfaces.Contract
{
    public interface ITrainingService
    {
        Task<IEnumerable<TrainingViewModel>> GetAllAsync();
        Task<TrainingViewModel> GetAsync(int id);
        Task SaveAsync(TrainingCreateViewModel info);
        Task UpdateAsync(TrainingUpdateViewModel info);
        Task DeleteAsync(int id);
        IEnumerable<Training> GetAllActive();
        IEnumerable<Training> GetAllInactive();
        IEnumerable<Training> GetAllWithPerson();
        void GetWithPersonsHasToken();
    }
}
