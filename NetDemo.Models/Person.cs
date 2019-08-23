using System.Collections.Generic;
using System.ComponentModel;

namespace NetDemo.Models
{
    public partial class Person
    {
        public Person()
        {
            Training = new HashSet<Training>();
        }
  
        public int Id { get; set; }

        [DisplayName("First Name")]
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Address { get; set; }

        public string EmailAddress { get; set; }

        public int Age { get; set; }

        public string SecurityToken { get; set; }

        public virtual ICollection<Training> Training { get; set; }

        public bool IsActive { get; set; }
    }
}
