using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EingabenAusgabenUebung
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string name = string.Empty;
            int age = 0;
            int height = 0;
            DateTime birthday = DateTime.MinValue;
            bool isUserInputValid = false;
            int startPositionX = 0;
            string headerString = "Teilnehmer-Verwaltung v1.0";


            //1. Ausgabe Header
            string headerBorder = new string('-', Console.WindowWidth - 1);
            Console.WriteLine(headerBorder);
            startPositionX = (Console.WindowWidth - headerString.Length) / 2;
            Console.CursorLeft = startPositionX;
            Console.WriteLine(headerString);
            Console.WriteLine(headerBorder);
            Console.WriteLine();

            //2. Daten erfassen
            Console.WriteLine("Please enter following information:");
            
            Console.Write("\nName: ");
            name = Console.ReadLine();

            do
            {
                try
                {
                    Console.Write("Age: ");
                    age = int.Parse(Console.ReadLine());
                    isUserInputValid = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    isUserInputValid = false;
                } 
            } 
            while (isUserInputValid == false);

            do
            {
                try
                {
                    Console.Write("Height: ");
                    height = int.Parse(Console.ReadLine());
                    isUserInputValid = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    isUserInputValid = false;
                }
            }
            while (isUserInputValid == false);

            do
            {
                try
                {
                    Console.Write("Birthdate (DD.MM.YYYY): ");
                    birthday = DateTime.Parse(Console.ReadLine());
                    isUserInputValid = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    isUserInputValid = false;
                }
            }
            while (isUserInputValid == false);

            //3. Daten-Ausgabe
            Console.ForegroundColor = ConsoleColor.DarkCyan;

            Console.WriteLine("\nData:\n");    
            Console.WriteLine("\tName: " + name.ToUpper());
            Console.WriteLine("\tAge: " + age);
            Console.WriteLine("\tHeight: " + height +"cm");
            Console.WriteLine("\tBirthdate: " + birthday.ToLongDateString());

            Console.ResetColor();

        }
    }
}
