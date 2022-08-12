namespace NavalVessels.Models
{
    using Contracts;

    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Captain : ICaptain
    {
        private string fullName;
        private List<IVessel> vessels;

        public Captain(string fullName)
        {
            this.vessels = new List<IVessel>();
            this.CombatExperience = 0;
            this.FullName = fullName;
        }

        public string FullName
        {
            get => this.fullName;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Captain full name cannot be null or empty string.");
                }

                this.fullName = value;
            }
        }

        public int CombatExperience { get; private set; }

        public ICollection<IVessel> Vessels => this.vessels;

        public void AddVessel(IVessel vessel)
        {
            if (vessel == null)
            {
                throw new NullReferenceException("Null vessel cannot be added to the captain.");
            }

            this.vessels.Add(vessel);
        }

        public void IncreaseCombatExperience()
        {
            this.CombatExperience += 10; //samo tva?
        }

        public string Report()
        {
            var sb = new StringBuilder();

            sb.AppendLine(
                $"{this.FullName} has {this.CombatExperience} combat experience and commands {this.vessels.Count} vessels.");

            if (this.vessels.Count > 0)
            {
                foreach (var vessel in this.vessels)
                {
                    sb.AppendLine(vessel.ToString());
                }
            }

            return sb.ToString().Trim();
        }
    }
}
