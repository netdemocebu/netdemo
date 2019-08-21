using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NetDemo.Interfaces.Contract;
using NetDemo.Models;

namespace NetDemo.Services
{
    public class PersonService : IPersonService
    {
        #region Members

        private readonly IPersonRepository _PersonRepository;

        #endregion Members

        #region Constructor

        public PersonService(IPersonRepository PersonRepository)
        {
            _PersonRepository = PersonRepository;
        }

        #endregion Constructor

        #region Events

        public async Task<IEnumerable<Person>> GetAllAsync()
        {
            try
            {
                var model = await _PersonRepository.GetAllAsync();

                return model;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<Person> GetAsync(int id)
        {
            try
            {
                var model = await _PersonRepository.GetByIdAsync(id);

                return model;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task SaveAsync(Person info)
        {
            try
            {
                await _PersonRepository.CreateAsync(info);
            }
            catch (Exception ex)
            {

            }
        }

        public async Task UpdateAsync(Person info)
        {
            try
            {
                var model = await _PersonRepository.GetByIdAsync(info.Id);

                model.LastName = info.LastName;
                model.FirstName = info.FirstName;

                await _PersonRepository.UpdateAsync(model);
            }
            catch (Exception ex)
            {

            }
        }

        public async Task DeleteAsync(int id)
        {
            try
            {
                var model = await _PersonRepository.GetByIdAsync(id);

                await _PersonRepository.DeleteAsync(model);
            }
            catch (Exception ex)
            {
            }
        }

        #endregion Events
    }
}