using System;
using System.Collections.Generic;
using System.Linq; 

namespace _5.BirthdayCelebrations
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<IBirthable> birthables = new List<IBirthable>();

            while (true)
            {
                string command = Console.ReadLine();
                if (command == "End")
                {
                    break;
                }
                string[] tokens = command.Split();

                if (tokens[0] == "Citizen")
                {
                    IBirthable birthable = new Citizen(tokens[1], int.Parse(tokens[2]), tokens[3], tokens[4]);
                    birthables.Add(birthable);
                }
                else if (tokens[0] == "Pet")
                {
                    IBirthable birthable = new Pet(tokens[1], tokens[2]);
                    birthables.Add(birthable);
                }
                
            }

            string yearToFind = Console.ReadLine();


            foreach (var b in birthables)
            {
                if (b.Birthdate.EndsWith(yearToFind))
                {
                    Console.WriteLine(b.Birthdate);
                }
            }


        }
    }
}
