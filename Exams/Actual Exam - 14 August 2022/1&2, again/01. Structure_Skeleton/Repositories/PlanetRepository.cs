using PlanetWars.Models.Planets.Contracts;
using PlanetWars.Repositories.Contracts;
using System.Linq;

namespace PlanetWars.Repositories
{
    using System.Collections.Generic;

    public class PlanetRepository : IRepository<IPlanet>
    {
        private readonly IList<IPlanet> _models;

        public PlanetRepository()
        {
            this._models = new List<IPlanet>();
        }

        public IReadOnlyCollection<IPlanet> Models => this._models.ToList().AsReadOnly();

        public void AddItem(IPlanet model) => this._models.Add(model);

        public IPlanet FindByName(string name) => this._models.FirstOrDefault(x => x.Name == name);

        public bool RemoveItem(string name) => this._models.Remove(this.FindByName(name));
    }
}
