namespace _4.WildFarm.Models.Animals
{
    using System;
    using System.Collections.Generic;
    using Food;

    public abstract class Animal
    {
        public Animal(string name, double weight)
        {
            this.Name = name;
            this.Weight = weight;
        }
        public string Name { get; }
        public double Weight { get; private set; }
        public int FoodEaten { get; private set; }

        protected abstract double WeightMultiplier { get; }

        protected abstract List<Type> PreferredFoods { get; }

        public virtual void EatFood(Food food)
        {
            if (!PreferredFoods.Contains(food.GetType()))
            {
                throw new InvalidOperationException($"{GetType().Name} does not eat {food.GetType().Name}!");
            }
            FoodEaten += food.Quantity;
            Weight += food.Quantity * WeightMultiplier;
        }

        public abstract string ProduceSound();

        public override string ToString()
        {
            return $"{GetType().Name} [{Name}, ";
        }
    }
}
