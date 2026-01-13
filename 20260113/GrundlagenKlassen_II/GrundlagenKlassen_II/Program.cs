namespace GrundlagenKlassen_II
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Employee ma = new Employee("Max", "Mustermann", new DateTime(1980, 5, 15));

            ma.Display();

            Console.WriteLine($"Aktuelle Gehalt: EUR {ma.Salary.ToString("#,###.00")}");

            ma.GiveBonus(0.05);

            Console.WriteLine($"Aktuelle Gehalt: EUR {ma.Salary.ToString("#,###.00")}");

            //ma.Salary = 5500.90m;
            Console.WriteLine($"Aktuelle Gehalt: EUR {ma.Salary.ToString("#,###.00")}");

            Console.WriteLine($"Name: {ma.Name}"); //lesen (get)

            

        }
    }
}
