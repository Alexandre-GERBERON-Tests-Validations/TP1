using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TP2
{
    public class Credit
    {
        public decimal Montant { get; set; }
        public int Duree { get; set; }
        public decimal TauxNominal { get; set; }
        public List<Mensualite> Mensualites { get; set; }
        public decimal CoutTotal { get; set; }

        public Credit(decimal montant, int duree, decimal tauxNominal)
        {
            Montant = montant;
            Duree = duree;
            TauxNominal = tauxNominal;
            Mensualites = CalculateurCredit.CalculerMensualites(this);
            CoutTotal = CalculateurCredit.CalculerCoutTotal(this);
        }
    }
}
