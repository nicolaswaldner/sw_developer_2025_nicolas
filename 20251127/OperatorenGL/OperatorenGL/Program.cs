using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperatorenGL
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Arithmetische Operatoren
            // + - * /   % -> RestWertDivision

            //Zusammengesetzte Operatoren oder Incremente/Decrement
            int zahl = 5;

            zahl = zahl + 3;
            zahl += 3; //zur ersten Variable werden 3 hinzugefügt
            zahl -= 2;
            zahl *= 5;
            zahl /= 3;

            zahl += 1;
            zahl++; //inkrementieren -> zahl wird um eins erhöht (funktioniert nur mit ganzen zahlen)
            zahl--;

            zahl++; //-> POST inkrement
            ++zahl; //-> PRE inkrement

            zahl = 3;
            Console.WriteLine("Zahl: " + zahl++); //zahl ist 3, dann um eins erhöht (wird aber nicht angezeigt)
            Console.WriteLine("Zahl: " + ++zahl); //zahl ist 4 (von vorher addiert), zahl ist 5

            //Vergleichs Operatoren
            // == != < > <= >=

            //Logische Operatoren
            // & -> AND  (&&)
            // | -> OR   (||)
            // ! -> NOT
        }
    }
}
