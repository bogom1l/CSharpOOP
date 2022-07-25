using CommandPattern.Core;
using CommandPattern.Core.Contracts;
using CommandPattern.Core.IO;
using CommandPattern.Core.IO.Contracts;
using System;

namespace CommandPattern
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            IReader reader = new ConsoleReader();
            IWriter writer = new ConsoleWriter();   

            ICommandInterpreter command = new CommandInterpreter();
            IEngine engine = new Engine(command, reader ,writer);
            engine.Run();
        }
    }
}
