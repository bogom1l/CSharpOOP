using System;
using System.Collections.Generic;
using System.Linq;

namespace _3.ShoppingSpree
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Person> persons = new List<Person>();
            List<Product> products = new List<Product>();

            string[] firstInputPERSONS = Console.ReadLine().Split(';', StringSplitOptions.RemoveEmptyEntries);
            string[] secondInputPRODUCTS = Console.ReadLine().Split(';', StringSplitOptions.RemoveEmptyEntries);

            try
            {
                foreach (var item in firstInputPERSONS)
                {
                    string[] tokens = item.Split('=', StringSplitOptions.RemoveEmptyEntries);
                    string currName = tokens[0];
                    decimal currMoney = decimal.Parse(tokens[1]);

                    Person currPerson = new Person(currName, currMoney);
                    persons.Add(currPerson);
                }

                foreach (var item in secondInputPRODUCTS)
                {
                    string[] tokens = item.Split('=', StringSplitOptions.RemoveEmptyEntries);
                    string currName = tokens[0];
                    decimal currCost = decimal.Parse(tokens[1]);

                    Product currProduct = new Product(currName, currCost);
                    products.Add(currProduct);
                }

                while (true)
                {
                    string command = Console.ReadLine();
                    if (command == "END")
                    {
                        break;
                    }

                    string[] tokens = command.Split(" ");
                    string personName = tokens[0];
                    string productName = tokens[1];

                    Person currPerson = persons.FirstOrDefault(p => p.Name == personName);
                    Product currProduct = products.FirstOrDefault(p => p.Name == productName);

                    if (currPerson != null && currProduct != null)
                    {
                        if (currPerson.Money >= currProduct.Cost)
                        {
                            Console.WriteLine($"{currPerson.Name} bought {currProduct.Name}");
                            currPerson.Money -= currProduct.Cost;

                            currPerson.AddProduct(currProduct);
                        }
                        else
                        {
                            Console.WriteLine($"{currPerson.Name} can't afford {currProduct.Name}");
                        }
                    }
                }

                foreach (var p in persons)
                {
                    if (p.Products.Count > 0)
                    {
                        Console.WriteLine($"{p.Name} - {string.Join(", ", p.Products.Select(p => p.Name))}");
                    }
                    else
                    {
                        Console.WriteLine($"{p.Name} - Nothing bought");
                    }
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }
    }
}
