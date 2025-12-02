using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace if_Grundlagen
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int zahl1 = 50; //5...20
            int zahl2 = 8;

            if (zahl1 >= 5 && zahl1 <= 20)
            {
                Console.WriteLine("Zahl1 ist kleiner als Zahl2.");
            }
            else
            {
                Console.WriteLine("Zahl1 ist nicht kleiner als Zahl2.");
            }

        }
    }
}
