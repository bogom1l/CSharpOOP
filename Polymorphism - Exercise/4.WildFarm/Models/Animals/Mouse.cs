namespace _4.WildFarm.Models.Animals
{
    using System;
    using System.Collections.Generic;
    using Food;
    public class Mouse : Mammal
    {
        public Mouse(string name, double weight, string livingRegion)
            : base(name, weight, livingRegion)
        {
        }

        protected override double WeightMultiplier
            => 0.10;

        protected override List<Type> PreferredFoods
            => new List<Type>()
            {
                typeof(Vegetable), typeof(Fruit)
            };

        public override string ProduceSound()
        {
            return "Squeak";
        }
        public override string ToString()
        {
            return base.ToString() + $"{Weight}, {LivingRegion}, {FoodEaten}]";
        }

    }
}
