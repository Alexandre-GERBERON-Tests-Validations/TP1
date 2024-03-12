using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MorpionApp
{
    internal class Joueur
    {
        public string Nom { get; set; }
        public CellValue Symbole { get; set; }

        public Joueur(string nom, CellValue symbole)
        {
            Nom = nom;
            Symbole = symbole;
        }

        public override string ToString()
        {
            return Nom;
        }
    }
}
