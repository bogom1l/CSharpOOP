﻿namespace _4.WildFarm.Models.Animals
{
    using System;
    using System.Collections.Generic;
    using Food;

    public class Hen : Bird
    {
        public Hen(string name, double weight, double wingSize)
            : base(name, weight, wingSize)
        {
        }

        protected override double WeightMultiplier
            => 0.35;

        protected override List<Type> PreferredFoods
            => new List<Type>()
            {
                typeof(Vegetable), typeof(Fruit), typeof(Meat), typeof(Seeds)
            };

        public override string ProduceSound()
        {
            return "Cluck";
        }


    }
}
