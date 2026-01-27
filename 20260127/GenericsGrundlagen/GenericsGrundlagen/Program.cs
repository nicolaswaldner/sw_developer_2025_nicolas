



using System.Reflection;

namespace GenericsGrundlagen
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var myNameList = CreateStringArray(15, "No Name");

            var BirthdayYearList = CreateIntArray(5, 1990);

            myNameList = CreateArray<string>(4, string.Empty);

            var priceList = CreateArray<decimal>(15, 0.0m);

            List<double> weightList = new List<double>();

            weightList.Add(0.5);

            var count = GetValue<int>("Bitte Anzahl eingeben: ");
            var birthday = GetValue<DateTime>("Bitte Geburtsdatum eingeben: ");
        }

        private static T GetValue<T>(string inputPrompt) where T : IParsable<T> //Constraints, ich schränke Möglichkeit von T ein, nur Typen, die IParsable unterstützen verwenden
        {
            bool inputIsValid = false;
            T userValue = default(T);
            Type type = typeof(T);

            do
            {
                Console.Write(inputPrompt);
                try //indirekter Aufruf von Parse-Methode, weil T.Parse nicht geht
                {
                    var methode = type.GetMethod("Parse", new Type[] { typeof(string) });
                    if (methode != null)
                    {
                        userValue = (T)methode.Invoke(null, new object[] { Console.ReadLine() });
                        
                        inputIsValid = true;
                    }

                    //userValue = int.Parse(Console.ReadLine());
                    
                }
                catch
                {
                    Console.WriteLine("ERROR: Ungültige Eingabe.");
                    inputIsValid = false;
                }
            }
            while (!inputIsValid);

            return userValue;
        }

        //durch <T> wird die Methode generisch, kann wiederverwendet werden für verschiedene Datentypen
        private static T[] CreateArray<T>(int lenght, T initValue)
        {
            var array = new T[lenght];

            for (int i = 0; i < lenght; i++)
            {
                array[i] = initValue;
            }

            return array;
        }

        private static int[] CreateIntArray(int lenght, int initValue)
        {
            var array = new int[lenght];

            for (int i = 0; i < lenght; i++)
            {
                array[i] = initValue;
            }

            return array;
        }

        private static string[] CreateStringArray(int length, string initValue)
        {
            //create the array
            var array = new string[length];

            //initialize the array values
            for (int i = 0; i < length; i++)
            {
                array[i] = initValue;
            }

            return array;
        }
    }
}
