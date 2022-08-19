using PlanetWars.Core.Contracts;
using PlanetWars.Models.MilitaryUnits;
using PlanetWars.Models.MilitaryUnits.Contracts;
using PlanetWars.Models.Planets;
using PlanetWars.Models.Planets.Contracts;
using PlanetWars.Models.Weapons;
using PlanetWars.Models.Weapons.Contracts;
using PlanetWars.Repositories;
using System.Linq;

namespace PlanetWars.Core
{
    using System;
    using System.Text;

    public class Controller : IController
    {
        private readonly PlanetRepository _planets;

        public Controller()
        {
            this._planets = new PlanetRepository();
        }

        public string CreatePlanet(string name, double budget)
        {
            if (this._planets.FindByName(name) == null)
            {
                IPlanet planet = new Planet(name, budget);
                this._planets.AddItem(planet);
                return $"Successfully added Planet: {name}";
            }

            return $"Planet {name} is already added!";
        }

        public string AddUnit(string unitTypeName, string planetName)
        {
            IPlanet planet = this._planets.FindByName(planetName);

            if (planet == null)
            {
                throw new InvalidOperationException($"Planet {planetName} does not exist!");
            }

            IMilitaryUnit militaryUnit;

            if (unitTypeName == nameof(AnonymousImpactUnit))
            {
                militaryUnit = new AnonymousImpactUnit();
            }
            else if (unitTypeName == nameof(SpaceForces))
            {
                militaryUnit = new SpaceForces();
            }
            else if (unitTypeName == nameof(StormTroopers))
            {
                militaryUnit = new StormTroopers();
            }
            else
            {
                throw new InvalidOperationException($"{unitTypeName} still not available!");
            }

            if (planet.Army.Any(x => x.GetType().Name == unitTypeName))
            {
                throw new InvalidOperationException($"{unitTypeName} already added to the Army of {planetName}!");
            }

            planet.Spend(militaryUnit.Cost);
            planet.AddUnit(militaryUnit);

            return $"{unitTypeName} added successfully to the Army of {planetName}!";
        }

        public string AddWeapon(string planetName, string weaponTypeName, int destructionLevel)
        {
            IPlanet planet = this._planets.FindByName(planetName);

            if (planet == null)
            {
                throw new InvalidOperationException($"Planet {planetName} does not exist!");
            }

            IWeapon weapon;

            if (weaponTypeName == nameof(SpaceMissiles))
            {
                weapon = new SpaceMissiles(destructionLevel);
            }
            else if (weaponTypeName == nameof(NuclearWeapon))
            {
                weapon = new NuclearWeapon(destructionLevel);
            }
            else if (weaponTypeName == nameof(BioChemicalWeapon))
            {
                weapon = new BioChemicalWeapon(destructionLevel);
            }
            else
            {
                throw new InvalidOperationException($"{weaponTypeName} still not available!");
            }

            if (planet.Weapons.Any(x => x.GetType().Name == weaponTypeName))
            {
                throw new InvalidOperationException($"{weaponTypeName} already added to the Weapons of {planetName}!");
            }

            planet.Spend(weapon.Price);
            planet.AddWeapon(weapon);

            return $"{planetName} purchased {weaponTypeName}!";
        }

        public string SpecializeForces(string planetName)
        {
            IPlanet planet = this._planets.FindByName(planetName);

            if (planet == null)
            {
                throw new InvalidOperationException($"Planet {planetName} does not exist!");
            }

            if (!planet.Army.Any())
            {
                throw new InvalidOperationException("No units available for upgrade!");
            }

            planet.Spend(1.25);
            planet.TrainArmy();

            return $"{planetName} has upgraded its forces!";
        }

        public string SpaceCombat(string planetOne, string planetTwo)
        {
            IPlanet winner;
            IPlanet looser;

            IPlanet attacker = this._planets.FindByName(planetOne);
            IPlanet defender = this._planets.FindByName(planetTwo);

            bool attackerHasNuclearWeapon = attacker.Weapons.Any(x => x is NuclearWeapon);
            bool defenderHasNuclearWeapon = defender.Weapons.Any(x => x is NuclearWeapon);



            if (attacker.MilitaryPower > defender.MilitaryPower)
            {
                winner = attacker;
                looser = defender;
            }
            else if (attacker.MilitaryPower < defender.MilitaryPower)
            {
                winner = defender;
                looser = attacker;
            }
            else //attacker.MilitaryPower == defender.MilitaryPower
            {
                if (attackerHasNuclearWeapon && defenderHasNuclearWeapon)
                {
                    attacker.Spend(attacker.Budget / 2);
                    defender.Spend(defender.Budget / 2);
                    return "The only winners from the war are the ones who supply the bullets and the bandages!";
                }

                if (!attackerHasNuclearWeapon && !defenderHasNuclearWeapon)
                {
                    attacker.Spend(attacker.Budget / 2);
                    defender.Spend(defender.Budget / 2);
                    return "The only winners from the war are the ones who supply the bullets and the bandages!";
                }

                if (attackerHasNuclearWeapon && !defenderHasNuclearWeapon)
                {
                    winner = attacker;
                    looser = defender;
                }
                else //  !attackerHasNuclearWeapon  &&  defenderHasNuclearWeapon
                {
                    winner = defender;
                    looser = attacker;
                }
            }

            if (winner == attacker)
            {
                attacker.Spend(attacker.Budget / 2);
                attacker.Profit(defender.Budget / 2);

                double sum = defender.Army.Sum(x => x.Cost) + defender.Weapons.Sum(x => x.Price);
                attacker.Profit(sum);

                this._planets.RemoveItem(planetTwo);
                return $"{attacker.Name} destructed {defender.Name}!";
            }
            else //winner == defender
            {
                defender.Spend(defender.Budget / 2);
                defender.Profit(attacker.Budget / 2);

                double sum = attacker.Army.Sum(x => x.Cost) + attacker.Weapons.Sum(x => x.Price);
                defender.Profit(sum);

                this._planets.RemoveItem(planetOne);
                return $"{defender.Name} destructed {attacker.Name}!";
            }

        }

        public string ForcesReport()
        {
            var sb = new StringBuilder();

            sb.AppendLine("***UNIVERSE PLANET MILITARY REPORT***");

            foreach (var planet in this._planets.Models.OrderByDescending(x => x.MilitaryPower).ThenBy(x => x.Name))
            {
                sb.AppendLine(planet.PlanetInfo());
            }

            return sb.ToString().Trim();
        }
    }
}
