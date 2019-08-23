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
                        FirstName = person.FirstName,
                        Address = person.Address,
                        EmailAddress = person.EmailAddress,
                        Age = person.Age,
                        IsActive = person.IsActive
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
                    FirstName = model.FirstName,
                    Address = model.Address,
                    EmailAddress = model.EmailAddress,
                    Age = model.Age,
                    IsActive = model.IsActive
                };

                return viewModel;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task SaveAsync(PersonCreateViewModel info)
        {
            try
            {
                var svc = new AuthenticationService(_personRepository);
                var token = svc.CreateToken(info.EmailAddress);

                var person = new Person()
                {
                    LastName = info.LastName,
                    FirstName = info.FirstName,
                    Address = info.Address,
                    EmailAddress = info.EmailAddress,
                    Age = info.Age,
                    IsActive = true,
                    SecurityToken = token
                };

                await _personRepository.CreateAsync(person);
            }
            catch (Exception ex)
            {

            }
        }

        public async Task UpdateAsync(PersonUpdateViewModel info)
        {
            try
            {
                var model = await _personRepository.GetByIdAsync(info.Id);

                model.LastName = info.LastName;
                model.FirstName = info.FirstName;
                model.Address = info.Address;
                model.EmailAddress = info.EmailAddress;
                model.Age = info.Age;
                model.IsActive = info.IsActive;

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

        public IEnumerable<Person> GetAllActive()
        {
            return _personRepository.GetAllActive();
        }

        public IEnumerable<Person> GetAllInactive()
        {
            return _personRepository.GetAllInactive();
        }

        public IEnumerable<Person> GetAllWithTrainings()
        {
            return _personRepository.GetAllWithTrainings();
        }

        public Person GetWithTrainings(int id)
        {
            return _personRepository.GetWithTrainings(id);
        }

        #endregion Events
    }
}