namespace CommandPattern.Core
{
    using CommandPattern.Core.Contracts;
    using System;
    using System.Linq;
    using System.Reflection;

    public class CommandInterpreter : ICommandInterpreter
    {
        public string Read(string args)
        {
            string[] tokens = args.Split();

            string cmdName = tokens[0];
            string[] cmdArgs = tokens.Skip(1).ToArray();

            Assembly assembly = Assembly.GetEntryAssembly();
            Type cmdType = assembly.GetTypes().FirstOrDefault(t => t.Name == $"{cmdName}Command" && t.GetInterfaces().Any(i => i == typeof(ICommand)));

            if (cmdType == null)
            {
                throw new InvalidOperationException($"Provided type {cmdName}Command does not exist or it does not implement ICommand interface!");
            }

            object commandInstance = Activator.CreateInstance(cmdType);
            MethodInfo executeMethod = cmdType.GetMethods().First(m => m.Name == "Execute");

            object result = executeMethod.Invoke(commandInstance, new object[] { cmdArgs });

            return (string)result;
        }
    }
}
