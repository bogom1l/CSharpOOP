namespace AquaShop.Models.Aquariums
{
    using AquaShop.Models.Aquariums.Contracts;
    using AquaShop.Models.Decorations.Contracts;
    using AquaShop.Models.Fish.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public abstract class Aquarium : IAquarium
    {
        private string name;
        private int capacity;
        private readonly List<IDecoration> decorations;
        private readonly List<IFish> fish;

        public Aquarium(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.fish = new List<IFish>();
            this.decorations = new List<IDecoration>();
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Aquarium name cannot be null or empty.");
                }
                this.name = value;
            }
        }

        public int Capacity
        {
            get => this.capacity;
            private set
            {
                this.capacity = value;
            }
        }

        public ICollection<IDecoration> Decorations => this.decorations;

        public ICollection<IFish> Fish => this.fish;

        public int Comfort => this.Decorations.Sum(x => x.Comfort);

        public void AddDecoration(IDecoration decoration)
        {
            this.decorations.Add(decoration);
        }

        public void AddFish(IFish fish)
        {
            if (this.fish.Count >= this.Capacity) // ? => :)
            {
                throw new InvalidOperationException("Not enough capacity.");
            }

            this.fish.Add(fish);
        }

        public void Feed()
        {
            this.fish.ForEach(f => f.Eat());
        }

        public string GetInfo()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"{this.Name} ({this.GetType().Name}):"); // ? => :)
            if (this.fish.Any())
            {
                sb.AppendLine($"Fish: {string.Join(", ", this.fish.Select(f => f.Name))}");
            }
            else
            {
                sb.AppendLine($"Fish: none");
            }
            sb.AppendLine($"Decorations: {this.decorations.Count}");
            sb.AppendLine($"Comfort: {this.Comfort}");


            return sb.ToString().Trim();
        }

        public bool RemoveFish(IFish fish)
        {
           return this.fish.Remove(fish);
        }
    }
}
