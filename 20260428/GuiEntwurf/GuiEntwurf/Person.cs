using System;
using System.Collections.Generic;
using System.Text;

namespace GuiEntwurf
{
    public class Person
    {
        public int Id { get; set; }
        public string Lastname { get; set; }
        public string Firstname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        //displayname, sodass bei der auswahl Person vor und nachname zur auswahl kommt
        public string DisplayName
        {
            get
            {
                return string.Format("{0} {1}", Lastname, Firstname);
            }
        }

    }
}
