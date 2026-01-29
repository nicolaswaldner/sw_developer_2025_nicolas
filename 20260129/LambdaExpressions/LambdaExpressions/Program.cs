namespace LambdaExpressions
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //delegates
            Action<string> action = DoSomething;
            action("Dies ist ein delegate-Aufruf");

            //anonyme methode
            action = delegate (string message)
            {
                Console.WriteLine("Anonyme Methode: " + message);
            };
            action("Jetzt ganz anonym!");

            //lambda expressions
            action = (string message) =>
            {
                Console.WriteLine("Lambda: " + message.ToUpper());
            };
            action("Hier Lambada!");

            //lamda expressions
            action = m => Console.WriteLine("Kurz: " + m); //methoden definition
            action("Sehr kurze Variante!"); //definierte methode ausführen

            //anwendungsbeispiel: zahlenfilter
            var meineZahlen = new[] { 2, 4, 5, 7, 9, 14, 23, 27, 28, 33, 40, 52 };

            var erg = Filter(meineZahlen, GeradeZahlenFilter);

            erg = Filter(meineZahlen, x => x > 10);
            erg = Filter(meineZahlen, x => x < 22);
            erg = Filter(meineZahlen, x => x % 2 != 0);


        }

        private static bool GeradeZahlenFilter(int arg)
        {
            if (arg % 2 == 0)
            {
                return true;
            }

            return false;
        }

        private static int[] Filter(int[] zahlen, Predicate<int> filterCriteria)
        {
            var filteredValues = new List<int>();

            foreach (var zahl in zahlen)
            {
                if(filterCriteria(zahl))
                {
                    filteredValues.Add(zahl);
                }
            }

            return filteredValues.ToArray();
        }

        private static void DoSomething(string message)
        {
            Console.WriteLine(message);
        }
    }
}
