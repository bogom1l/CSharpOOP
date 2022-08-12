namespace NavalVessels.Models
{
    using System;

    public class Submarine : Vessel
    {
        public Submarine(string name, double mainWeaponCaliber, double speed)
            : base(name, mainWeaponCaliber, speed, 200)
        {
            this.SubmergeMode = false;
        }

        public bool SubmergeMode { get; private set; }

        public void ToggleSubmergeMode()
        {
            if (!SubmergeMode)
            {
                this.MainWeaponCaliber += 40;
                this.Speed -= 4;
            }
            else
            {
                this.MainWeaponCaliber -= 40;
                this.Speed += 4;
            }

            this.SubmergeMode = !this.SubmergeMode;
        }

        public override void RepairVessel()
        {
            if (this.ArmorThickness < 200) //nujno?
            {
                this.ArmorThickness = 200;
            }
        }

        public override string ToString()
        {
            string ON_or_OFF = "OFF";
            if (this.SubmergeMode)
            {
                ON_or_OFF = "ON";
            }

            return base.ToString() + Environment.NewLine + $" *Submerge mode: {ON_or_OFF}";
        }
    }
}
