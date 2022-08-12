namespace NavalVessels.Models
{
    using Contracts;

    using System;
    using System.Collections.Generic;
    using System.Text;

    public abstract class Vessel : IVessel //TODO: protected nasqkade?
    {
        private string name;
        private ICaptain captain;
        private double armorThickness;
        private double mainWeaponCaliber;
        private double speed;
        private readonly List<string> targets;

        public Vessel(string name, double mainWeaponCaliber, double speed, double armorThickness)
        {
            this.targets = new List<string>();
            this.Name = name;
            this.MainWeaponCaliber = mainWeaponCaliber;
            this.Speed = speed;
            this.ArmorThickness = armorThickness;
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Vessel name cannot be null or empty.");
                }

                this.name = value;
            }
        }

        public ICaptain Captain
        {
            get => this.captain;
            set
            {
                if (value == null)
                {
                    throw new NullReferenceException("Captain cannot be null.");
                }

                this.captain = value;
            }
        }

        public double ArmorThickness
        {
            get => this.armorThickness;
            set => this.armorThickness = value;
        }

        public double MainWeaponCaliber
        {
            get => this.mainWeaponCaliber;
            protected set => this.mainWeaponCaliber = value;
        }

        public double Speed
        {
            get => this.speed;
            protected set => this.speed = value;
        }

        public ICollection<string> Targets => this.targets;

        public void Attack(IVessel target)
        {
            if (target == null)
            {
                throw new NullReferenceException("Target cannot be null.");
            }

            target.ArmorThickness -= this.MainWeaponCaliber;

            if (target.ArmorThickness < 0)
            {
                target.ArmorThickness = 0;
            }

            if (!this.targets.Contains(target.Name))
            {
                this.targets.Add(target.Name);
            }
        }

        public abstract void RepairVessel();

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"- {this.Name}");
            sb.AppendLine($" *Type: {this.GetType().Name}");
            sb.AppendLine($" *Armor thickness: {this.ArmorThickness}");
            sb.AppendLine($" *Main weapon caliber: {this.MainWeaponCaliber}");
            sb.AppendLine($" *Speed: {this.Speed} knots");
            if (this.targets.Count > 0)
            {
                sb.AppendLine($" *Targets: {string.Join(", ", this.targets)}");
            }
            else
            {
                sb.AppendLine(" *Targets: None");
            }

            return sb.ToString().Trim();
        }
    }
}
