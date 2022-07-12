using System;

namespace Animals
{
    public class Animal
    {
        public string Name { get; protected set; }
        public string FavFood { get; protected set; }

        public Animal(string name, string favFood)
        {
            this.Name = name;
            this.FavFood = favFood;
        }

        public virtual string ExplainSelf()
        {
            return $"I am {this.Name} and my fovourite food is {this.FavFood}";
        }
    }
}