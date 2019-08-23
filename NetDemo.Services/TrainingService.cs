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

        #region Events

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
                        PersonId = training.PersonId,
                        Description = training.Description,
                        Location = training.Location,
                        IsActive = true
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
                    PersonId = model.PersonId,
                    Description = model.Description,
                    Location = model.Location,
                    IsActive = true
                };

                return viewModel;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task SaveAsync(TrainingCreateViewModel info)
        {
            try
            {
                var training = new Training()
                {
                    Name = info.Name,
                    PersonId = info.PersonId,
                    Description = info.Description,
                    Location = info.Location,
                    IsActive = true
                };

                await _trainingRepository.CreateAsync(training);
            }
            catch (Exception ex)
            {

            }
        }

        public async Task UpdateAsync(TrainingUpdateViewModel info)
        {
            try
            {
                var model = await _trainingRepository.GetByIdAsync(info.Id);
                model.Name = info.Name;
                model.PersonId = info.PersonId;
                model.Description = info.Description;
                model.Location = info.Location;
                model.IsActive = info.IsActive;

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

        public IEnumerable<Training> GetAllActive()
        {
            return _trainingRepository.GetAllActive();
        }

        public IEnumerable<Training> GetAllInactive()
        {
            return _trainingRepository.GetAllInactive();
        }

        public IEnumerable<Training> GetAllWithPerson()
        {
            return _trainingRepository.GetAllWithPerson();
        }

        public void GetWithPersonsHasToken()
        {
            Func<Training, bool> myFilter = x => x.Person.SecurityToken != null;

            var personsHasToken = _trainingRepository.FindWithPerson(myFilter);
        }

        #endregion Events
    }
}
