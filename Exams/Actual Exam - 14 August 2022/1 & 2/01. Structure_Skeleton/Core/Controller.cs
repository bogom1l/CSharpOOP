namespace PlanetWars.Core
{
    using PlanetWars.Core.Contracts;
    using PlanetWars.Models.MilitaryUnits;
    using PlanetWars.Models.MilitaryUnits.Contracts;
    using PlanetWars.Models.Planets;
    using PlanetWars.Models.Planets.Contracts;
    using PlanetWars.Models.Weapons;
    using PlanetWars.Models.Weapons.Contracts;
    using PlanetWars.Repositories;

    using System;
    using System.Linq;
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
            if (this._planets.FindByName(name) != null)
            {
                return $"Planet {name} is already added!";
            }

            IPlanet planet = new Planet(name, budget);
            this._planets.AddItem(planet);

            return $"Successfully added Planet: {name}";
        }

        public string AddUnit(string unitTypeName, string planetName)
        {
            if (this._planets.FindByName(planetName) == null)
            {
                throw new InvalidOperationException($"Planet {planetName} does not exist!");
            }

            IPlanet planet = this._planets.FindByName(planetName);

            if (planet.Army.Any(x => x.GetType().Name == unitTypeName))
            {
                throw new InvalidOperationException($"{unitTypeName} already added to the Army of {planetName}!");
            }

            IMilitaryUnit unit;

            if (unitTypeName == nameof(AnonymousImpactUnit))
            {
                unit = new AnonymousImpactUnit();
            }
            else if (unitTypeName == nameof(SpaceForces))
            {
                unit = new SpaceForces();
            }
            else if (unitTypeName == nameof(StormTroopers))
            {
                unit = new StormTroopers();
            }
            else
            {
                throw new InvalidOperationException($"{unitTypeName} still not available!");
            }

            planet.Spend(unit.Cost);
            planet.AddUnit(unit);

            return $"{unitTypeName} added successfully to the Army of {planetName}!";
        }

        public string AddWeapon(string planetName, string weaponTypeName, int destructionLevel)
        {
            if (this._planets.FindByName(planetName) == null)
            {
                throw new InvalidOperationException($"Planet {planetName} does not exist!");
            }

            IPlanet planet = this._planets.FindByName(planetName);

            if (planet.Weapons.Any(x => x.GetType().Name == weaponTypeName))
            {
                throw new InvalidOperationException($"{weaponTypeName} already added to the Weapons of {planetName}!");
            }

            IWeapon weapon;

            if (weaponTypeName == nameof(BioChemicalWeapon))
            {
                weapon = new BioChemicalWeapon(destructionLevel);
            }
            else if (weaponTypeName == nameof(NuclearWeapon))
            {
                weapon = new NuclearWeapon(destructionLevel);
            }
            else if (weaponTypeName == nameof(SpaceMissiles))
            {
                weapon = new SpaceMissiles(destructionLevel);
            }
            else
            {
                throw new InvalidOperationException($"{weaponTypeName} still not available!");
            }

            planet.Spend(weapon.Price);
            planet.AddWeapon(weapon);

            return $"{planetName} purchased {weaponTypeName}!";
        }

        public string SpecializeForces(string planetName)
        {
            if (this._planets.FindByName(planetName) == null)
            {
                throw new InvalidOperationException($"Planet {planetName} does not exist!");
            }

            IPlanet planet = this._planets.FindByName(planetName);

            if (!planet.Army.Any())
            {
                throw new InvalidOperationException("No units available for upgrade!");
            }

            planet.Spend(1.25);
            planet.TrainArmy();

            return $"{planetName} has upgraded its forces!";
        }

        private bool DoesPlanetHaveNuclearWeapon(IPlanet planet) => planet.Weapons.Any(x => x is NuclearWeapon);

        public string SpaceCombat(string planetOneName, string planetTwoName)
        {
            IPlanet planetOne = this._planets.FindByName(planetOneName);
            IPlanet planetTwo = this._planets.FindByName(planetTwoName);

            string winnerName = string.Empty;

            if (planetOne.MilitaryPower > planetTwo.MilitaryPower)
            {
                winnerName = planetOneName;
            }
            else if (planetOne.MilitaryPower < planetTwo.MilitaryPower)
            {
                winnerName = planetTwoName;
            }
            else //same MilitaryPower
            {
                if (!DoesPlanetHaveNuclearWeapon(planetOne) && !DoesPlanetHaveNuclearWeapon(planetTwo)) //noone wins
                {
                    planetOne.Spend(planetOne.Budget / 2);
                    planetTwo.Spend(planetTwo.Budget / 2);

                    return "The only winners from the war are the ones who supply the bullets and the bandages!";
                }

                if (DoesPlanetHaveNuclearWeapon(planetOne) && DoesPlanetHaveNuclearWeapon(planetTwo)) //noone wins
                {
                    planetOne.Spend(planetOne.Budget / 2);
                    planetTwo.Spend(planetTwo.Budget / 2);

                    return "The only winners from the war are the ones who supply the bullets and the bandages!";
                }

                if (DoesPlanetHaveNuclearWeapon(planetOne) &&
                    !DoesPlanetHaveNuclearWeapon(planetTwo)) //planetOne has NuclearWeapon
                {
                    winnerName = planetOneName;
                }
                else //planetTwo has NuclearWeapon
                {
                    winnerName = planetTwoName;
                }

            }

            if (winnerName == planetOneName) //planetOne is winner
            {
                planetOne.Spend(planetOne.Budget / 2);
                planetOne.Profit(planetTwo.Budget / 2);

                double sum = planetTwo.Army.Sum(x => x.Cost) + planetTwo.Weapons.Sum(x => x.Price);
                planetOne.Profit(sum);

                this._planets.RemoveItem(planetTwoName);

                return $"{planetOneName} destructed {planetTwoName}!";
            }
            else //planetTwo is winner
            {
                planetTwo.Spend(planetTwo.Budget / 2);
                planetTwo.Profit(planetOne.Budget / 2);

                double sum = planetOne.Army.Sum(x => x.Cost) + planetOne.Weapons.Sum(x => x.Price);
                planetTwo.Profit(sum);

                this._planets.RemoveItem(planetOneName);

                return $"{planetTwoName} destructed {planetOneName}!";
            }

        }

        public string ForcesReport()
        {
            var sb = new StringBuilder();

            sb.AppendLine("***UNIVERSE PLANET MILITARY REPORT***");

            foreach (var planet in
                     this._planets.Models.OrderByDescending(x => x.MilitaryPower)
                         .ThenBy(x => x.Name))
            {
                sb.AppendLine(planet.PlanetInfo());
            }

            return sb.ToString().Trim();
        }
    }
}