using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fuhrpark_v3
{
    internal class Scooter : IVehicle
    {
		//Zustandsinfo
		private int _maxDistance;
        private int _maxSpeed;
        private int _currentSpeed;
        private string _description;
        private ConsoleColor _color;

        //Konstruktor
        public Scooter()
            :this ("No description", 24, 100, ConsoleColor.Yellow)
        {
 
        }

        public Scooter(string description, int maxSpeed, int maxDistance)
            :this (description, maxSpeed, maxDistance, ConsoleColor.Yellow) 
        {

        }

        public Scooter(string description, int maxSpeed, int maxDistance, ConsoleColor color)
        {
            _maxDistance = maxDistance;
            _description = description;
            _maxSpeed = maxSpeed;
            _color = color;
        }

        //Properties
        public int MaxDistance
		{
			get { return _maxDistance; }
		}
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


        //Methoden
        public void Show()
        {
            //base.Show();
            ConsoleColor oldcolor = Console.ForegroundColor;
            Console.ForegroundColor = Color;

            Console.WriteLine($"Scooter: {_description} \n\t[{_currentSpeed}/{_maxSpeed} km/h] \n\t{_maxDistance} km");

            Console.ForegroundColor = oldcolor;
        }


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

        public void ChangeRadioPower(bool isOn)
        {
            throw new NotImplementedException();
        }

        public void MakeSound()
        {
            throw new NotImplementedException();
        }
    }
}
