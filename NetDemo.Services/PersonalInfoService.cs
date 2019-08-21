using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NetDemo.Interfaces.Contract;
using NetDemo.Models;

namespace NetDemo.Services
{
    public class PersonalInfoService : IPersonalInfoService
    {
        #region Members

        private readonly IPersonalInfoRepository _personalInfoRepository;

        #endregion Members

        #region Constructor

        public PersonalInfoService(IPersonalInfoRepository personalInfoRepository)
        {
            _personalInfoRepository = personalInfoRepository;
        }

        #endregion Constructor

        #region Events

        public async Task<IEnumerable<PersonalInfo>> GetAllAsync()
        {
            try
            {
                var model = await _personalInfoRepository.GetAllAsync();

                return model;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<PersonalInfo> GetAsync(int id)
        {
            try
            {
                var model = await _personalInfoRepository.GetByIdAsync(id);

                return model;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task SaveAsync(PersonalInfo info)
        {
            try
            {
                await _personalInfoRepository.CreateAsync(info);
            }
            catch (Exception ex)
            {

            }
        }

        public async Task UpdateAsync(PersonalInfo info)
        {
            try
            {
                var model = await _personalInfoRepository.GetByIdAsync(info.PersonalId);

                model.LastName = info.LastName;
                model.FirstName = info.FirstName;

                await _personalInfoRepository.UpdateAsync(model);
            }
            catch (Exception ex)
            {

            }
        }

        public async Task DeleteAsync(int id)
        {
            try
            {
                var model = await _personalInfoRepository.GetByIdAsync(id);

                await _personalInfoRepository.DeleteAsync(model);
            }
            catch (Exception ex)
            {
            }
        }

        #endregion Events
    }
}