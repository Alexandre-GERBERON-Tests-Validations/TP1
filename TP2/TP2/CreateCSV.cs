using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TP2
{
    public static class CreateCSV
    {
        public static void GenererCSV(string cheminFichier, string[] donnees)
        {
            using (StreamWriter writer = new StreamWriter(cheminFichier))
            {
                foreach (var ligne in donnees)
                {
                    writer.WriteLine(ligne);
                }
            }
        }
    }
}
