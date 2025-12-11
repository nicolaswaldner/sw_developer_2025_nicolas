using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wifi.Toolbox.Tools
{
    public abstract class ConsoleTools
    {
        //GetDouble inkl. RangeCheck
        //GetBool
        //GetDecimal inkl. RangeCheck
        //WriteColoredMessage mit default-color und eine ohne (Überladungen)

        public static DateTime GetDateTime(string inputPrompt)
        {
            DateTime inputValue = DateTime.MinValue;
            bool isUserInputValid;

            do
            {
                try
                {
                    Console.Write(inputPrompt);
                    inputValue = DateTime.Parse(Console.ReadLine());

                    isUserInputValid = true;
                }
                catch (Exception ex)
                {
                    isUserInputValid = false;
                }
            }
            while (isUserInputValid == false);

            return inputValue;
        }

        public static int GetInt(string inputPrompt, int minValue, int maxValue)
        {
            //1. Eingabe der Zahl
            int inputValue = 0;
            bool isUserInputValid;

            //Parameter value check
            if (minValue >= maxValue)
            {
                throw new ArgumentException("Ungültiger Wertebereich definiert.");
            }

            do
            {
                try
                {
                    Console.Write(inputPrompt);
                    inputValue = int.Parse(Console.ReadLine());

                    //2. Range Check durchführen
                    if (inputValue >= minValue && inputValue <= maxValue)
                    {
                        isUserInputValid = true;
                    }
                    else
                    {
                        isUserInputValid = false;
                    }
                }
                catch (Exception ex)
                {

                    Console.WriteLine("\aERROR: " + ex.Message);
                    isUserInputValid = false;
                }
            }
            while (isUserInputValid == false);

            return inputValue;


        }
        public static int GetInt(string inputPrompt)
        {
            return GetInt(inputPrompt, int.MinValue, int.MaxValue);
        }

        public static void CreateHeader(string titleString)
        {
            int startPositionX = 0;
            //string headerString = "Teilnehmer-Verwaltung v1.0";

            string headerBorder = new string('#', Console.WindowWidth - 1);
            Console.WriteLine(headerBorder);
            startPositionX = (Console.WindowWidth - titleString.Length) / 2;
            Console.CursorLeft = startPositionX;
            Console.WriteLine(titleString);
            Console.WriteLine(headerBorder);
            Console.WriteLine();
        }



        public static bool IsInRange<T>(T value, T min, T max) where T : IComparable<T>
        {
            return value.CompareTo(min) >= 0 && value.CompareTo(max) <= 0;
        }

        public static double GetDouble(string inputPrompt, double minValue, double maxValue)
        {
            if (minValue >= maxValue)
                throw new ArgumentException("Ungültiger Wertebereich definiert.");

            double inputValue = 0;
            bool isUserInputValid;

            do
            {
                try
                {
                    Console.Write(inputPrompt);
                    inputValue = double.Parse(Console.ReadLine());

                    isUserInputValid = IsInRange(inputValue, minValue, maxValue);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("\nERROR: " + ex.Message);
                    isUserInputValid = false;
                }
            }
            while (isUserInputValid==false);

            return inputValue;
        }

        public static bool GetBool(string inputPrompt)
        {
            bool isUserInputValid = false;
            bool result = false;

            do
            {
                try
                {
                    Console.Write(inputPrompt);
                    result = bool.Parse(Console.ReadLine());  // nur true/false erlaubt
                    isUserInputValid = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("ERROR: " + ex.Message);
                    isUserInputValid = false;
                }

            } while (isUserInputValid== false);

            return result;
        }

        public static decimal GetDecimal(string inputPrompt, decimal minValue, decimal maxValue)
        {
            if (minValue >= maxValue)
                throw new ArgumentException("Ungültiger Wertebereich definiert.");

            decimal inputValue = 0;
            bool isUserInputValid;

            do
            {
                try
                {
                    Console.Write(inputPrompt);
                    inputValue = decimal.Parse(Console.ReadLine());

                    isUserInputValid = IsInRange(inputValue, minValue, maxValue);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("\nERROR: " + ex.Message);
                    isUserInputValid = false;
                }
            }
            while (isUserInputValid == false);

            return inputValue;
        }

        public static void WriteColoredMessage(string message)
        {
            WriteColoredMessage(message, Console.ForegroundColor = ConsoleColor.Yellow);
        }

        public static void WriteColoredMessage(string message, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(message);
            Console.ResetColor();
        }

    }

}
