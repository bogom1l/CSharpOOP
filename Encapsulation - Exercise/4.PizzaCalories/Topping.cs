using System;
using System.Collections.Generic;
using System.Text;

namespace _4.PizzaCalories
{
    public class Topping
    {
        private const double BaseCaloriesPerGram = 2;

        private string type; //meat, veggies, cheese, sauce
        private double weight;

        public Topping(string type, double weight)
        {
            this.Type = type;
            this.Weight = weight;
        }

        public string Type 
        {
            get => this.type;
            private set
            {
                if (value.ToLower() != "meat" && value.ToLower() != "veggies" && value.ToLower() != "cheese" && value.ToLower() != "sauce")
                {
                    throw new Exception($"Cannot place {value} on top of your pizza.");
                }
                this.type = value;
            }
        }

        public double Weight
        {
            get => this.weight;
            private set
            {
                if (value < 1 || value > 50)
                {
                    throw new Exception($"{this.Type} weight should be in the range [1..50].");
                }
                this.weight = value;
            }
        }

        public double CalculateTotalCalories()  //meat, veggies, cheese, sauce
        {
            double modifier = BaseCaloriesPerGram;

            if (this.Type.ToLower() == "meat")
            {
                modifier *= 1.2;
            }
            else if(this.Type.ToLower() == "veggies")
            {
                modifier *= 0.8;
            }
            else if(this.Type.ToLower() == "cheese")
            {
                modifier *= 1.1;
            }
            else if(this.Type.ToLower() == "sauce")
            {
                modifier *= 0.9;
            }
            
            return modifier * this.Weight;
        }


    }
}
