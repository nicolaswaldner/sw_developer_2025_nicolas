using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vererbung_GL
{
    public class Vehicle
    {
        //Zustandsinformationen
        private int _maxSpeed;
        private int _currentSpeed;
        private string _description;
        private ConsoleColor _color;


        //Konstruktor
        public Vehicle(string description)
        {
            _maxSpeed = 180;
            _currentSpeed = 0;
            _description = description;
            _color = ConsoleColor.White;
        }

        public Vehicle (string description, int maxSpeed, ConsoleColor color)
        {
            _description = description;
            _maxSpeed = maxSpeed;
            _currentSpeed = 0;
            _color = color;
        }

        //Methode
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
    }
}
