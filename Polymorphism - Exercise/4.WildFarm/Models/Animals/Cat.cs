namespace _4.WildFarm.Models.Animals
{
    using System;
    using System.Collections.Generic;
    using Food;

    public class Cat : Feline
    {
        public Cat(string name, double weight, string livingRegion, string breed)
            : base(name, weight, livingRegion, breed)
        {
        }

        protected override List<Type> PreferredFoods => new List<Type>()
        {
            typeof(Vegetable), typeof(Meat)
        };

        protected override double WeightMultiplier
            => 0.30;

        public override string ProduceSound()
        {
            return "Meow";
        }
    }
}
