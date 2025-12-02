using System;

namespace ExceptionsGL
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double length = 0.0;
            double height = 0.0;
            double circumference = 0.0;
            double area = 0.0;
            int startPositionX = 0;
            string headerString = "Rechtecks-Berechnungen v1.0";
            string userInput = string.Empty;

            //1. Ausgabe Header
            string headerBorder = new string('#', Console.WindowWidth - 1);
            Console.WriteLine(headerBorder);
            startPositionX = (Console.WindowWidth - headerString.Length) / 2;
            Console.CursorLeft = startPositionX;
            Console.WriteLine(headerString);
            Console.WriteLine(headerBorder);
            Console.WriteLine();

            try //try-blöcke so kurz wie möglich halten, um lange laufzeiten zu vermeiden
            {
                //2. Eingabe der Rechtecks-Werte (L, B)
                Console.Write("Bitte Länge eingeben: ");
                //userInput = Console.ReadLine();
                length = double.Parse(Console.ReadLine());

                Console.Write("Bitte Höhe eingeben: ");
                //userInput = Console.ReadLine();
                height = double.Parse(Console.ReadLine());
            }
            catch (FormatException)
            {
                Console.WriteLine("\aERROR: Eingabe war leider keine Zahl.");
                return; //kleinere/spezifischere Exception zuerst, dann die allgemeine Exception
            }
            catch (Exception ex)
            {
                Console.WriteLine("\aERROR: " + ex.Message);
                return; //beendet Methode
            }
            finally //wird immer ausgeführt, egal ob Fehler gecatched wurde oder nicht
            {

            }

            //3. Berechnung der Fäche und Umfang
            circumference = 2 * (length +  height);
            area = length * height;

            //4. Ausgabe Ergebnisse
            Console.WriteLine("\nUmfang: " + circumference + "mm");
            Console.WriteLine("Fläche: " + area + "mm²");


        }
    }
}
