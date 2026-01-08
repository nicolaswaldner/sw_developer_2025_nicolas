namespace GeneralTopics
{
    internal class Program
    {
        //Konstanten
        const ConsoleColor DefaultForegroundColor = ConsoleColor.Cyan;

        static void Main(string[] args)
        {
            Console.ForegroundColor = Program.DefaultForegroundColor;

            Console.WriteLine("Hallo zusammen!");
            Console.ResetColor();

            //hart-kodierte Werte (hard-coded)
            

            //Program.DefaultForegroundColor = ConsoleColor.Yellow;

//####################################################################################################################

            bool isValid = false;

            if (isValid)
            {
                Console.WriteLine("is true");
            }

        }
    }
}
