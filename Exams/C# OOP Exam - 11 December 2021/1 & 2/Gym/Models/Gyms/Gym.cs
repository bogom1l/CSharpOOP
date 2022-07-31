namespace Gym.Models.Gyms
{
    using global::Gym.Models.Athletes.Contracts;
    using global::Gym.Models.Equipment.Contracts;
    using global::Gym.Models.Gyms.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public abstract class Gym : IGym
    {
        private string name;
        private int capacity;
        private readonly List<IEquipment> equipment;
        private readonly List<IAthlete> athletes;

        protected Gym(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.equipment = new List<IEquipment>();
            this.athletes = new List<IAthlete>();
        }
        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Gym name cannot be null or empty.");
                }
                this.name = value;
            }
        }

        public int Capacity
        {
            get => this.capacity;
            private set
            {
                this.capacity = value;
            }
        }

        public double EquipmentWeight => this.equipment.Sum(x => x.Weight);

        public ICollection<IEquipment> Equipment => this.equipment;

        public ICollection<IAthlete> Athletes => this.athletes;

        public virtual void AddAthlete(IAthlete athlete)
        {
            this.athletes.Add(athlete);
        }

        public void AddEquipment(IEquipment equipment)
        {
            this.equipment.Add(equipment);
        }

        public void Exercise()
        {
            athletes.ForEach(x => x.Exercise());    
        }

        public string GymInfo()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"{this.Name} is a {this.GetType().Name}:");
            if (this.athletes.Count > 0)
            {
                sb.AppendLine($"Athletes: {string.Join(", ", this.athletes.Select(x => x.FullName))}");
            }
            else
            {
                sb.AppendLine("Athletes: No athletes");
            }
            
            sb.AppendLine($"Equipment total count: {this.equipment.Count}");
            sb.AppendLine($"Equipment total weight: {this.EquipmentWeight:f2} grams");

            return sb.ToString().Trim();
        }

        public bool RemoveAthlete(IAthlete athlete)
        {
            return this.athletes.Remove(athlete);
        }
    }
}
