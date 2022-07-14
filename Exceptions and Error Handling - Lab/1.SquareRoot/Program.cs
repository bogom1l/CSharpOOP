using System;

namespace _1.SquareRoot
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            double num = double.Parse(Console.ReadLine());

            try
            {
                if (num < 0)
                {
                    throw new Exception("Invalid number.");
                }
                Console.WriteLine(Math.Sqrt(num));
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine($"Goodbye.");
            }
        }
    }
}
