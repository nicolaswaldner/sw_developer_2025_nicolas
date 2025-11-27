using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VariablenUndDatentypen
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Deklaration
            string name;

            //Initialisierung
            name = "Gandalf"; //string.Empty 

            //Deklaration & Initialsierung
            string userName = string.Empty;

            userName = name.Substring(4, 1);
          
            Console.WriteLine("Name: " + userName);

            //für ganze Zahlen
            int zahl1 = 5;
            int zahl2 = 10;
            int erg = 0;

            erg = zahl1 + zahl2;
            //Math. (Mathebibliothek)

            double gewicht = 21.3143;
            Console.WriteLine("Gewicht: " + gewicht);
            //erg = 2 * gewicht; zwei unterschiedliche Datentypen

            bool isPowerOn = false; //true (mehr geht nicht)

            //für Geld-Beträge
            decimal price = 0.0m;




        }
    }
}
