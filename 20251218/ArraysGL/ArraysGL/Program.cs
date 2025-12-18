namespace ArraysGL
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int zahl;

            //Deklaration
            int[] zahlen;
            string[] namen;
            

            //Dimensionierung
            zahlen = new int[5]; //5 ist die Anzahl der Elemente in der Liste

            zahlen[0] = 2;
            zahlen[1] = -3;
            zahlen[2] = 2543;
            zahlen[3] = 1560;

            Console.WriteLine("Wert 1 = " + zahlen[0]);
        }
    }
}
