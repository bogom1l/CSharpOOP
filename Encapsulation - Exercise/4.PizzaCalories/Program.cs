using System;

namespace _4.PizzaCalories
{
    public class StartUp
    {
        static void Main(string[] args)
        {

            string[] PizzaCommand = Console.ReadLine().Split();
            string pizzaName = PizzaCommand[1];

            string[] DoughCommand = Console.ReadLine().Split();
            string doughFlourType = DoughCommand[1];
            string doughBakingTechnique = DoughCommand[2];
            double doughWeight = double.Parse(DoughCommand[3]);

            Dough dought = new Dough(doughFlourType, doughBakingTechnique, doughWeight);
            Pizza pizza = new Pizza(pizzaName, dought);

            while (true)
            {
                string[] commandTopping = Console.ReadLine().Split();
                if (commandTopping[0] == "END")
                {
                    break;
                }

                string currType = commandTopping[1];
                double currWeight = double.Parse(commandTopping[2]);

                Topping currTopping = new Topping(currType, currWeight);

            }

            





        }
    }
}
