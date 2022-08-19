using PlanetWars.Models.Weapons.Contracts;
using PlanetWars.Repositories.Contracts;
using System.Linq;

namespace PlanetWars.Repositories
{
    using System.Collections.Generic;

    public class WeaponRepository : IRepository<IWeapon>
    {
        private readonly List<IWeapon> _models;

        public WeaponRepository()
        {
            this._models = new List<IWeapon>();
        }

        public IReadOnlyCollection<IWeapon> Models => this._models;

        public void AddItem(IWeapon model) => this._models.Add(model);

        public IWeapon FindByName(string name) => this._models.FirstOrDefault(x => x.GetType().Name == name);

        public bool RemoveItem(string name) => this._models.Remove(this.FindByName(name));
    }
}
