namespace SpaceStation.Models.Astronauts
{
    using SpaceStation.Models.Astronauts.Contracts;
    using SpaceStation.Models.Bags;
    using SpaceStation.Models.Bags.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public abstract class Astronaut : IAstronaut
    {
        private string name;
        private double oxygen;
        private readonly Backpack bag; //readonly?

        public Astronaut(string name, double oxygen)
        {
            this.Name = name;
            this.Oxygen = oxygen;
            this.bag = new Backpack();
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Astronaut name cannot be null or empty.");
                }
                this.name = value;
            }
        }

        public double Oxygen
        {
            get => this.oxygen;
            protected set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Cannot create Astronaut with negative oxygen!");
                }
                this.oxygen = value;
            }
        }

        public bool CanBreath { get => this.Oxygen > 0; } //protected set?

        public IBag Bag => this.bag;

        public virtual void Breath() 
        {
            this.Oxygen -= 10;
        }
    }
}
