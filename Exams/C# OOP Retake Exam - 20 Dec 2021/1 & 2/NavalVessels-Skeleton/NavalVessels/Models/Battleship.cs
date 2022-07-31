namespace NavalVessels.Models
{
    using System;

    public class Battleship : Vessel
    {
        private const int DefaultArmorThickness = 300;
        public Battleship(string name, double mainWeaponCaliber, double speed)
            : base(name, mainWeaponCaliber, speed)
        {
            this.SonarMode = false;
            this.ArmorThickness = DefaultArmorThickness;
        }

        public bool SonarMode { get; private set; }

        public override void RepairVessel()
        {
            if (this.ArmorThickness < DefaultArmorThickness)
            {
                this.ArmorThickness = DefaultArmorThickness;
            }
        }

        public void ToggleSonarMode()
        {
            if (this.SonarMode == false)
            {
                this.SonarMode = true;
                this.MainWeaponCaliber += 40;
                this.Speed -= 5;
            }
            else if(this.SonarMode == true)
            {
                this.SonarMode = false;
                this.MainWeaponCaliber -= 40;
                this.Speed += 5;
            }
        }

        public override string ToString()
        {
            string bonus;
            if (this.SonarMode == true)
            {
                bonus = ($" *Sonar mode: ON");
            }
            else
            {
                bonus = ($" *Sonar mode: OFF");
            }

            return base.ToString() + Environment.NewLine + bonus;
        }
    }
}
