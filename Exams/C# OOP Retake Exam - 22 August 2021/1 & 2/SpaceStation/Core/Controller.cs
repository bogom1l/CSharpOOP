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
        private readonly PlanetRepository planetRepository;
        private readonly AstronautRepository astronautRepository;
        private int planetsExplored = 0;
        public Controller()
        {
            this.planetRepository = new PlanetRepository();
            this.astronautRepository = new AstronautRepository();
        }

        public string AddAstronaut(string type, string astronautName)
        {
            IAstronaut astronaut = null;
            //check if astronaut already exists in astronautRepository

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

            this.astronautRepository.Add(astronaut);
            return $"Successfully added {type}: {astronautName}!";
        }

        public string AddPlanet(string planetName, params string[] items)
        {
            IPlanet planet = new Planet(planetName);
            //check if planet already exists in repo

            foreach (string item in items)
            {
                planet.Items.Add(item);
            }

            this.planetRepository.Add(planet);
            return $"Successfully added Planet: {planetName}!";
        }

        public string ExplorePlanet(string planetName)
        {
            IPlanet planet = this.planetRepository.FindByName(planetName); 
            IMission mission = new Mission();

            List<IAstronaut> suitableAstronauts = this.astronautRepository.Models.Where(x => x.Oxygen > 60).ToList(); 

            if (!suitableAstronauts.Any())
            {
                throw new InvalidOperationException("You need at least one astronaut to explore the planet");
            }

            mission.Explore(planet, suitableAstronauts);
            planetsExplored++;

            int deadCount = suitableAstronauts.Where(x => !x.CanBreath).Count();

            return $"Planet: {planetName} was explored! Exploration finished with {deadCount} dead astronauts!";
        }

        public string Report() //TODO: to check for AppendLine in all cases if it works right
        {
            var sb = new StringBuilder();

            sb.AppendLine($"{this.planetsExplored} planets were explored!");
            sb.AppendLine("Astronauts info:"); 

            foreach (var astronaut in this.astronautRepository.Models)
            {
                sb.AppendLine($"Name: {astronaut.Name}");
                sb.AppendLine($"Oxygen: {astronaut.Oxygen}");
                
                if (astronaut.Bag.Items.Count <= 0)
                {
                    sb.AppendLine("Bag items: none");
                }
                else
                {
                    sb.AppendLine($"Bag items: {string.Join(", ", astronaut.Bag.Items)}");
                }
            }

            return sb.ToString().Trim();
        }

        public string RetireAstronaut(string astronautName)
        {
            IAstronaut astronaut = astronautRepository.FindByName(astronautName);

            if (astronaut == null)
            {
                throw new InvalidOperationException($"Astronaut {astronautName} doesn't exists!");
            }

            this.astronautRepository.Remove(astronaut);
            return $"Astronaut {astronautName} was retired!";
        }
    }
}
