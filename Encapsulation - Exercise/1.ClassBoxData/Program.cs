using System;

namespace _1.ClassBoxData
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            double len = double.Parse(Console.ReadLine());
            double wid = double.Parse(Console.ReadLine());
            double hei = double.Parse(Console.ReadLine());

            try
            {
                Box box = new Box(len, wid, hei);

                Console.WriteLine($"Surface Area - {box.SurfaceArea():F2}");
                Console.WriteLine($"Lateral Surface Area - {box.LataralSurfaceArea():F2}");
                Console.WriteLine($"Volume - {box.Volume():F2}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
    }
}
