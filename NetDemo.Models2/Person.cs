using System;
using System.Collections.Generic;

namespace NetDemo.Models2
{
    public partial class Person
    {
        public Person()
        {
            Training = new HashSet<Training>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string EmailAddress { get; set; }
        public string SecurityToken { get; set; }

        public virtual ICollection<Training> Training { get; set; }
    }
}
