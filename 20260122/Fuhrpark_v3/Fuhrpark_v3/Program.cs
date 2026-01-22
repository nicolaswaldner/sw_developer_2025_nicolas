
namespace Fuhrpark_v3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var myVehicleList = new IVehicle[]
            {
                new Car("Fiat e500 City", 165, ConsoleColor.Gray),
                new Scooter(),
                new Scooter("Mikey Mouse Scooter", 35, 150),
                new RacingCar("BadMobil F1 Edition", 385, ConsoleColor.DarkCyan, DownforceType.Wings)
            };

            ShowVehicles(myVehicleList);
        }

        private static void ShowVehicles(IVehicle[] myVehicleList)
        {
            foreach (var vehicle in myVehicleList)
            {
                vehicle.Show();
            }
        }
    }
}
