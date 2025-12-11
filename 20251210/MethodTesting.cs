using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wifi.Toolbox.Tools;

namespace Wifi.Toolbox.TestApplication
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ConsoleTools.CreateHeader("Demo Application ConsoleTools");

            ConsoleTools.WriteColoredMessage("Hi\n");
            ConsoleTools.WriteColoredMessage("Bitte ausfüllen:\n", ConsoleColor.Cyan);

            int geburtsJahr = ConsoleTools.GetInt("Bitte Geburtsjahr eingeben: ",
                DateTime.Now.Year - 150, DateTime.Now.Year - 5);

            double gewicht = ConsoleTools.GetDouble("Bitte Gewicht angeben: ", 40, 300);

            decimal height = ConsoleTools.GetDecimal("Bitte Größe angeben: ", 100, 300);

            


        }
    }
}
