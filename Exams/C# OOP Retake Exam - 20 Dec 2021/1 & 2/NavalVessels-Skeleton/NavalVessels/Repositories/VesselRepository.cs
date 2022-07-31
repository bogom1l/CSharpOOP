namespace NavalVessels.Repositories
{
    using NavalVessels.Models.Contracts;
    using NavalVessels.Repositories.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class VesselRepository : IRepository<IVessel>
    {
        private readonly List<IVessel> models;

        public VesselRepository()
        {
            this.models = new List<IVessel>();
        }

        public IReadOnlyCollection<IVessel> Models { get => this.models; }

        public void Add(IVessel vessel)
        {
            this.models.Add(vessel);
        }

        public IVessel FindByName(string name)
        {
            return this.models.FirstOrDefault(x => x.Name == name);
        }

        public bool Remove(IVessel vessel)
        {
           return this.models.Remove(vessel);   
        }
    }
}
