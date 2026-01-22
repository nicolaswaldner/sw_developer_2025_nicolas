using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fuhrpark_v3
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

        //override, dass zustandsinfos aus scooter im show ausgelesen werden können
        public override void Show()
        {
            //base.Show();
            ConsoleColor oldcolor = Console.ForegroundColor;
            Console.ForegroundColor = Color;

            Console.WriteLine($"Scooter: {Description} \n\t[{CurrentSpeed}/{MaxSpeed} km/h] \n\t{_maxDistance} km");

            Console.ForegroundColor = oldcolor;
        }

    }
}
