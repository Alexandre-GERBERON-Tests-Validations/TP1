using System;
using System.Collections.Generic;

namespace TP2
{
    public static class CalculateurCredit
    {
        public static double CalculerMensualite(Credit credit)
        {
            double tauxNominal = credit.TauxNominal / 12 / 100;
            double montant = credit.Montant;
            int duree = credit.Duree;
            double denominateur = Math.Pow(1 + tauxNominal, -duree);
            return montant * tauxNominal / (1 - denominateur);
        }

        public static List<Mensualite> CalculerMensualites(Credit credit)
        {
            double montant = credit.Montant;
            int duree = credit.Duree;
            double mensualite = CalculerMensualite(credit);
            double capitalRestantDu = montant + credit.CoutTotal;
            List<Mensualite> mensualites = new List<Mensualite>(duree);

            for (int i = 1; i <= duree; i++)
            {
                capitalRestantDu -= mensualite;
                double remboursementCapital = (montant + credit.CoutTotal) - capitalRestantDu;
                Mensualite mensualiteObj = new Mensualite(i, remboursementCapital, capitalRestantDu);
                mensualites.Add(mensualiteObj);
            }

            return mensualites;
        }

        public static double CalculerCoutTotal(Credit credit)
        {
            double montant = credit.Montant;
            int duree = credit.Duree;
            double mensualite = CalculerMensualite(credit);
            return mensualite * duree - montant;
        }
    }
}
