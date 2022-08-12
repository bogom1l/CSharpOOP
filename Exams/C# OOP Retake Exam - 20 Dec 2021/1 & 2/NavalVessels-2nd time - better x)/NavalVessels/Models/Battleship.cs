namespace NavalVessels.Models
{
    using System;

    public class Battleship : Vessel
    {
        public Battleship(string name, double mainWeaponCaliber, double speed)
            : base(name, mainWeaponCaliber, speed, 300)
        {
            this.SonarMode = false;
        }

        public bool SonarMode { get; private set; }

        public void ToggleSonarMode()
        {
            if (!SonarMode)
            {
                this.MainWeaponCaliber += 40;
                this.Speed -= 5;
            }
            else
            {
                this.MainWeaponCaliber -= 40;
                this.Speed += 5;
            }

            this.SonarMode = !this.SonarMode;
        }

        public override void RepairVessel()
        {
            if (this.ArmorThickness < 300) //nujno?
            {
                this.ArmorThickness = 300;
            }
        }

        public override string ToString()
        {
            string ON_or_OFF = "OFF";
            if (this.SonarMode)
            {
                ON_or_OFF = "ON";
            }

            return base.ToString() + Environment.NewLine + $" *Sonar mode: {ON_or_OFF}";
        }
    }
}
