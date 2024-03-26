using System;

namespace TP2
{
    public class InputHandler
    {
        private const double MONTANT_MIN = 50000;
        private const int DUREE_MIN = 9 * 12;
        private const int DUREE_MAX = 25 * 12;

        public static Credit HandleInput(string[] args)
        {
            if (args.Length != 3)
            {
                throw new ArgumentException("Il faut 3 arguments : montant, durée et taux nominal");
            }

            if (!double.TryParse(args[0], out double montant) || montant < MONTANT_MIN)
            {
                throw new ArgumentException("Le montant doit être un nombre supérieur à 50 000 euros");
            }

            if (!int.TryParse(args[1], out int duree) || duree < DUREE_MIN || duree > DUREE_MAX)
            {
                throw new ArgumentException("La durée doit être un nombre entier compris entre 9 et 25 ans");
            }

            if (!double.TryParse(args[2], out double tauxNominal))
            {
                throw new ArgumentException("Le taux nominal doit être un nombre");
            }

            return new Credit(montant, duree, tauxNominal);
        }
    }
}
