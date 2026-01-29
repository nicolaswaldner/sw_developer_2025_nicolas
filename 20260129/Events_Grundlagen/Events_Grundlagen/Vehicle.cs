namespace Events_Grundlagen
{

    internal class Vehicle
    {
        private int _maxSpeed;
        private int _currentSpeed;
        private string _description;
        private ConsoleColor _color;

        public event EventHandler<MaxSpeedReachedEventArgs> MaxSpeedReached;
        
        public Vehicle(string description)
        {
            _description = description;
            _color = ConsoleColor.White;
            _currentSpeed = 0;
            _maxSpeed = 180;
        }

        public Vehicle(string description, int maxSpeed, ConsoleColor color)
        {
            _description = description;
            _maxSpeed = maxSpeed;
            _currentSpeed = 0;
            _color = color;  
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

                //fire the event -> for more details see microsoft event pattern !
                if (MaxSpeedReached != null) //prüfen, ob jemand abonniert hat, ereignis mitzubekommen
                {
                    MaxSpeedReached(this, new MaxSpeedReachedEventArgs(_maxSpeed)); //2ter part hier ist neue instanz
                }
            }
        }

        public void Show()
        {
            Console.WriteLine($"{_description}:  {_currentSpeed}/{_maxSpeed} km/h");
        }
    }
}
