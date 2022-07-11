using System;
using System.Collections.Generic;
using System.Linq;

namespace _4.BorderControl
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<IControlable> controlables = new List<IControlable>();

            while (true)
            {
                string command = Console.ReadLine();
                if (command == "End")
                {
                    break;
                }
                string[] tokens = command.Split();
            
                IControlable controlable = null;

                if (tokens.Length == 3)
                {
                    controlable = new Citizen(tokens[0], int.Parse(tokens[1]), tokens[2]);
                }
                else
                {
                    controlable = new Robot(tokens[0], tokens[1]);
                }

                controlables.Add(controlable);
            }

            string lastDigits = Console.ReadLine();


            foreach (var currControlable in controlables)
            {
                if (currControlable.Id.EndsWith(lastDigits))
                {
                    Console.WriteLine(currControlable.Id);
                }
            }


        }
    }
}
