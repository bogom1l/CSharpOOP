namespace SpaceStation.Core
{
    using SpaceStation.Core.Contracts;
    using SpaceStation.Models.Astronauts;
    using SpaceStation.Models.Astronauts.Contracts;
    using SpaceStation.Models.Mission;
    using SpaceStation.Models.Mission.Contracts;
    using SpaceStation.Models.Planets;
    using SpaceStation.Models.Planets.Contracts;
    using SpaceStation.Repositories;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Controller : IController
    {
        private readonly AstronautRepository _astronautRepository;
        private readonly PlanetRepository _planetRepository;
        private int exploredPlanetsCount;

        public Controller()
        {
            this._astronautRepository = new AstronautRepository();
            this._planetRepository = new PlanetRepository();
            this.exploredPlanetsCount = 0;
        }

        public string AddAstronaut(string type, string astronautName)
        {
            IAstronaut astronaut;

            if (type == nameof(Biologist))
            {
                astronaut = new Biologist(astronautName);
            }
            else if (type == nameof(Geodesist))
            {
                astronaut = new Geodesist(astronautName);
            }
            else if (type == nameof(Meteorologist))
            {
                astronaut = new Meteorologist(astronautName);
            }
            else
            {
                throw new InvalidOperationException("Astronaut type doesn't exists!");
            }

            this._astronautRepository.Add(astronaut);
            return $"Successfully added {type}: {astronautName}!";
        }

        public string AddPlanet(string planetName, params string[] items)
        {
            IPlanet planet = new Planet(planetName);

            foreach (var item in items)
            {
                planet.Items.Add(item);
            }

            this._planetRepository.Add(planet);
            return $"Successfully added Planet: {planetName}!";
        }

        public string RetireAstronaut(string astronautName)
        {
            IAstronaut astronaut = this._astronautRepository.FindByName(astronautName);

            if (astronaut == null)
            {
                throw new InvalidOperationException($"Astronaut {astronautName} doesn't exists!");
            }

            this._astronautRepository.Remove(astronaut);
            return $"Astronaut {astronautName} was retired!";
        }

        public string ExplorePlanet(string planetName)
        {
            IPlanet planet = this._planetRepository.FindByName(planetName);
            IMission misson = new Mission();

            List<IAstronaut> astronautsToSendForMission = new List<IAstronaut>();

            foreach (var astronaut in this._astronautRepository.Models)
            {
                if (astronaut.Oxygen > 60)
                {
                    astronautsToSendForMission.Add(astronaut);
                }
            }

            if (!astronautsToSendForMission.Any())
            {
                throw new InvalidOperationException("You need at least one astronaut to explore the planet");
            }

            int astronautsSentToMissionCount = astronautsToSendForMission.Count;

            misson.Explore(planet, astronautsToSendForMission);
            this.exploredPlanetsCount++;

            List<IAstronaut> deadAstronautsList = astronautsToSendForMission.Where(x => !x.CanBreath).ToList();
            int deadAstronauts = deadAstronautsList.Count;

            return $"Planet: {planetName} was explored! Exploration finished with {deadAstronauts} dead astronauts!";
        }

        public string Report()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"{this.exploredPlanetsCount} planets were explored!");
            sb.AppendLine("Astronauts info:");

            foreach (var astronaut in this._astronautRepository.Models)
            {
                sb.AppendLine($"Name: {astronaut.Name}");
                sb.AppendLine($"Oxygen: {astronaut.Oxygen}");
                if (astronaut.Bag.Items.Count > 0)
                {
                    sb.AppendLine($"Bag items: {string.Join(", ", astronaut.Bag.Items)}");
                }
                else
                {
                    sb.AppendLine($"Bag items: none");
                }
            }

            return sb.ToString().Trim();
        }
    }
}
