using NetDemo.Interfaces.Contract;
using NetDemo.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NetDemo.Services
{
    public class TrainingInfoService : ITrainingInfoService
    {
        #region Members

        private readonly ITrainingInfoRepository _trainingInfoRepository;

        #endregion Members

        #region Constructor

        public TrainingInfoService(ITrainingInfoRepository trainingInfoRepository)
        {
            _trainingInfoRepository = trainingInfoRepository;
        }

        #endregion Members

        public async Task<IEnumerable<TrainingInfo>> GetAllAsync()
        {
            try
            {
                var model = await _trainingInfoRepository.GetAllAsync();

                return model;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<TrainingInfo> GetAsync(int id)
        {
            try
            {
                var model = await _trainingInfoRepository.GetByIdAsync(id);

                return model;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task SaveAsync(TrainingInfo info)
        {
            try
            {
                await _trainingInfoRepository.CreateAsync(info);
            }
            catch (Exception ex)
            {

            }
        }

        public async Task UpdateAsync(TrainingInfo info)
        {
            try
            {
                var model = await _trainingInfoRepository.GetByIdAsync(info.TrainingId);
                model.PersonalId = info.PersonalId;
                model.TrainingDate = info.TrainingDate;

                await _trainingInfoRepository.CreateAsync(model);
            }
            catch (Exception ex)
            {

            }
        }

        public async Task DeleteAsync(int id)
        {
            try
            {
                var model = await _trainingInfoRepository.GetByIdAsync(id);

                await _trainingInfoRepository.DeleteAsync(model);
            }
            catch (Exception ex)
            {
            }
        }
    }
}
