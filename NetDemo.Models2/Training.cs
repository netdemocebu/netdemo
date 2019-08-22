using System;
using System.Collections.Generic;

namespace NetDemo.Models2
{
    public partial class Training
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? PersonId { get; set; }
        public string Desc { get; set; }
        public string Location { get; set; }

        public virtual Person Person { get; set; }
    }
}
