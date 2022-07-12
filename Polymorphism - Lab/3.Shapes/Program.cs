using System;

namespace Shapes
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Shape circle = new Circle(11);

            Console.WriteLine(circle.CalculatePerimeter());
            Console.WriteLine(circle.CalculateArea());
            Console.WriteLine(circle.Draw());

            Shape rectangle = new Rectangle(2, 6);

            Console.WriteLine(rectangle.CalculatePerimeter());
            Console.WriteLine(rectangle.CalculateArea());
            Console.WriteLine(rectangle.Draw());

        }
    }
}
