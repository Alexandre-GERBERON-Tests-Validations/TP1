namespace TP2
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                Credit credit = InputHandler.HandleInput(args);
                string csvPath = "credit.csv";
                CreateCSV.CreateFile(credit, csvPath);
                Console.WriteLine("Le fichier CSV a été créé avec succès.");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
