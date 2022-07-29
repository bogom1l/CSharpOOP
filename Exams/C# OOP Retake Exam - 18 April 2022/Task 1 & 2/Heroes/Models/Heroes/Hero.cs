namespace Heroes.Models.Heroes
{
    using global::Heroes.Models.Contracts;
    using global::Heroes.Utilities;
    using System;

    public abstract class Hero : IHero
    {
        private string name;
        private int health;
        private int armour;
        private IWeapon weapon;

        protected Hero(string name, int health, int armour)
        {
            this.Name = name;
            this.Health = health;
            this.Armour = armour;
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.HeroNameNull);
                }
                this.name = value;
            }
        }

        public int Health
        {
            get => this.health;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.HeroHealth);
                }
                this.health = value;
            }
        }

        public int Armour
        {
            get => this.armour;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.HeroArmour);
                }
                this.armour = value;
            }
        }


        public IWeapon Weapon
        {
            get => this.weapon;
            private set
            {
                if (value == null)
                {
                    throw new ArgumentException(ExceptionMessages.WeaponNull);
                }
                this.AddWeapon(value);
            }
        }
        public bool IsAlive => this.Health > 0;

        public void AddWeapon(IWeapon weaponToAdd)
        {
            if (weaponToAdd == null)
            {
                throw new ArgumentException(ExceptionMessages.WeaponNull);
            }
            else if (this.Weapon != null)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.HeroArmed, this.Name));
            }
            this.weapon = weaponToAdd;
        }

        public void TakeDamage(int points)
        {
            if (this.Armour > points)
            {
                this.Armour -= points;
            }
            else if (this.Armour > 0)
            {
                points -= this.Armour;
                this.Armour = 0;
            }

            if (this.Health > points && this.Armour == 0)
            {
                this.Health -= points;
            }
            else if (this.Health <= points && this.Armour == 0)
            {
                this.Health = 0;
            }
        }
    }
}
