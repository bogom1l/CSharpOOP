namespace NavalVessels.Models
{
    using NavalVessels.Models.Contracts;
    using System;

    public class Submarine : Vessel, ISubmarine
    {
        private const int DefaultArmorThickness = 200;
        public Submarine(string name, double mainWeaponCaliber, double speed) 
            : base(name, mainWeaponCaliber, speed, DefaultArmorThickness)
        {
            this.SubmergeMode = false;
        }

        public bool SubmergeMode { get; private set; }

        public override void RepairVessel()
        {
            if (this.ArmorThickness < DefaultArmorThickness)
            {
                this.ArmorThickness = DefaultArmorThickness;
            }
        }

        public void ToggleSubmergeMode()
        {
            if (this.SubmergeMode == false)
            {
                this.SubmergeMode = true;
                this.MainWeaponCaliber += 40;
                this.Speed -= 4;
            }
            else if (this.SubmergeMode == true)
            {
                this.SubmergeMode = false;
                this.MainWeaponCaliber -= 40;
                this.Speed += 4;
            }
        }

        public override string ToString()
        {
            string bonus;
            if (this.SubmergeMode == true)
            {
                bonus = ($" *Submerge mode: ON");
            }
            else
            {
                bonus = ($" *Submerge mode: OFF");
            }

            return base.ToString() + Environment.NewLine + bonus;
        }
    }
}
