using System.IO;

namespace TP2
{
    public static class CreateCSV
    {
        public static void CreateFile(Credit credit, string path)
        {
            using (StreamWriter writer = new StreamWriter(path))
            {
                writer.WriteLine($"Coût total du crédit : {Math.Round(credit.CoutTotal, 2, MidpointRounding.ToZero)}");
                writer.WriteLine("Numero;interetRembourse;CapitalRestantDu;CapitalTotalRembourse;Mensualite");
                foreach (Mensualite mensualite in credit.Mensualites)
                {
                    writer.WriteLine($"{mensualite.Numero};" +
                        $"{Math.Round(mensualite.InteretRembourse, 2, MidpointRounding.ToZero)};" +
                        $"{Math.Round(mensualite.CapitalRestantDu, 2, MidpointRounding.ToZero)};" +
                        $"{Math.Round(mensualite.CapitalTotalRembourse, 2, MidpointRounding.ToZero)};" +
                        $"{Math.Round(mensualite.CoutMensualite, 2, MidpointRounding.ToZero)}");
                }
            }
        }
    }
}
