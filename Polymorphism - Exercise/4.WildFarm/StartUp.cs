namespace _4.WildFarm
{
    using System;
    using System.Collections.Generic;
    using Models.Animals;
    using Models.Food;

    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Animal> animals = new List<Animal>();

            Animal animal = null;
            Food food = null;

            int cnt = 0;

            while (true)
            {
                try
                {
                    string input = Console.ReadLine();
                    if (input == "End")
                    {
                        break;
                    }

                    string[] tokens = input.Split();

                    if (cnt % 2 == 0) //animal
                    {
                        cnt++;
                        string typeAnimal = tokens[0];

                        string name = tokens[1];
                        double weight = double.Parse(tokens[2]);

                        if (typeAnimal == "Cat")
                        {
                            string livingRegion = tokens[3];
                            string breed = tokens[4];
                            animal = new Cat(name, weight, livingRegion, breed);
                        }
                        else if (typeAnimal == "Tiger")
                        {
                            string livingRegion = tokens[3];
                            string breed = tokens[4];
                            animal = new Tiger(name, weight, livingRegion, breed);
                        }
                        else if (typeAnimal == "Owl")
                        {
                            double wingSize = double.Parse(tokens[3]);
                            animal = new Owl(name, weight, wingSize);
                        }
                        else if (typeAnimal == "Hen")
                        {
                            double wingSize = double.Parse(tokens[3]);
                            animal = new Hen(name, weight, wingSize);
                        }
                        else if (typeAnimal == "Mouse")
                        {
                            string livingRegion = tokens[3];
                            animal = new Mouse(name, weight, livingRegion);
                        }
                        else if (typeAnimal == "Dog")
                        {
                            string livingRegion = tokens[3];
                            animal = new Dog(name, weight, livingRegion);
                        }

                        animals.Add(animal);

                    }
                    else if (cnt % 2 != 0) //food
                    {
                        cnt++;
                        string typeFood = tokens[0];
                        int quantity = int.Parse(tokens[1]);

                        if (typeFood == "Vegetable")
                        {
                            food = new Vegetable(quantity);
                        }
                        else if (typeFood == "Fruit")
                        {
                            food = new Fruit(quantity);
                        }
                        else if (typeFood == "Meat")
                        {
                            food = new Meat(quantity);
                        }
                        else if (typeFood == "Seeds")
                        {
                            food = new Seeds(quantity);
                        }


                        Console.WriteLine(animal.ProduceSound());
                        animal.EatFood(food);
                    }

                }
                catch (InvalidOperationException ioe)
                {
                    Console.WriteLine(ioe.Message);
                }
            }


            foreach (var a in animals)
            {
                Console.WriteLine(a);
            }

        }
    }
}
