using NetDemo.Interfaces.Contract;
using NetDemo.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NetDemo.ViewModels;

namespace NetDemo.Services
{
    public class TrainingService : ITrainingService
    {
        #region Members

        private readonly ITrainingRepository _trainingRepository;
        private readonly IPersonRepository _personRepository;

        #endregion Members

        #region Constructor

        public TrainingService(ITrainingRepository trainingRepository, IPersonRepository personRepository)
        {
            _trainingRepository = trainingRepository;
            _personRepository = personRepository;
        }

        #endregion Members

        public async Task<IEnumerable<TrainingViewModel>> GetAllAsync()
        {
            try
            {
                var trainings = await _trainingRepository.GetAllAsync();
                var trainingsViewModel = new List<TrainingViewModel>();

                foreach (var training in trainings)
                {
                    trainingsViewModel.Add(new TrainingViewModel
                    {
                        Id = training.Id,
                        Name = training.Name,
                        PersonId = training.PersonId
                    });
                }

                return trainingsViewModel;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<TrainingViewModel> GetAsync(int id)
        {
            try
            {
                var model = await _trainingRepository.GetByIdAsync(id);
                var viewModel = new TrainingViewModel()
                {
                    Id = model.Id,
                    Name = model.Name,
                    PersonId = model.PersonId
                };

                return viewModel;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task SaveAsync(TrainingViewModel info)
        {
            try
            {
                var training = new Training()
                {
                    Name = info.Name,
                    PersonId = info.PersonId
                };

                await _trainingRepository.CreateAsync(training);
            }
            catch (Exception ex)
            {

            }
        }

        public async Task UpdateAsync(TrainingViewModel info)
        {
            try
            {
                var model = await _trainingRepository.GetByIdAsync(info.Id);
                model.Name = info.Name;
                model.PersonId = info.PersonId;

                await _trainingRepository.UpdateAsync(model);
            }
            catch (Exception ex)
            {

            }
        }

        public async Task DeleteAsync(int id)
        {
            try
            {
                var model = await _trainingRepository.GetByIdAsync(id);

                await _trainingRepository.DeleteAsync(model);
            }
            catch (Exception ex)
            {
            }
        }
    }
}
