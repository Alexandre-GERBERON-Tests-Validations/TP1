using System;

namespace TP2
{
    public class Mensualite
    {
        public int Numero { get; }
        public double RemboursementCapital { get; }
        public double RestantDu { get; }

        public Mensualite(int numero, double remboursementCapital, double restantDu)
        {
            Numero = numero;
            RemboursementCapital = Math.Round(remboursementCapital, 0);
            RestantDu = Math.Round(restantDu, 0);
        }
    }
}
