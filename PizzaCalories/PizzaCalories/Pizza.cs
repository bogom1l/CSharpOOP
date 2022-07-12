using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{
    public class Pizza
    {
        private string name;
        private List<Topping> toppings;
        private Dough dough;

        public Pizza(string name)
        {
            this.Name = name;
            this.toppings = new List<Topping>();
        }

        public Pizza(string n, Dough d)
        {
            this.Name = n;
            this.dough = d;
            this.toppings = new List<Topping>();
        }

        public string Name 
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length > 15)
                {
                    throw new Exception("Pizza name should be between 1 and 15 symbols.");
                }
                this.name = value;
            }
        }

        public int NumberOfToppings { get; set; }

        public void AddTopping(Topping topping)
        {
            if (this.NumberOfToppings > 10)
            {
                throw new Exception("Number of toppings should be in range [0..10].");
            }
            this.toppings.Add(topping);
            this.NumberOfToppings = toppings.Count;
        }

        private double CalculateTotalCalories()
        {
            double sum = 0.0;

            foreach (Topping t in toppings)
            {
                sum += t.GetCalories;
            }

            sum += this.dough.GetCalories;

            return sum;
        }

        public double GetTotalCalories => this.CalculateTotalCalories();


    }
}
