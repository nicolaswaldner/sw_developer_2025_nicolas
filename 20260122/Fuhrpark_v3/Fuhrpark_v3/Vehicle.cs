using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fuhrpark_v3
{
    public abstract class Vehicle
    {

        //Methode
        public abstract void SpeedUp(int delta);


        public abstract void Show(); //virtual, dass das überschreibbar ist später mit override


        //Methoden von Radio deligieren, dass man nicht direkt auf Radio zugreift, sondern von außen über Vehicle
        //erlaubt es, Radio später mit besserem Radio auszutauschen
        public abstract void ChangeRadioPower(bool isOn);


        public abstract void MakeSound();


        //Eigenschaften/Properties
        public abstract int MaxSpeed { get; }

        public abstract int CurrentSpeed { get; }

        public abstract string Description { get; }

        public abstract ConsoleColor Color { get; }
    }
}
