using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vererbung_GL
{
    internal class Scooter : Vehicle
    {
		//Zustandsinfo
		private int _maxDistance;

        //Standard Konstruktor mit Basis der Klasse Vehicle
        public Scooter()
            :base("Standard Scooter", 25, ConsoleColor.Yellow)
        {
            _maxDistance = 100;
        }

        //Konstruktor der Basis Klasse aufrufen mit : base, weil dort schon exisitiert
        public Scooter(string description, int maxSpeed, int maxDistance)
            : base(description, maxSpeed, ConsoleColor.Yellow)
        {
            _maxDistance = maxDistance;
        }

        //Eigenschaft/Property
        public int MaxDistance
		{
			get { return _maxDistance; }
		}

    }
}
