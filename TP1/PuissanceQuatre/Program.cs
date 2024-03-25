using System;

namespace MorpionApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            Vue.AfficherMessage("Jouer à quel jeu ? Taper [X] pour le morpion et [P] pour le puissance 4.");

            while (true)
            {
                ConsoleKey key = Vue.LireTouche().Key;

                if (key == ConsoleKey.X)
                {
                    Game morpion = new Morpion();
                    morpion.boucleJeu();
                    break;
                }
                else if (key == ConsoleKey.P)
                {
                    Game puissanceQuatre = new PuissanceQuatre();
                    puissanceQuatre.boucleJeu();
                    break;
                }
            }
        }
    }
}
