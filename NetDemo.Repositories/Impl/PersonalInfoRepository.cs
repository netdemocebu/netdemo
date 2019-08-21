using NetDemo.Models;
using System.Collections.Generic;
using System.Linq;
using NetDemo.Interfaces.Contract;

namespace NetDemo.Repositories
{
    public class PersonalInfoRepository : Repository<PersonalInfo>, IPersonalInfoRepository
    {
        public PersonalInfoRepository(MyDbContext context) : base(context)
        {

        }

        //public IEnumerable<PersonalInfo> GetAllActive()
        //{
        //    return _context.PersonalInfo.Where(a => a.IsActive == true).ToList().OrderBy(a => a.Name);
        //}
    }
}
