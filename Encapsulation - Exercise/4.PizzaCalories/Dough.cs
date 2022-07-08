using System;
using System.Collections.Generic;
using System.Text;

namespace _4.PizzaCalories
{
    public class Dough 
    {
        private const double BaseCaloriesPerGram = 2;

        private string flourType; //white, wholegrain
        private string bakingTechnique; //crispy, chewy, homemade
        private double weight;

        public Dough(string flourType, string bakingTechnique, double weight)
        {
            this.FlourType = flourType;
            this.BakingTechnique = bakingTechnique;
            this.Weight = weight;
        }

        public string FlourType  //.ToLower() to all values???
        {
            get => this.flourType;
            private set
            {
                if (value != "White" && value != "Wholegrain")
                {
                    throw new Exception("Invalid type of dough.");
                }
                this.flourType = value;
            }
        }
        public string BakingTechnique 
        {
            get => this.bakingTechnique; 
            private set
            {
                if (value != "Crispy" && value != "Chewy" && value != "Homemade")
                {
                    throw new Exception("Invalid type of dough.");
                }
                this.bakingTechnique = value;
            }
        }
        public double Weight
        {
            get => this.weight;
            private set
            {
                if (value < 1 || value > 200)
                {
                    throw new Exception("Dough weight should be in the range [1..200].");
                }
                this.weight = value;
            }
        }
        public double CalculateTotalCalories()
        {
            double modifier = BaseCaloriesPerGram;

            if (this.FlourType == "White")
            {
                modifier *= 1.5;
            }
            else if(this.FlourType == "Wholegrain")
            {
                modifier *= 1.0;
            }

            if (this.bakingTechnique == "Crispy")
            {
                modifier *= 0.9;
            }
            else if (this.bakingTechnique == "Chewy")
            {
                modifier *= 1.1;
            }
            else if (this.bakingTechnique == "Homemade")
            {
                modifier *= 1.0;
            }

            return modifier * this.Weight;
        }

        
    }
}
