namespace _4.WildFarm.Models.Animals
{
    using System;
    using System.Collections.Generic;
    using Food;
    public class Dog : Mammal
    {
        public Dog(string name, double weight, string livingRegion)
            : base(name, weight, livingRegion)
        {
        }

        protected override double WeightMultiplier
            => 0.40;

        protected override List<Type> PreferredFoods
            => new List<Type>()
            {
                typeof(Meat)
            };

        public override string ProduceSound()
        {
            return "Woof!";
        }

        public override string ToString()
        {
            return base.ToString() + $"{Weight}, {LivingRegion}, {FoodEaten}]";
        }
    }
}
