using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrundlagenKlassen_II
{
    public class Employee
    {
        //Zustandsinformationen (Felder/Fields, immer private machen)
        private string _surname;
        private string _name;
        private Guid _id;
        private decimal _salary;
        private DateTime _birthday;
        private Adresse _adress;


        //standard Konstruktor, heißt gleich wie die Class
        //public Employee()
        //{
        //    Name = "No";
        //    Surname = "Name";

        //    Id = Guid.NewGuid();
        //    Salary = 1000.0m;
        //}

        //user specific Konstruktor

        public Employee(string name, string surname, DateTime birthday, Adresse adress)
            : this(name, surname, birthday)
        {
            _adress = adress;
        }
        public Employee(string name, string surname, DateTime birthday)
        {
            _name = name;
            _surname = surname;
            _birthday = birthday;

            _id = Guid.NewGuid();
            _salary = 1000.0m;
        }

        public void GiveBonus(double bonusInPercent)
        {
            if (bonusInPercent > 0 && bonusInPercent <= 1)
            {
                //new salary with bonus
                _salary += _salary * (decimal)bonusInPercent;

                int age = DateTime.Now.Year - _birthday.Year;

                //20 => 2000  25 ==> 2500  40 ==> 4000
                decimal maxSalary = age * 100;

                if (_salary > maxSalary)
                {
                    _salary = maxSalary;
                }
            }


        }


        //Methoden/Logik
        public void Display()
        {
            Console.WriteLine($"{_name} {_surname}");
            Console.WriteLine($"ID: {_id}");
        }

        //Änderungs- und Zugriffsmethoden
        //public decimal GetSalary()
        //{
        //    return Salary; 
        //}

        //public void SetSurname(string newSurname)
        //{
        //    if(!string.IsNullOrEmpty(newSurname))
        //    {
        //        Surname = newSurname;
        //    }
        //}

        //Eigenschaften / Properties (müssen public sein, sind da, um sie von außen zu nutzen + abzurufen)
        public string Name //ist keine Methode, deshalb keine ()
        {
            get
            {
                return _name;
            }

            //set
            //{
            //    if(string.IsNullOrEmpty(value))
            //    {
            //        _name = value;
            //    }
            //}
        }

        public string Surname
        {
            get
            {
                return _surname;
            }
        }

        public Guid Id
        {
            get
            {
                return _id;
            }
        }

        public decimal Salary
        {
            get
            {
                return _salary;
            }
        }

        public DateTime Birthday
        {
            get
            {
                return _birthday;
            }
        }


    }
}
