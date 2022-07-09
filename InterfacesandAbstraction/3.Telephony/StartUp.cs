namespace Telephony
{
    using Telephony.Core;
    using Telephony.IO;
    using Telephony.IO.Interfaces;
    using System;
    public class StartUp
    {
        static void Main(string[] args)
        {
            IReader reader = new ConsoleReader();
            IWriter writer = new ConsoleWriter();

            IEngine engine = new Engine(reader, writer);

            engine.Start();

        }
    }
}
