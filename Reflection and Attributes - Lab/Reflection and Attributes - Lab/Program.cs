namespace Reflection_and_Attributes___Lab
{
    using System;
    using System.Reflection;

    public class Program
    {
        static void Main(string[] args)
        {

            Type personType = typeof(Person);

            FieldInfo fi = personType.GetField("test");



            Console.WriteLine();
        }
    }
}
