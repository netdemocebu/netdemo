using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NetDemo.Interfaces.Contract;
using NetDemo.Models;
using NetDemo.ViewModels;

namespace NetDemo.Services
{
    public class PersonService : IPersonService
    {
        #region Members

        private readonly IPersonRepository _personRepository;

        #endregion Members

        #region Constructor

        public PersonService(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        #endregion Constructor

        #region Events

        public async Task<IEnumerable<PersonViewModel>> GetAllAsync()
        {
            try
            {
                var persons = await _personRepository.GetAllAsync();
                var personsViewModel = new List<PersonViewModel>();

                foreach (var person in persons)
                {
                    personsViewModel.Add(new PersonViewModel
                    {
                        Id = person.Id,
                        LastName = person.LastName,
                        FirstName = person.FirstName
                    });
                }

                return personsViewModel;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<PersonViewModel> GetAsync(int id)
        {
            try
            {
                var model = await _personRepository.GetByIdAsync(id);
                var viewModel = new PersonViewModel()
                {
                    Id = model.Id,
                    LastName = model.LastName,
                    FirstName = model.FirstName
                };

                return viewModel;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task SaveAsync(PersonViewModel info)
        {
            try
            {
                var person = new Person()
                {
                    LastName = info.LastName,
                    FirstName = info.FirstName
                };

                await _personRepository.CreateAsync(person);
            }
            catch (Exception ex)
            {

            }
        }

        public async Task UpdateAsync(PersonViewModel info)
        {
            try
            {
                var model = await _personRepository.GetByIdAsync(info.Id);

                model.LastName = info.LastName;
                model.FirstName = info.FirstName;

                await _personRepository.UpdateAsync(model);
            }
            catch (Exception ex)
            {

            }
        }

        public async Task DeleteAsync(int id)
        {
            try
            {
                var model = await _personRepository.GetByIdAsync(id);

                await _personRepository.DeleteAsync(model);
            }
            catch (Exception ex)
            {
            }
        }

        #endregion Events
    }
}