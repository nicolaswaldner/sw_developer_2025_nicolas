using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KlassenGrundlagen
{
    public class Employee
    {
        //Zustandsinformationen
        public string Name;
        public string Surname;
        public Guid Id;
        public decimal Salary;
        public DateTime Birthday;

        //standard Konstruktor, heißt gleich wie die Class
        //public Employee()
        //{
        //    Name = "No";
        //    Surname = "Name";

        //    Id = Guid.NewGuid();
        //    Salary = 1000.0m;
        //}

        //user specific Konstruktor
        public Employee(string name, string surname, DateTime birthday)
        {
            Name = name;
            Surname = surname;
            Birthday = birthday;

            Id = Guid.NewGuid();
            Salary = 1000.0m;
        }

        public void GiveBonus(double bonusInPercent)
        {
            if(bonusInPercent > 0 && bonusInPercent <= 1)
            {
                //new salary with bonus
                Salary += Salary * (decimal)bonusInPercent;

                int age = DateTime.Now.Year - Birthday.Year;

                //20 => 2000  25 ==> 2500  40 ==> 4000
                decimal maxSalary = age * 100;

                if(Salary > maxSalary)
                {
                    Salary = maxSalary;
                }
            }

            
        }


        //Methoden/Logik
        public void Display()
        {
            Console.WriteLine($"{Name} {Surname}");
            Console.WriteLine($"ID: {Id}");
        }


    }
}
