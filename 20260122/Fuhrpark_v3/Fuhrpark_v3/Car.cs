using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fuhrpark_v3
{
    internal class Car : IVehicle
    {
        //Zustandsinformationen
        private int _maxSpeed;
        private int _currentSpeed;
        private string _description;
        private ConsoleColor _color;
        private Radio _radio;
        private int _seatCount;


        //Konstruktor
        public Car(string description)
        {
            _maxSpeed = 180;
            _currentSpeed = 0;
            _description = description;
            _color = ConsoleColor.White;
            _seatCount = 5;
            _radio = new Radio();
        }

        public Car(string description, int maxSpeed, ConsoleColor color, int seatCount)
        {
            _description = description;
            _maxSpeed = maxSpeed;
            _currentSpeed = 0;
            _color = color;
            _seatCount = seatCount;
            _radio = new Radio();
        }


        //Methoden
        public void SpeedUp(int delta)
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

        public void Show()
        {
            ConsoleColor oldcolor = Console.ForegroundColor;
            Console.ForegroundColor = _color;

            Console.WriteLine($"{_description} [{_currentSpeed}/{_maxSpeed} km/h]");

            Console.ForegroundColor = oldcolor;
        }

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
        public string Description
        {
            get => _description;
        }
        public ConsoleColor Color
        {
            get => _color;
        }
        public int SeatCount
        {
            get { return _seatCount; }
        }
    }
}
