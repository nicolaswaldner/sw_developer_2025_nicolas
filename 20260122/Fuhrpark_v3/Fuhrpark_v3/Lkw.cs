using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fuhrpark_v3
{
    internal class Lkw : IVehicle
    {
        public int MaxSpeed => throw new NotImplementedException();

        public int CurrentSpeed => throw new NotImplementedException();

        public string Description => throw new NotImplementedException();

        public ConsoleColor Color => throw new NotImplementedException();

        public void ChangeRadioPower(bool isOn)
        {
            throw new NotImplementedException();
        }

        public void MakeSound()
        {
            throw new NotImplementedException();
        }

        public void Show()
        {
            throw new NotImplementedException();
        }

        public void SpeedUp(int delta)
        {
            throw new NotImplementedException();
        }
    }
}
