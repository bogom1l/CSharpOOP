namespace Heroes.Core
{
    using Heroes.Core.Contracts;
    using Heroes.Models.Contracts;
    using Heroes.Models.Heroes;
    using Heroes.Models.Map;
    using Heroes.Models.Weapons;
    using Heroes.Repositories;
    using Heroes.Utilities;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Controller : IController
    {
        private HeroRepository heroes;
        private WeaponRepository weapons;
        public Controller()
        {
            this.heroes = new HeroRepository();
            this.weapons = new WeaponRepository();
        }
        public string AddWeaponToHero(string weaponName, string heroName)
        {
            IHero hero = heroes.FindByName(heroName);
            IWeapon weapon = weapons.FindByName(weaponName);

            if (hero == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.HeroException, heroName));
            }
            if (weapon == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.WeaponException, weaponName));
            }
            if (hero.Weapon != null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.HeroArmed, heroName));
            }

            hero.AddWeapon(weapon);
            weapons.Remove(weapon);
            return string.Format(OutputMessages.HeroBattle, heroName, weapon.GetType().Name.ToLower());
        }

        public string CreateHero(string type, string name, int health, int armour)
        {
            IHero hero = null; 

            if (type == nameof(Knight))
            {
                hero = new Knight(name, health, armour);
                if (heroes.FindByName(name) == null)
                {
                    heroes.Add(hero);
                    return string.Format(OutputMessages.SuccessAddSir, name);
                }
                else
                {
                    throw new InvalidOperationException(string.Format(ExceptionMessages.HeroExists, name));
                }
            }
            else if (type == nameof(Barbarian))
            {
                hero = new Barbarian(name, health, armour);
                if (heroes.FindByName(name) == null)
                {
                    heroes.Add(hero);
                    return string.Format(OutputMessages.SuccessAddBar, name);
                }
                else
                {
                    throw new InvalidOperationException(string.Format(ExceptionMessages.HeroExists, name));
                }
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidHeroType);
            }

        }

        public string CreateWeapon(string type, string name, int durability)
        {
            IWeapon weapon = null;

            if (type == nameof(Mace))
            {
                if (weapons.FindByName(name) == null)
                {
                    weapon = new Mace(name, durability);
                    weapons.Add(weapon);
                    return string.Format(OutputMessages.WeaponAdd, type.ToLower(), name);
                }
                else
                {
                    throw new InvalidOperationException(string.Format(ExceptionMessages.WeaponExists, name));
                }
            }
            else if (type == nameof(Claymore))
            {
                if (weapons.FindByName(name) == null)
                {
                    weapon = new Claymore(name, durability);
                    weapons.Add(weapon);
                    return string.Format(OutputMessages.WeaponAdd, type.ToLower(), name);
                }
                else
                {
                    throw new InvalidOperationException(string.Format(ExceptionMessages.WeaponExists, name));
                }
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidWeaponType);
            }
        }

        public string HeroReport()
        {
            StringBuilder sb = new StringBuilder();

            foreach (IHero hero in heroes.Models.OrderBy(h => h.GetType().Name).ThenByDescending(h => h.Health).ThenBy(h => h.Name))
            {
                sb.AppendLine($"{hero.GetType().Name}: {hero.Name}");
                sb.AppendLine($"--Health: {hero.Health}");
                sb.AppendLine($"--Armour: {hero.Armour}");
                if (hero.Weapon == null)
                {
                    sb.AppendLine($"--Weapon: Unarmed");
                }
                else
                {
                    sb.AppendLine($"--Weapon: {hero.Weapon.Name}");
                }
            }

            return sb.ToString().TrimEnd();
        }

        public string StartBattle()
        {
            var map = new Map();
            return map.Fight((ICollection<IHero>)heroes.Models);
        }
    }
}
