namespace Heroes.Repositories
{
    using Heroes.Models.Contracts;
    using Heroes.Repositories.Contracts;
    using Heroes.Utilities;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class HeroRepository : IRepository<IHero>
    {
        private readonly List<IHero> models;
        public HeroRepository() 
            : base()
        {
            this.models = new List<IHero>();
        }
        public IReadOnlyCollection<IHero> Models { get => (IReadOnlyCollection<IHero>)this.models; }


        public void Add(IHero model)
        {
            if (this.models.Any(x => x.Name == model.Name))
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.HeroExists, model.Name));
            }
            this.models.Add(model);
        }

        public IHero FindByName(string name)
        {
            return models.FirstOrDefault(m => m.Name == name);
        }

        public bool Remove(IHero model)
        {
            return models.Remove(model);
        }
    }
}
