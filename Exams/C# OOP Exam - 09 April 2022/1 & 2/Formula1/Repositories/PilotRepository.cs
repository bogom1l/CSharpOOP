namespace Formula1.Repositories
{
    using Formula1.Models.Contracts;
    using Formula1.Repositories.Contracts;
    using System.Collections.Generic;
    using System.Linq;

    public class PilotRepository : IRepository<IPilot>
    {
        private readonly List<IPilot> models;

        public PilotRepository()
        {
            this.models = new List<IPilot>();
        }
        public IReadOnlyCollection<IPilot> Models
        {
            get => this.models;
        }

        public void Add(IPilot pilot)
        {
            this.models.Add(pilot);
        }

        public IPilot FindByName(string name)
        {
            return models.FirstOrDefault(p => p.FullName == name);
        }

        public bool Remove(IPilot model)
        {
            return this.models.Remove(model);
        }
    }
}
