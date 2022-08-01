namespace SpaceStation.Models.Mission
{
    using SpaceStation.Models.Astronauts.Contracts;
    using SpaceStation.Models.Bags.Contracts;
    using SpaceStation.Models.Mission.Contracts;
    using SpaceStation.Models.Planets.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Mission : IMission
    { 
        public void Explore(IPlanet planet, ICollection<IAstronaut> astronauts)
        {
            foreach (IAstronaut astronaut in astronauts)
            {
                while (planet.Items.Any())
                {
                    string item = planet.Items.FirstOrDefault();
                    astronaut.Breath();
                    astronaut.Bag.Items.Add(item);
                    planet.Items.Remove(item);

                    if (!astronaut.CanBreath)
                    {
                        break;
                    }
                }
            }

        }
    }
}
