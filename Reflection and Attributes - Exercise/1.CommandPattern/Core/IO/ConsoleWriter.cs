namespace CommandPattern.Core.IO
{
    using CommandPattern.Core.IO.Contracts;
    using System;

    public class ConsoleWriter : IWriter
    {
        public void Write(string value)
        {
            Console.WriteLine(value);
        }

        public void WriteLine(string value)
        {
            Console.WriteLine(value);
        }
    }
}
