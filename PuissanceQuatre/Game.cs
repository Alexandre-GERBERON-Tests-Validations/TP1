using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MorpionApp
{
    abstract public class Game
    {
        public bool quiterJeu = false;
        public bool tourDuJoueur = true;
        public Grid? grille;

        public abstract void boucleJeu();

        public void InitialiserGrille(int rows, int columns)
        {
            grille = new Grid(rows, columns);
        }


        public virtual void tourJoueur()
        {
            var (row, column) = (0, 0);
            bool moved = false;

            while (!quiterJeu && !moved)
            {
                Vue.EffacerConsole();
                Vue.AfficherPlateau(grille.GetGrid());
                Vue.AfficherMessage("");
                Vue.AfficherMessage("Choisir une case valide est appuyer sur [Entrer]");
                // put cursor position at the right place
                Console.SetCursorPosition(column * 4 + 1, row * 2 + 1);

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

                    case ConsoleKey.UpArrow:
                        if (row <= 0)
                        {
                            row = grille.GetRows() - 1;
                        }
                        else
                        {
                            row = row - 1;
                        }
                        break;

                    case ConsoleKey.DownArrow:
                        if (row >= grille.GetRows() - 1)
                        {
                            row = 0;
                        }
                        else
                        {
                            row = row + 1;
                        }
                        break;
                    case ConsoleKey.Enter:
                        if (grille.GetCell(row, column).Value == CellValue.Empty)
                        {
                            grille.GetCell(row, column).Value = tourDuJoueur ? CellValue.X : CellValue.O;
                            moved = true;
                            quiterJeu = false;
                        }
                        break;
                }

            }
        }

        public bool verifVictoire(CellValue c)
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

        public bool verifEgalite()
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

        public void finPartie(string msg)
        {
            Vue.EffacerConsole();
            Vue.AfficherPlateau(grille.GetGrid());
            Vue.AfficherMessage(msg);
        }
    }
}
