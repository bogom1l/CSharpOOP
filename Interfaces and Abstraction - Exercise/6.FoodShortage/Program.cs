using System;
using System.Collections.Generic;
using System.Linq;

namespace _6.FoodShortage
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<IBuyer> buyers = new List<IBuyer>();

            int N = int.Parse(Console.ReadLine());

            for (int i = 0; i < N; i++)
            {
                string command = Console.ReadLine();
                string[] tokens = command.Split();

                IBuyer buyer = null;

                if (tokens.Length == 4) //Citizen
                {
                    string name = tokens[0];
                    int age = int.Parse(tokens[1]);
                    string id = tokens[2];
                    string bd = tokens[3];

                    buyer = new Citizen(name, age, id, bd);
                }
                else // Rebel
                {
                    string name = tokens[0];
                    string id = tokens[1];
                    string group = tokens[2];

                    buyer = new Rebel(name, id, group);
                }

                buyers.Add(buyer);
            }

            while (true)
            {
                string cmd = Console.ReadLine();
                if (cmd == "End")
                {
                    break;
                }

                IBuyer currBuyer = buyers.FirstOrDefault(x => x.Name == cmd);

                if (currBuyer != null)
                {
                    currBuyer.BuyFood();
                }
            }

            Console.WriteLine(buyers.Sum(x => x.Food));
            
        }
    }
}
