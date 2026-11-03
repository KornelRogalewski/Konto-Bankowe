using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;

namespace Konto_Bankowe
{
    internal class KontoBankowe
    {
        private decimal _saldo;

        public string _numer()
        {
            string _numer = RandomNumberGenerator.GetString("0123456789", 25);
            return _numer;
        }

        public string Numer()
        {
           return ($"Numer Konta: {_numer()}");
        }
        public decimal Saldo
        {
            get { return _saldo; }
        }
        public void Wplac(decimal kwota)
        {
            _saldo += kwota;
        }
        public string StanKonta()
        {
            return ($"Saldo Konta: {_saldo} zł.");
        }

    }
}
