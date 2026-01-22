using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fuhrpark_v3
{
    internal class Car : Vehicle
    {
        //Konstruktor
        public Car(string description, int maxSpeed, ConsoleColor color)
            : base(description, maxSpeed, color)
        {
            _seatCount = 5;
        }

        public Car(string description, int maxSpeed, ConsoleColor color, int seatCount)
            : base(description, maxSpeed, color)
        {
            _seatCount = seatCount;
        }

        //Zustandsinfo
        private int _seatCount;

        //Properties
        public int SeatCount
        {
            get { return _seatCount; }
        }

        //override, dass zustandsinfos aus car im show ausgelesen werden können
        public override void Show()
        {
            base.Show();
            Console.WriteLine($"  => Sitzplätze: {_seatCount}");
        }


    }
}
