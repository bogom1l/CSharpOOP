namespace CommandPattern.Core.IO
{
    using CommandPattern.Core.IO.Contracts;
    using System;

    public class ConsoleReader : IReader
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
