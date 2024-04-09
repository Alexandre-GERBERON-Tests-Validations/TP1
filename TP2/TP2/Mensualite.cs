using System;

namespace TP2
{
    public class Mensualite
    {
        public int Numero { get; }
        public decimal InteretRembourse { get; }
        public decimal CapitalRestantDu { get; }
        public decimal CapitalTotalRembourse { get; }
        public decimal CoutMensualite { get; }

        public Mensualite(int numero, decimal interetRembourse, decimal capitalRestantDu, decimal capitalTotalRembourse, decimal mensualite)
        {
            Numero = numero;
            InteretRembourse = interetRembourse;
            CapitalRestantDu = capitalRestantDu;
            CapitalTotalRembourse = capitalTotalRembourse;
            CoutMensualite = mensualite;
        }
    }
}
