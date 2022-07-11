using System;

namespace _9.ExplicitInterfaces
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            while (true)
            {
                string cmd = Console.ReadLine();
                if (cmd == "End")
                {
                    break;
                }

                string[] tokens = cmd.Split();
                string name = tokens[0];
                string country = tokens[1];
                int age = int.Parse(tokens[2]);
                
                IPerson person = new Citizen(name, country, age);
                IResident resident = new Citizen(name, country, age);

                Console.WriteLine(person.GetName());
                Console.WriteLine(resident.GetName());
            }
        }
    }
}
