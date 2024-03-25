using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP2
{
    public static class CalculateurCredit
    {
        public static double CalculerMensualite(double montantEmprunte, int dureeEnMois, double tauxNominal)
        {
            double tauxMensuel = tauxNominal / 12 / 100;
            double mensualite = (montantEmprunte * tauxMensuel) / (1 - Math.Pow(1 + tauxMensuel, -dureeEnMois));
            return Math.Round(mensualite, 2);
        }
    }
}