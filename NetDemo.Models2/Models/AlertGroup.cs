using System;
using System.Collections.Generic;

namespace NetDemo.Models2.Models
{
    public partial class AlertGroup
    {
        public int AlertGroupId { get; set; }
        public int MonitorId { get; set; }
        public DateTimeOffset? StartedAt { get; set; }
        public DateTimeOffset? EndedAt { get; set; }
        public int? AlertAcknowledgeId { get; set; }
        public int? AcknowledgedSeverity { get; set; }
    }
}
