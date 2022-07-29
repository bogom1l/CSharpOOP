namespace Heroes.Utilities
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class ExceptionMessages
    {
        public const string HeroNameNull = "Hero name cannot be null or empty.";
        public const string HeroHealth = "Hero health cannot be below 0.";
        public const string HeroArmour = "Hero armour cannot be below 0.";

        public const string WeaponNull = "Weapon cannot be null.";
        public const string WeaponNullEmpty = "Weapon type cannot be null or empty.";
        public const string Durability = "Durability cannot be below 0.";

        public const string HeroException = "Hero {0} does not exist.";
        public const string WeaponException = "Weapon {0} does not exist.";
        public const string HeroArmed = "Hero {0} is well-armed.";

        public const string HeroExists = "The hero {0} already exists.";
        public const string InvalidHeroType = "Invalid hero type.";

        public const string WeaponExists = "The weapon {0} already exists.";
        public const string InvalidWeaponType = "Invalid weapon type.";
    }
}
