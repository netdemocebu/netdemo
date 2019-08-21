using NetDemo.Models;
using System.Collections.Generic;

namespace NetDemo.Interfaces.Contract
{
    public interface IPersonalInfoRepository : IRepository<PersonalInfo>
    {
        //IEnumerable<PersonalInfo> GetAllActive();
    }
}
