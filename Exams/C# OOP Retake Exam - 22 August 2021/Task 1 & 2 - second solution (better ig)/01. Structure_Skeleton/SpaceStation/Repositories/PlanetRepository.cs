namespace SpaceStation.Repositories
{
    using SpaceStation.Models.Planets.Contracts;
    using SpaceStation.Repositories.Contracts;
    using System.Collections.Generic;
    using System.Linq;


    public class PlanetRepository : IRepository<IPlanet>
    {
        private readonly List<IPlanet> _models;

        public PlanetRepository()
        {
            this._models = new List<IPlanet>();
        }

        public IReadOnlyCollection<IPlanet> Models => this._models;

        public void Add(IPlanet model)
        {
            this._models.Add(model);
        }

        public bool Remove(IPlanet model)
        {
            return this._models.Remove(model);
        }

        public IPlanet FindByName(string name)
        {
            return this._models.FirstOrDefault(x => x.Name == name);
            //It is guaranteed that the planet exists in the collection.
        }
    }
}