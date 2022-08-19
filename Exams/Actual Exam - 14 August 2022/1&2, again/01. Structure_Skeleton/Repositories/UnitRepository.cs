using PlanetWars.Models.MilitaryUnits.Contracts;
using PlanetWars.Repositories.Contracts;
using System.Linq;

namespace PlanetWars.Repositories
{
    using System.Collections.Generic;

    public class UnitRepository : IRepository<IMilitaryUnit>
    {
        private readonly List<IMilitaryUnit> _models;

        public UnitRepository()
        {
            this._models = new List<IMilitaryUnit>();
        }

        public IReadOnlyCollection<IMilitaryUnit> Models => this._models;

        public void AddItem(IMilitaryUnit model) => this._models.Add(model);

        public IMilitaryUnit FindByName(string name) => this._models.FirstOrDefault(x => x.GetType().Name == name);

        public bool RemoveItem(string name) => this._models.Remove(this.FindByName(name));
    }
}
