namespace KlassenGrundlagen
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Employee ist die Klasse
            //ma ist das Objekt/Instanz

            //Instanziierung
            Employee ma = new Employee("Max", "Mustermann", new DateTime(2006, 2, 15));

            ////Initialisierung
            //ma.Name = "Max";
            //ma.Surname = "Mustermann";
            //ma.Id = Guid.NewGuid();
            //ma.Salary = 1700.0m;
            //ma.Birthday = new DateTime(2006, 2, 15);

            ma.GiveBonus(0.1);
            ma.Display();

            //bonus geben
            ma.GiveBonus(0.1);

            //neues Gehalt darstellen
            Console.WriteLine($"Neues Gehalt: EUR {ma.Salary.ToString("#,###.00")}");
        }
    }
}
