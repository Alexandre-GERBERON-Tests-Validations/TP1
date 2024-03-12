using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MorpionApp
{
    public class Morpion : Game
    {
        public Morpion()
        {
            InitialiserGrille(3, 3);

        }

        public override void boucleJeu()
        {
            while (!quiterJeu)
            {
                while (!quiterJeu)
                {
                    if (tourDuJoueur)
                    {
                        tourJoueur();
                        if (verifVictoire(CellValue.X))
                        {
                            finPartie("Le joueur 1 a gagné !");
                            break;
                        }
                    }
                    else
                    {
                        tourJoueur();
                        if (verifVictoire(CellValue.O))
                        {
                            finPartie("Le joueur 2 a gagné !");
                            break;
                        }
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
                        // reinitialiser la grille
                        InitialiserGrille(3, 3);
                        Vue.EffacerConsole();
                    }
                }
            }
        }

        public new bool verifVictoire(CellValue c)
        {
            for (int i = 0; i < grille.GetRows(); i++)
            {
                if (grille.GetCell(i, 0).Value == c && grille.GetCell(i, 1).Value == c && grille.GetCell(i, 2).Value == c)
                {
                    return true;
                }
            }

            for (int j = 0; j < grille.GetColumns(); j++)
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
            for (int i = 0; i < grille.GetRows(); i++)
            {
                for (int j = 0; j < grille.GetColumns(); j++)
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
