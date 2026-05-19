using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleSteps.Model
{
    public class AppUser
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }
        public DateTime? Birthday { get; set; } //? macht es null-able
        public bool IsActive { get; set; }
        public string Email { get; set; }
        public string Mobilephone { get; set; }
        public string Sex { get; set; }


        public string Displayname { get { return string.Format("{0} {1}", Lastname, Name); } }

    }
}
