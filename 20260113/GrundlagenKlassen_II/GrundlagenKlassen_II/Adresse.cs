using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrundlagenKlassen_II
{
    //DTO -> Data Transfer Object (POCO -> Plain Old CRL Object)
    public class Adresse
    {
        public string Wohnort { get; set; }
        public int Plz { get; set; }
        public string Strasse { get; set; }
        public string HausNr { get; set; }

        //= Auto-Properties


    }
}
