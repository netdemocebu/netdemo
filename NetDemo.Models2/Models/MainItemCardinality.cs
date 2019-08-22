using System;
using System.Collections.Generic;

namespace NetDemo.Models2.Models
{
    public partial class MainItemCardinality
    {
        public int ItemId { get; set; }
        public int ItemTypeId { get; set; }
        public string AppEnvId { get; set; }
        public int ClientId { get; set; }
        public string UrlName { get; set; }
        public string TypeName { get; set; }
        public string AppName { get; set; }
        public string TypeDetail { get; set; }
        public decimal RequestCount { get; set; }
        public decimal CallCount { get; set; }
        public decimal TotalTime { get; set; }
        public decimal AverageTime { get; set; }
    }
}
