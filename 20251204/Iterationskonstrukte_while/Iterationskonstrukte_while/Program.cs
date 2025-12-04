using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iterationskonstrukte_while
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //kopfgesteuerte Schleife
            while (DateTime.Now.Hour == 18)
            {
                Console.WriteLine("Es ist noch immer 18:00 Uhr");
            }

            //fussgesteuerte Schleife; wird mind. einmal ausgeführt
            do
            {
                Console.WriteLine("Es ist noch immer 18:00 Uhr");
            }
            while (DateTime.Now.Hour == 18);
        }
    }
}
