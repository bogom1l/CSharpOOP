using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{
    public class Dough
    {
        private const int BaseCaloriesPerGram = 2;

        private List<string> AllValidFlourTypes = new List<string>()
        {
            "white", "wholegrain"
        };

        private List<string> AllValidBakingTechniques = new List<string>()
        {
            "crispy", "chewy", "homemade"
        };

        private string flourType; //white or wholegrain
        private string bakingTechnique; // crispy, chewy, or homemade
        private double weight;

        public Dough(string flourType, string bakingTechnique, double weight)
        {
            this.FlourType = flourType;
            this.BakingTechnique = bakingTechnique;
            this.Weight = weight;
        }

        public string FlourType
        {
            get => this.flourType;
            private set
            {
                if (!AllValidFlourTypes.Contains(value.ToLower()))
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
                if (!AllValidBakingTechniques.Contains(value.ToLower()))
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

        private double CalculateCalories()
        {
            double modifier = BaseCaloriesPerGram;

            if (this.FlourType.ToLower() == "white") 
            {
                modifier *= 1.5;
            }
            else if(this.FlourType.ToLower() == "wholegrain")
            {
                modifier *= 1.0;
            }
            
            if(this.BakingTechnique.ToLower() == "crispy")
            {
                modifier *= 0.9;
            }
            else if(this.BakingTechnique.ToLower() == "chewy")
            {
                modifier *= 1.1;
            }
            else if(this.BakingTechnique.ToLower() == "homemade")
            {
                modifier *= 1.0;
            }

            return modifier * this.Weight; //(modifier = calories per Gram => this.Weight * modifier = total calories) ;
        }

        public double GetCalories => this.CalculateCalories();


    }
}
