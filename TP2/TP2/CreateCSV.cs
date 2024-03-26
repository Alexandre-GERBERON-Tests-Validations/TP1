using System.IO;

namespace TP2
{
    public static class CreateCSV
    {
        public static void CreateFile(Credit credit, string path)
        {
            using (StreamWriter writer = new StreamWriter(path))
            {
                writer.WriteLine($"Coût total du crédit : {credit.CoutTotal}");
                writer.WriteLine("Numero;RemboursementCapital;RestantDu");
                foreach (Mensualite mensualite in credit.Mensualites)
                {
                    writer.WriteLine($"{mensualite.Numero};{mensualite.RemboursementCapital};{mensualite.RestantDu}");
                }
            }
        }
    }
}
