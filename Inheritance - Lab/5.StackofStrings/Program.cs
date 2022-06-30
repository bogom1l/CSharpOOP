using System;
using System.Collections.Generic;
using System.Linq;

namespace CustomStack
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            StackOfStrings stack = new StackOfStrings();

            stack.Push("Cat");

            Console.WriteLine(stack.IsEmpty());
            Console.WriteLine();

            stack.Push("Dog");
            stack.Push("Butterfly");

            Console.WriteLine(stack.IsEmpty());
            Console.WriteLine();

            Stack<string> range = new Stack<string>();

            range.Push("A");
            range.Push("B");
            range.Push("C");

            Console.WriteLine(stack.IsEmpty());
            Console.WriteLine();

            stack.AddRange(range);

            while (stack.Count > 0)
            {
                Console.WriteLine(stack.Pop());
            }
        }
    }
}
