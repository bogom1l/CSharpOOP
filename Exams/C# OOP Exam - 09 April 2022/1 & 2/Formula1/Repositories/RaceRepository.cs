namespace Formula1.Repositories
{
    using Formula1.Models.Contracts;
    using Formula1.Repositories.Contracts;
    using System.Collections.Generic;
    using System.Linq;

    public class RaceRepository : IRepository<IRace>
    {
        private readonly List<IRace> models;

        public RaceRepository()
        {
            this.models = new List<IRace>();
        }

        public IReadOnlyCollection<IRace> Models
        {
            get => this.models;
        }
        public void Add(IRace race)
        {
            this.models.Add(race);
        }

        public IRace FindByName(string name)
        {
            return models.FirstOrDefault(x => x.RaceName == name);
        }

        public bool Remove(IRace model)
        {
            return this.models.Remove(model);
        }
    }
}
