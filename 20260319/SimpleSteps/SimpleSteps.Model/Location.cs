using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleSteps.Model
{
    public class Location
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public decimal Longitude { get; set; }
        public decimal Latitude { get; set; }
    }
}
