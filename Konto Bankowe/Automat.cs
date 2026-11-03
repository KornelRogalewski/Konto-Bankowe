using System;
using System.Collections.Generic;
using System.Globalization;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Xml.Schema;

namespace Konto_Bankowe
{
    internal class Automat
    {
        private int _iloscMonet5;
        private int _iloscMonet2;
        private int _iloscMonet1;
        private int _iloscMonet05;
        private int _iloscMonet02;
        private int _iloscMonet01;
        private readonly decimal[] _przyjmowaneMonety = new decimal[] { 5, 2, 1, 0.5m, 0.2m, 0.1m };

        public void WrzucMonete(KontoBankowe konto, string WartoscMonety)
        {
            string ReplacedWartoscMonety = WartoscMonety.Replace(",", ".");
            bool czyPrzyjeto = false;

            bool czyUdanyParse = decimal.TryParse(ReplacedWartoscMonety, NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture, out decimal wartosc);
            if (!czyUdanyParse)
            {
                Console.WriteLine("Nieudany odczyt monety");
                return;
            }
            else
            {
                foreach (decimal nominal in _przyjmowaneMonety)
                {
                    if (wartosc == nominal)
                    {
                        konto.Wplac(wartosc);
                        Console.WriteLine($"moneta przyjęta ({wartosc})");
                        czyPrzyjeto = true;
                        switch(wartosc)
                        {
                            case 5:
                                _iloscMonet5++;
                                break;
                            case 2:
                                _iloscMonet2++;
                                break;
                            case 1:
                                _iloscMonet1++;
                                break;
                            case 0.5m:
                                _iloscMonet05++;
                                break;
                            case 0.2m:
                                _iloscMonet02++;
                                break;
                            case 0.1m:
                                _iloscMonet01++;
                                break;
                        }
                    }
                }
                if (czyPrzyjeto == false)
                {
                    Console.WriteLine($"moneta nie przyjęta ({wartosc})");
                }
            }
        }
        public void PokazMonety()
        {
            Console.WriteLine($"Ilość monet 5 zł: {_iloscMonet5}");
            Console.WriteLine($"Ilość monet 2 zł: {_iloscMonet2}");
            Console.WriteLine($"Ilość monet 1 zł: {_iloscMonet1}");
            Console.WriteLine($"Ilość monet 0,50 zł: {_iloscMonet05}");
            Console.WriteLine($"Ilość monet 0,20 zł: {_iloscMonet02}");
            Console.WriteLine($"Ilość monet 0,10 zł: {_iloscMonet01}");
            decimal wartosc;
            wartosc = (_iloscMonet5 * 5) + (_iloscMonet2 * 2) + (_iloscMonet1 * 1) + (_iloscMonet05 * 0.5m) + (_iloscMonet02 * 0.2m) + (_iloscMonet01 * 0.1m);
            Console.WriteLine($"Wartość wszystkich monet: {wartosc} zł");
        }
    }
}