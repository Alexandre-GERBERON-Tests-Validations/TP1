namespace MorpionApp
{
    internal class Joueur
    {
        public string Nom { get; }
        public CellValue Symbole { get; }

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
