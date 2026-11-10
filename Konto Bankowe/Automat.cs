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
        private Dictionary<decimal, int> _iloscMonet = new Dictionary<decimal, int>
        {
            { 5, 0 },
            { 2, 0 },
            { 1, 0 },
            { 0.5m, 0 },
            { 0.2m, 0 },
            { 0.1m, 0 }
        };
        private readonly decimal[] _przyjmowaneMonety = new decimal[] { 5, 2, 1, 0.5m, 0.2m, 0.1m };

        public void WrzucMonety(KontoBankowe konto, string WartoscMonety)
        {
            int przyjeteMonety = 0;
            int odrzuconeMonety = 0;
            string[] wartosciMonet = WartoscMonety.Split(' ');

            foreach (string wartoscMonety in wartosciMonet)
            {
                string ReplacedWartoscMonety = WartoscMonety.Replace(",", ".");
                bool czyPrzyjeto = false;
                bool czyUdanyParse = decimal.TryParse(ReplacedWartoscMonety, NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture, out decimal wartosc);

                if (!czyUdanyParse)
                {
                    Console.WriteLine("Nieudany odczyt monety");
                    odrzuconeMonety++;
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
                            przyjeteMonety++;

                            _iloscMonet[nominal]++;
                            // Console.WriteLine($"debug: ilosc przyjętych monet {nominal}: {_iloscMonet[nominal]}");
                        }
                    }
                    if (czyPrzyjeto == false)
                    {
                        odrzuconeMonety++;
                        Console.WriteLine($"moneta nie przyjęta ({wartosc})");
                    }
                }
                Console.WriteLine($"Przyjęto {przyjeteMonety} monety");
                Console.WriteLine($"Odrzucono {odrzuconeMonety} monety");
            }
        }
        public void PokazMonety()
        {
            Console.WriteLine($"Ilość monet 5 zł: {_iloscMonet[5]}");
            Console.WriteLine($"Ilość monet 2 zł: {_iloscMonet[2]}");
            Console.WriteLine($"Ilość monet 1 zł: {_iloscMonet[1]}");
            Console.WriteLine($"Ilość monet 0,50 zł: {_iloscMonet[0.5m]}");
            Console.WriteLine($"Ilość monet 0,20 zł: {_iloscMonet[0.2m]}");
            Console.WriteLine($"Ilość monet 0,10 zł: {_iloscMonet[0.1m]}");
            decimal wartosc;
            wartosc = (_iloscMonet[5] * 5) + (_iloscMonet[2] * 2) + (_iloscMonet[1] * 1) + (_iloscMonet[0.5m] * 0.5m) + (_iloscMonet[0.2m] * 0.2m) + (_iloscMonet[0.1m] * 0.1m);
            Console.WriteLine($"Wartość wszystkich monet: {wartosc} zł");
        }

        public void WrzucMonety2(KontoBankowe konto, string monety)
        {
            int przyjeteMonety = 0;
            int odrzuconeMonety = 0;

            string[] wartosciMonet = monety.Split(' ');
            foreach (string wartoscMonety in wartosciMonet)
            {
                Console.WriteLine($"debug: odczytano monetę ({wartoscMonety})");
                string ReplacedWartoscMonety = wartoscMonety.Replace(",", ".");
                bool czyPrzyjeto = false;
                bool czyUdanyParse = decimal.TryParse(ReplacedWartoscMonety, NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture, out decimal wartosc);

                if (!czyUdanyParse)
                {
                    Console.WriteLine("Nieudany odczyt monety");
                    odrzuconeMonety++;
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
                            przyjeteMonety++;
                        }
                    }
                    if (czyPrzyjeto == false)
                    {
                        odrzuconeMonety++;
                        Console.WriteLine($"moneta nie przyjęta ({wartosc})");
                    }
                }
            }
            Console.WriteLine($"Przyjęto {przyjeteMonety} monety");
            Console.WriteLine($"Odrzucono {odrzuconeMonety} monety");
        }
    }
}