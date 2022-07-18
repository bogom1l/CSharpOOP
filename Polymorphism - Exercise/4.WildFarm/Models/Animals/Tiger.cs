﻿namespace _4.WildFarm.Models.Animals
{
    using System;
    using System.Collections.Generic;
    using Food;
    public class Tiger : Feline
    {
        public Tiger(string name, double weight, string livingRegion, string breed)
            : base(name, weight, livingRegion, breed)
        {
        }

        protected override double WeightMultiplier
            => 1.00;

        protected override List<Type> PreferredFoods
            => new List<Type>()
            {
                typeof(Meat)
            };

        public override string ProduceSound()
        {
            return "ROAR!!!";
        }

    }
}
