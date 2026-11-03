using System.Runtime.InteropServices;

namespace Konto_Bankowe
{
    internal class Program
    {
        static void Main(string[] args)
        {
            KontoBankowe kontoBankowe = new KontoBankowe();

            Automat automat = new Automat();

            automat.WrzucMonete(kontoBankowe, "2");
            automat.WrzucMonete(kontoBankowe, "0.5");
            automat.WrzucMonete(kontoBankowe, "3");
            automat.WrzucMonete(kontoBankowe, "dwa");

            Console.WriteLine(kontoBankowe.StanKonta());
            Console.WriteLine(kontoBankowe.Numer());
            automat.PokazMonety();

            KontoBankowe kontoBankowe2 = new KontoBankowe();
            Console.WriteLine(kontoBankowe.Numer());
        }
    }
}
