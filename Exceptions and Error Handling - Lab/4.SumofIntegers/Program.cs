using System;

namespace _4.SumofIntegers
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] values = Console.ReadLine().Split();
            int sum = 0;

            foreach (var element in values)
            {
                int numberToOut;

                bool success = int.TryParse(element, out numberToOut);
                try
                {
                    if (int.MaxValue <= int.Parse(element) || int.Parse(element) < int.MinValue)
                    {
                        throw new OverflowException();
                    }

                    if (success)
                    {
                        sum += numberToOut;
                    }
                    else
                    {
                        throw new FormatException();
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine($"The element '{element}' is in wrong format!");
                }
                catch (OverflowException)
                {
                    Console.WriteLine($"The element '{element}' is out of range!");
                }
                finally
                {
                    Console.WriteLine($"Element '{element}' processed - current sum: {sum}");
                }
            }

            Console.WriteLine($"The total sum of all integers is: {sum}");
        }
    }
}
