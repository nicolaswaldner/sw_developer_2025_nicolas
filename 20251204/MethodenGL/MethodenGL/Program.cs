using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MethodenGL
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PrintHelloWorld();

            PrintMessage("C# ist so cool");
            PrintMessage("Hello World");
            
            PrintColoredMessage("Error: Test", ConsoleColor.Red);
            PrintColoredMessage("Hello World", ConsoleColor.Green);

        }

        static void PrintColoredMessage(string message, ConsoleColor messageColor)
        {
            //save set color to be able to restore it
            ConsoleColor oldColor = Console.ForegroundColor;

            Console.ForegroundColor = messageColor;
            Console.WriteLine(message);

            Console.ForegroundColor = oldColor; 
        }
        static void PrintMessage(string message)
        {
            Console.WriteLine(message);
        }

        //Rückgabetype MethodenName ( Parameter-Liste )
        static void PrintHelloWorld() //Signatur
        {
            Console.WriteLine("Hello World!");
        }

    }
}
