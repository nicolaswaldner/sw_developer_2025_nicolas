using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleSteps.Model
{
    public class MeasuredData
    {
        public long Id { get; set; }
        public DateTime MeasuredDateTime { get; set; }
        public decimal MeasuredValue { get; set; }
        public string? Unit { get; set; }
        public string? MeasuredType { get; set; }
        public long? SensorId { get; set; }
        public long? AppUserId { get; set; }

    }
}
