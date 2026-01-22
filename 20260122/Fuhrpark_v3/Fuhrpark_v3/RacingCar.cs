using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fuhrpark_v3
{
    internal class RacingCar : Car
    {
		//Zustandsinfo
		private DownforceType _downforceDevice;

        //Konstruktor
        public RacingCar(string description, int maxSpeed, ConsoleColor color, DownforceType downforceType)
            : base(description, maxSpeed, color, 2) //das hier ist 2ter Konstruktor von Car (mit Seatcount)
        {
            _downforceDevice = downforceType;
        }

        //Properties
        public DownforceType DownforceDevice
		{
			get { return _downforceDevice; }
		}

        public override void Show()
        {
            Console.WriteLine($"RacingCar aerodynamic property: {_downforceDevice}");
            base.Show();
        }


	}
}
