using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fuhrpark_v3
{
    public class Vehicle
    {
        //Zustandsinformationen
        private int _maxSpeed;
        private int _currentSpeed;
        private string _description;
        private ConsoleColor _color;
        //hat-ein-beziehung
        private Radio _radio;

        //Konstruktor
        public Vehicle(string description)
        {
            _maxSpeed = 180;
            _currentSpeed = 0;
            _description = description;
            _color = ConsoleColor.White;
            _radio = new Radio();
        }

        public Vehicle (string description, int maxSpeed, ConsoleColor color)
        {
            _description = description;
            _maxSpeed = maxSpeed;
            _currentSpeed = 0;
            _color = color;
            _radio = new Radio();
        }


        //Methode
        public virtual void SpeedUp(int delta)
        {
            _currentSpeed += delta;

            if (_currentSpeed < 0)
            {
                _currentSpeed = 0;
            }

            if (_currentSpeed > _maxSpeed)
            {
                _currentSpeed = _maxSpeed;
            }
        }

        public virtual void Show() //virtual, dass das überschreibbar ist später mit override
        {
            ConsoleColor oldcolor = Console.ForegroundColor;
            Console.ForegroundColor = _color;

            Console.WriteLine($"{_description} [{_currentSpeed}/{_maxSpeed} km/h]");

            Console.ForegroundColor = oldcolor;
        }

        //Methoden von Radio deligieren, dass man nicht direkt auf Radio zugreift, sondern von außen über Vehicle
        //erlaubt es, Radio später mit besserem Radio auszutauschen
        public void ChangeRadioPower(bool isOn)
        {
            if (isOn)
            {
                _radio.PowerStatus = PowerState.On;
            }
            else
            {
                _radio.PowerStatus = PowerState.Off;
            }
        }

        public void MakeSound()
        {
            _radio.MakeNoise();
        }

        //Eigenschaften/Properties


        public int MaxSpeed 
        { 
            get => _maxSpeed; 
        }

        public int CurrentSpeed 
        { 
            get => _currentSpeed;  
        }

        public virtual string Description 
        { 
            get => _description;  
        }

        public ConsoleColor Color 
        { 
            get => _color; 
        }
    }
}
