using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MorpionApp
{
    public class PuissanceQuatre : Game
    {

        public PuissanceQuatre()
        {
            InitialiserGrille(6, 7);
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
                        InitialiserGrille(6, 7);
                        Vue.EffacerConsole();
                    }
                }
            }
        }

        public new bool verifVictoire(CellValue c)
        {
            for (int i = 0; i < grille.GetRows(); i++)
            {
                for (int j = 0; j < grille.GetColumns() - 3; j++)
                {
                    if (grille.GetCell(i, j).Value == c && grille.GetCell(i, j + 1).Value == c && grille.GetCell(i, j + 2).Value == c && grille.GetCell(i, j + 3).Value == c)
                    {
                        return true;
                    }
                }
            }

            for (int i = 0; i < grille.GetRows() - 3; i++)
            {
                for (int j = 0; j < grille.GetColumns(); j++)
                {
                    if (grille.GetCell(i, j).Value == c && grille.GetCell(i + 1, j).Value == c && grille.GetCell(i + 2, j).Value == c && grille.GetCell(i + 3, j).Value == c)
                    {
                        return true;
                    }
                }
            }

            for (int i = 0; i < grille.GetRows() - 3; i++)
            {
                for (int j = 0; j < grille.GetColumns() - 3; j++)
                {
                    if (grille.GetCell(i, j).Value == c && grille.GetCell(i + 1, j + 1).Value == c && grille.GetCell(i + 2, j + 2).Value == c && grille.GetCell(i + 3, j + 3).Value == c)
                    {
                        return true;
                    }
                }
            }

            for (int i = 0; i < grille.GetRows() - 3; i++)
            {
                for (int j = 3; j < grille.GetColumns(); j++)
                {
                    if (grille.GetCell(i, j).Value == c && grille.GetCell(i + 1, j - 1).Value == c && grille.GetCell(i + 2, j - 2).Value == c && grille.GetCell(i + 3, j - 3).Value == c)
                    {
                        return true;
                    }
                }
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

        public override void tourJoueur()
        {
            var column = 0;
            bool moved = false;

            while (!quiterJeu && !moved)
            {
                Vue.EffacerConsole();
                Vue.AfficherPlateau(grille.GetGrid());
                Vue.AfficherMessage("");
                Vue.AfficherMessage("Choisir une colonne valide et appuyer sur [Entrer]");
                // mettre le curseur à la bonne position
                Vue.SetCursorPosition(column * 4 + 2, 0);

                switch (Vue.LireTouche().Key)
                {
                    case ConsoleKey.Escape:
                        quiterJeu = true;
                        Vue.EffacerConsole();
                        break;

                    case ConsoleKey.RightArrow:
                        if (column >= grille.GetColumns() - 1)
                        {
                            column = 0;
                        }
                        else
                        {
                            column = column + 1;
                        }
                        break;

                    case ConsoleKey.LeftArrow:
                        if (column <= 0)
                        {
                            column = grille.GetColumns() - 1;
                        }
                        else
                        {
                            column = column - 1;
                        }
                        break;

                    case ConsoleKey.Enter:
                        for (int i = grille.GetRows() - 1; i >= 0; i--)
                        {
                            if (grille.GetCell(i, column).Value == CellValue.Empty)
                            {
                                if (tourDuJoueur)
                                {
                                    grille.GetCell(i, column).Value = CellValue.X;
                                }
                                else
                                {
                                    grille.GetCell(i, column).Value = CellValue.O;
                                }
                                moved = true;
                                break;
                            }
                        }
                        break;
                }
            }
        }

    }
}
