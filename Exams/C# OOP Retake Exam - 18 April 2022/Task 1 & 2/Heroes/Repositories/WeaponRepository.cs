namespace Heroes.Repositories
{
    using Heroes.Models.Contracts;
    using Heroes.Models.Weapons;
    using Heroes.Repositories.Contracts;
    using Heroes.Utilities;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class WeaponRepository : IRepository<IWeapon>
    {
        private readonly List<IWeapon> models;
        public WeaponRepository() 
            : base()
        {
            this.models = new List<IWeapon>();
        }
        public IReadOnlyCollection<IWeapon> Models { get => (IReadOnlyCollection<IWeapon>)this.models; }

        public void Add(IWeapon model)
        {
            if (this.models.Any(x => x.Name == model.Name))
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.WeaponExists, model.Name));
            }
            this.models.Add(model);
        }

        public IWeapon FindByName(string name)
        {
            return this.models.FirstOrDefault(m => m.Name == name);
        }

        public bool Remove(IWeapon model)
        {
            return models.Remove(model);
        }
    }
}
