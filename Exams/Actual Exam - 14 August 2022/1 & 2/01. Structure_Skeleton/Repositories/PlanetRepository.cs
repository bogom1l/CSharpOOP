namespace PlanetWars.Repositories
{
    using PlanetWars.Models.Planets.Contracts;
    using PlanetWars.Repositories.Contracts;

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

        public void AddItem(IPlanet model) => this._models.Add(model);

        public IPlanet FindByName(string name) => this._models.FirstOrDefault(x => x.Name == name);

        public bool RemoveItem(string name) => this._models.Remove(this.FindByName(name));

    }
}
