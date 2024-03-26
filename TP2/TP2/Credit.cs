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
        public double Montant { get; set; }
        public int Duree { get; set; }
        public double TauxNominal { get; set; }
        public List<Mensualite> Mensualites { get; set; }
        public double CoutTotal { get; set; }

        public Credit(double montant, int duree, double tauxNominal)
        {
            Montant = montant;
            Duree = duree;
            TauxNominal = tauxNominal;
            Mensualites = CalculateurCredit.CalculerMensualites(this);
            CoutTotal = Math.Round(CalculateurCredit.CalculerCoutTotal(this), 0);
        }
    }
}
