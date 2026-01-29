

namespace Events_Grundlagen
{
    internal class Program
    {
        static bool stopSpeedUp = false;

        static void Main(string[] args)
        {
            var myCar = new Vehicle("MyBadMobil V12");

            //Abos
            myCar.MaxSpeedReached += MyCar_MaxSpeedReached;
            myCar.MaxSpeedReached += MyCar_MaxSpeedReached1;


            while(!stopSpeedUp)
            {
                myCar.SpeedUp(20);
                myCar.Show();
            }
            
        }

        private static void MyCar_MaxSpeedReached1(object? sender, MaxSpeedReachedEventArgs e)
        {
            if (sender is Vehicle vehicle)
            {
                //vehicle.
            }
            
            stopSpeedUp = true;
        }

        private static void MyCar_MaxSpeedReached(object? sender, MaxSpeedReachedEventArgs e)
        {
            Console.WriteLine($"\t==>Max Speed ({e.MaxSpeed}) wurde erreicht.");
        }

        //private static void MyCar_MaxSpeedReached1(int currentSpeed, int maxSpeed)
        //{
        //    stopSpeedUp = true;
        //}

        //private static void MyCar_MaxSpeedReached(int currentSpeed, int maxSpeed)
        //{
        //    Console.WriteLine($"\t==>Max Speed ({maxSpeed}) wurde erreicht.");
        //}
    }
}
