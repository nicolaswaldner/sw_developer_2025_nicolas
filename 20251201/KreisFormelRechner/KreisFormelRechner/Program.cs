using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KreisFormelRechner
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string radius = string.Empty;
            double fläche = 0;
            double eingabeRadius = 0;
            double umfang = 0;

            Console.Write("Bitte Radius deines Kreises angeben: ");
            radius = Console.ReadLine();

            eingabeRadius = double.Parse(radius);

            umfang = 2.0 * eingabeRadius * Math.PI;

            fläche = Math.PI * Math.Pow(eingabeRadius, 2);

            Console.WriteLine("\nDer Umfang deines Kreises ist " + Math.Round(umfang, 2) + "cm lang.\n");
            Console.WriteLine("Die Fläche deines Kreises ist " + Math.Round(fläche, 2) + "cm² groß.");

        }
    }
}
