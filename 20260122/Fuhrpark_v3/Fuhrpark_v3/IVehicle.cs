using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fuhrpark_v3
{
    public interface IVehicle
    {

        //Methoden
         void SpeedUp(int delta);
         void Show(); 
         void ChangeRadioPower(bool isOn);
         void MakeSound();


        //Properties
         int MaxSpeed { get; }
         int CurrentSpeed { get; }
         string Description { get; }
         ConsoleColor Color { get; }

    }
}
