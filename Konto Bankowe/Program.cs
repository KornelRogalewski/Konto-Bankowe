using System.Runtime.InteropServices;

namespace Konto_Bankowe
{
    internal class Program
    {
        static void Main(string[] args)
        {
            KontoBankowe kontoBankowe = new KontoBankowe();

            Automat automat = new Automat();

            automat.WrzucMonety(kontoBankowe, "2");
            automat.WrzucMonety(kontoBankowe, "0.5");
            automat.WrzucMonety(kontoBankowe, "0,2");
            automat.WrzucMonety(kontoBankowe, "3");
            automat.WrzucMonety(kontoBankowe, "dwa");

            Console.WriteLine(kontoBankowe.StanKonta());
            Console.WriteLine(kontoBankowe.Numer());
            automat.PokazMonety();

            KontoBankowe kontoBankowe2 = new KontoBankowe();
            Console.WriteLine(kontoBankowe2.Numer());

            automat.WrzucMonety2(kontoBankowe2, "5 2 abc 0.5 3");
            Console.WriteLine(kontoBankowe2.StanKonta());
            
        }
    }
}
