namespace NavalVessels.Repositories
{
    using NavalVessels.Models.Contracts;
    using Contracts;

    using System.Linq;
    using System.Collections.Generic;

    public class VesselRepository : IRepository<IVessel>
    {
        private readonly List<IVessel> models;

        public VesselRepository()
        {
            this.models = new List<IVessel>();
        }

        public IReadOnlyCollection<IVessel> Models => this.models;

        public void Add(IVessel model)
        {
            this.models.Add(model);
        }

        public bool Remove(IVessel model)
        {
            return this.models.Remove(model);
        }

        public IVessel FindByName(string name)
        {
            return this.models.FirstOrDefault(x => x.Name == name);
        }
    }
}
