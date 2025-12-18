using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeilnehmerVerwaltungMitArray.DataTypes
{
    public struct Teilnehmer
    {
        public Guid Id;
        public string Name;
        public DateTime Geburtsdatum;
        public Adresse Wohnadresse;
    }
}
