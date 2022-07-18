namespace _4.WildFarm.Models.Animals
{
    using System;
    using System.Collections.Generic;
    using Food;

    public class Owl : Bird
    {
        public Owl(string name, double weight, double wingSize)
            : base(name, weight, wingSize)
        {
        }

        protected override double WeightMultiplier
            => 0.25;

        protected override List<Type> PreferredFoods
            => new List<Type>()
        {
            typeof(Meat)
        };

        public override string ProduceSound()
        {
            return "Hoot Hoot";
        }
    }
}
