using PlanetWars.Models.Weapons.Contracts;

namespace PlanetWars.Models.Weapons
{
    using System;

    public abstract class Weapon : IWeapon
    {
        private int _destLvl;

        public Weapon(int destructionLevel, double price)
        {
            this.DestructionLevel = destructionLevel;
            this.Price = price;
        }

        public double Price { get; }

        public int DestructionLevel
        {
            get => this._destLvl;
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

                this._destLvl = value;
            }
        }

    }
}