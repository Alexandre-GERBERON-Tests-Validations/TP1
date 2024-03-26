using System;

namespace TP2
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Credit credit = InputHandler.HandleInput(args);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
