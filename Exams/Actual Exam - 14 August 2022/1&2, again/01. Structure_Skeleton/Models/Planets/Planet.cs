using PlanetWars.Models.MilitaryUnits;
using PlanetWars.Models.MilitaryUnits.Contracts;
using PlanetWars.Models.Planets.Contracts;
using PlanetWars.Models.Weapons;
using PlanetWars.Models.Weapons.Contracts;
using PlanetWars.Repositories;
using System.Linq;

namespace PlanetWars.Models.Planets
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Planet : IPlanet
    {
        private readonly UnitRepository _units;
        private readonly WeaponRepository _weapons;

        private string _name;
        private double _budget;

        public Planet(string name, double budget)
        {
            this.Name = name;
            this.Budget = budget;

            this._weapons = new WeaponRepository();
            this._units = new UnitRepository();
        }


        public string Name
        {
            get => this._name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Planet name cannot be null or empty.");
                }

                this._name = value;
            }
        }

        public double Budget
        {
            get => this._budget;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Budget's amount cannot be negative.");
                }

                this._budget = value;
            }
        }

        private double CalculateMilitaryPower()
        {
            double sum = this._units.Models.Sum(x => x.EnduranceLevel)
                         + this._weapons.Models.Sum(x => x.DestructionLevel);

            if (this._units.Models.ToList().Exists(x => x is AnonymousImpactUnit))
            {
                sum *= 1.30;
            }

            if (this._weapons.Models.ToList().Exists(x => x is NuclearWeapon))
            {
                sum *= 1.45;
            }

            return Math.Round(sum, 3);
        }

        public double MilitaryPower => CalculateMilitaryPower();

        public IReadOnlyCollection<IMilitaryUnit> Army => this._units.Models;

        public IReadOnlyCollection<IWeapon> Weapons => this._weapons.Models;

        public void AddUnit(IMilitaryUnit unit) => this._units.AddItem(unit);

        public void AddWeapon(IWeapon weapon) => this._weapons.AddItem(weapon);

        public void TrainArmy() => this.Army.ToList().ForEach(x => x.IncreaseEndurance());

        public void Spend(double amount)
        {
            if (this.Budget < amount)
            {
                throw new InvalidOperationException("Budget too low!");
            }

            this.Budget -= amount;
        }

        public void Profit(double amount) => this.Budget += amount;

        public string PlanetInfo()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"Planet: {this.Name}");
            sb.AppendLine($"--Budget: {this.Budget} billion QUID");

            if (this.Army.Any())
            {
                sb.AppendLine($"--Forces: {string.Join(", ", this.Army.Select(x => x.GetType().Name))}");
            }
            else
            {
                sb.AppendLine($"--Forces: No units");
            }

            if (this.Weapons.Any())
            {
                sb.AppendLine($"--Combat equipment: {string.Join(", ", this.Weapons.Select(x => x.GetType().Name))}");
            }
            else
            {
                sb.AppendLine($"--Combat equipment: No weapons");
            }

            sb.AppendLine($"--Military Power: {this.MilitaryPower}");

            return sb.ToString().Trim();
        }
    }
}
