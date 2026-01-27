namespace Grundlagen_Delegates
{
    internal delegate int OperationDelegate(int z1, int z2);

    internal delegate void ErrorHandler(Exception ex);

    internal class Program
    {
        static void Main(string[] args)
        {
            OperationDelegate op;

            op = Addieren;

            var summe = Addieren(5, 8);

            summe = op(10, 15);
            Console.WriteLine("Summe: " + summe);

            op = Subtrahieren;
            summe = op(10, 15);
            Console.WriteLine("Differenz: " + summe);

            var eingabe = GetValue<int>("Bitte geben Sie Ihr Alter sein: ", DefaultErrorHandler);
        }

        private static int Addieren(int zahl1, int zahl2)
        {
            return zahl1 + zahl2;
        }

        private static int Subtrahieren(int zahl1, int zahl2)
        {
            return zahl1 - zahl2;
        }

        private static T GetValue<T>(string inputPrompt, ErrorHandler errorHandler) where T : IParsable<T> 
        {
            bool inputIsValid = false;
            T userValue = default(T);
            Type type = typeof(T);

            do
            {
                Console.Write(inputPrompt);
                try 
                {
                    var methode = type.GetMethod("Parse", new Type[] { typeof(string) });
                    if (methode != null)
                    {
                        userValue = (T)methode.Invoke(null, new object[] { Console.ReadLine() });

                        inputIsValid = true;
                    }

                }
                catch(Exception ex)
                {
                    if (errorHandler != null)
                    {
                        errorHandler(ex);
                    }
                    
                    inputIsValid = false;
                }
            }
            while (!inputIsValid);

            return userValue;
        }

        private static void DefaultErrorHandler(Exception ex)
        {
            Console.WriteLine("ERROR: Ungültige Eingabe.");
        }

    }
}
