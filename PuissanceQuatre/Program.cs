using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MorpionApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            Vue.AfficherMessage("Jouer à quel jeu ? Taper [X] pour le morpion et [P] pour le puissance 4.");
        GetKey:
            switch (Console.ReadKey(true).Key)
            {
                case ConsoleKey.X:
                    Game morpion = new Morpion();
                    morpion.boucleJeu();
                    break;
                case ConsoleKey.P:

                    Game puissanceQuatre = new PuissanceQuatre();
                    puissanceQuatre.boucleJeu();
                    break;
                default:
                    goto GetKey;
            }
        }
    }
}