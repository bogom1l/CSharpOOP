using System;

namespace PizzaCalories
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            try
            {
                string command1 = Console.ReadLine();
                string[] tokensPizza = command1.Split();
                string pizzaName = tokensPizza[1];
                //Pizza pizza = new Pizza(tokensPizza[0]);

                string command2 = Console.ReadLine();
                string[] tokensDough = command2.Split();
                string currDoughFlourType = tokensDough[1];
                string currDoughBT = tokensDough[2];
                double currDoughWeight = double.Parse(tokensDough[3]);
                Dough dough = new Dough(currDoughFlourType, currDoughBT, currDoughWeight);

                Pizza pizza = new Pizza(pizzaName, dough);

                while (true)
                {
                    string inputTopping = Console.ReadLine();
                    if (inputTopping == "END")
                    {
                        break;
                    }

                    string[] tokens = inputTopping.Split();
                    string currType = tokens[1];
                    double currWeight = double.Parse(tokens[2]);
                    Topping currTopping = new Topping(currType, currWeight);

                    pizza.AddTopping(currTopping);

                }

                Console.WriteLine($"{pizza.Name} - {pizza.GetTotalCalories:f2} Calories.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
    }
}
