namespace SpaceStation.Repositories
{
    using SpaceStation.Models.Astronauts.Contracts;
    using SpaceStation.Repositories.Contracts;
    using System.Collections.Generic;
    using System.Linq;

    public class AstronautRepository : IRepository<IAstronaut>
    {
        private readonly List<IAstronaut> _models;

        public AstronautRepository()
        {
            this._models = new List<IAstronaut>();
        }

        public IReadOnlyCollection<IAstronaut> Models => this._models;

        public void Add(IAstronaut model)
        {
            this._models.Add(model);
        }

        public bool Remove(IAstronaut model)
        {
            return this._models.Remove(model);
        }

        public IAstronaut FindByName(string name)
        {
            return this._models.FirstOrDefault(x => x.Name == name);
        }
    }
}