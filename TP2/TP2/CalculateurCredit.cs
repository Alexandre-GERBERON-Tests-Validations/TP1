using System;
using System.Collections.Generic;

namespace TP2
{
    public static class CalculateurCredit
    {
        public static decimal CalculerMensualite(Credit credit)
        {
            decimal tauxMensuel = credit.TauxNominal / 12 / 100;
            decimal montant = credit.Montant;
            int duree = credit.Duree;
            decimal numerator = montant * tauxMensuel;
            decimal denominateur = 1 - (decimal)Math.Pow((double)(1 + tauxMensuel), -duree);
            return numerator / denominateur;
        }

        public static List<Mensualite> CalculerMensualites(Credit credit)
        {
            List<Mensualite> mensualites = new List<Mensualite>();
            decimal montant = credit.Montant;
            int duree = credit.Duree;
            decimal tauxNominal = credit.TauxNominal;
            decimal mensualite = CalculerMensualite(credit);
            decimal capitalRestantDu = montant;
            decimal capitalTotalRembourse = 0;
            for (int i = 1; i <= duree; i++)
            {
                decimal interetRembourse = capitalRestantDu * tauxNominal / 12 / 100;
                decimal capitalRembourse = mensualite - interetRembourse;
                capitalTotalRembourse += capitalRembourse;
                capitalRestantDu -= capitalRembourse;
                mensualites.Add(new Mensualite(i, interetRembourse, capitalRestantDu, capitalTotalRembourse, mensualite));
            }
            return mensualites; 
        }

        public static decimal CalculerCoutTotal(Credit credit)
        {
            decimal montant = credit.Montant;
            int duree = credit.Duree;
            decimal mensualite = CalculerMensualite(credit);
            return mensualite * duree - montant;
        }
    }
}
