using System;

namespace MorpionApp
{
    public class Morpion : Game
    {
        private const int Rows = 3;
        private const int Columns = 3;

        public Morpion()
        {
            InitialiserGrille(Rows, Columns);
        }

        public override void boucleJeu()
        {
            while (!quiterJeu)
            {
                while (!quiterJeu)
                {
                    tourJoueur();

                    if (tourDuJoueur && verifVictoire(CellValue.X))
                    {
                        finPartie("Le joueur 1 a gagné !");
                        break;
                    }
                    else if (!tourDuJoueur && verifVictoire(CellValue.O))
                    {
                        finPartie("Le joueur 2 a gagné !");
                        break;
                    }

                    tourDuJoueur = !tourDuJoueur;

                    if (verifEgalite())
                    {
                        finPartie("Aucun vainqueur, la partie se termine sur une égalité.");
                        break;
                    }
                }

                if (!quiterJeu)
                {
                    Vue.AfficherMessage("Appuyez sur [Echap] pour quitter, [Entrer] pour rejouer.");
                    ConsoleKeyInfo key = Vue.LireTouche();

                    if (key.Key == ConsoleKey.Escape)
                    {
                        quiterJeu = true;
                        Vue.EffacerConsole();
                    }
                    else if (key.Key == ConsoleKey.Enter)
                    {
                        InitialiserGrille(Rows, Columns);
                        Vue.EffacerConsole();
                    }
                }
            }
        }

        public new bool verifVictoire(CellValue c)
        {
            for (int i = 0; i < Rows; i++)
            {
                if (grille.GetCell(i, 0).Value == c && grille.GetCell(i, 1).Value == c && grille.GetCell(i, 2).Value == c)
                {
                    return true;
                }
            }

            for (int j = 0; j < Columns; j++)
            {
                if (grille.GetCell(0, j).Value == c && grille.GetCell(1, j).Value == c && grille.GetCell(2, j).Value == c)
                {
                    return true;
                }
            }

            if (grille.GetCell(0, 0).Value == c && grille.GetCell(1, 1).Value == c && grille.GetCell(2, 2).Value == c)
            {
                return true;
            }

            if (grille.GetCell(0, 2).Value == c && grille.GetCell(1, 1).Value == c && grille.GetCell(2, 0).Value == c)
            {
                return true;
            }

            return false;
        }

        public new bool verifEgalite()
        {
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    if (grille.GetCell(i, j).Value == CellValue.Empty)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
