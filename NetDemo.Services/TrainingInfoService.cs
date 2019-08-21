using NetDemo.Interfaces.Contract;
using NetDemo.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NetDemo.Services
{
    public class TrainingService : ITrainingService
    {
        #region Members

        private readonly ITrainingRepository _TrainingRepository;

        #endregion Members

        #region Constructor

        public TrainingService(ITrainingRepository TrainingRepository)
        {
            _TrainingRepository = TrainingRepository;
        }

        #endregion Members

        public async Task<IEnumerable<Training>> GetAllAsync()
        {
            try
            {
                var model = await _TrainingRepository.GetAllAsync();

                return model;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<Training> GetAsync(int id)
        {
            try
            {
                var model = await _TrainingRepository.GetByIdAsync(id);

                return model;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task SaveAsync(Training info)
        {
            try
            {
                await _TrainingRepository.CreateAsync(info);
            }
            catch (Exception ex)
            {

            }
        }

        public async Task UpdateAsync(Training info)
        {
            try
            {
                var model = await _TrainingRepository.GetByIdAsync(info.Id);
                model.Id = info.Id;
                

                await _TrainingRepository.UpdateAsync(model);
            }
            catch (Exception ex)
            {

            }
        }

        public async Task DeleteAsync(int id)
        {
            try
            {
                var model = await _TrainingRepository.GetByIdAsync(id);

                await _TrainingRepository.DeleteAsync(model);
            }
            catch (Exception ex)
            {
            }
        }
    }
}
