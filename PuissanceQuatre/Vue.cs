using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MorpionApp
{
    internal class Vue
    {
        public static void AfficherPlateau(Cell[,] grille)
        {
            Console.WriteLine();
            for (int i = 0; i < grille.GetLength(0); i++)
            {
                for (int j = 0; j < grille.GetLength(1); j++)
                {
                    Console.Write($" {grille[i, j].ToString()} ");
                    if (j < grille.GetLength(1) - 1)
                    {
                        Console.Write("|");
                    }
                }
                Console.WriteLine();
                if (i < grille.GetLength(0) - 1)
                {
                    Console.WriteLine(new string('-', grille.GetLength(1) * 4 - 1));
                }
            }
        }

        public static void AfficherMessage(string message)
        {
            Console.WriteLine(message);
        }

        public static void EffacerConsole()
        {
            Console.Clear();
        }

        public static ConsoleKeyInfo LireTouche()
        {
            return Console.ReadKey(true);
        }

        public static void SetCursorPosition(int left, int top)
        {
            Console.SetCursorPosition(left, top);
        }
    }
}
