namespace PlanetWars.Models.Weapons
{
    using PlanetWars.Models.Weapons.Contracts;

    using System;

    public abstract class Weapon : IWeapon
    {
        // Every Planet can possess only one Weapon from each type in it’s collection of weapons.

        private int _destructionLevel;

        protected Weapon(int destructionLevel, double price)
        {
            this.DestructionLevel = destructionLevel;
            this.Price = price;
        }

        public double Price { get; }

        public int DestructionLevel
        {
            get => this._destructionLevel;
            private set
            {
                if (value < 1)
                {
                    throw new ArgumentException("Destruction level cannot be zero or negative.");
                }

                if (value > 10)
                {
                    throw new ArgumentException("Destruction level cannot exceed 10 power points.");
                }

                this._destructionLevel = value;
            }
        }
    }
}