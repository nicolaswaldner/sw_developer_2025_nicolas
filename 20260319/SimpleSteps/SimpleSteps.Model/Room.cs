using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleSteps.Model
{
    public class Room
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Longitude { get; set; }
        public string Latitude { get; set; }
        public long LocationId { get; set; }

    }
}
