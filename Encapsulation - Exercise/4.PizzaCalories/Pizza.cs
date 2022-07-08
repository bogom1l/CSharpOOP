using System;
using System.Collections.Generic;
using System.Text;

namespace _4.PizzaCalories
{
    public class Pizza
    {
        private string name;
        private int numberOfToppings;
        private Dough pizzaDough;
        private readonly List<Topping> pizzaToppings;

        public Pizza(string name, Dough dough)
        {
            this.Name = name;
            this.pizzaDough = dough;
            this.pizzaToppings = new List<Topping>();
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length <= 15)
                {
                    throw new Exception("Pizza name should be between 1 and 15 symbols.");
                }
                this.name = value;
            }
        }

        public int NumberOfToppings 
        {
            get => this.numberOfToppings;
            private set
            {
                if (value < 0 || value > 10)
                {
                    Console.WriteLine("Number of toppings should be in range [0..10].");
                }
                this.numberOfToppings = value;
            }
        }

        public int TotalCalories =>
            1;

        public void AddTopping(Topping topping)
        {
            this.pizzaToppings.Add(topping);
        }

    }
}
