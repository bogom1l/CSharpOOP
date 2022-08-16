namespace PlanetWars.Models.MilitaryUnits
{
    using PlanetWars.Models.MilitaryUnits.Contracts;

    using System;

    public abstract class MilitaryUnit : IMilitaryUnit
    {
        //Every Planet can possess only one MilitaryUnit from each type in it’s collection of military units.

        protected MilitaryUnit(double cost)
        {
            this.Cost = cost;
            this.EnduranceLevel = 1;
        }

        public double Cost { get; }
        public int EnduranceLevel { get; private set; }

        public void IncreaseEndurance()
        {
            this.EnduranceLevel++;

            if (this.EnduranceLevel > 20)
            {
                this.EnduranceLevel = 20;
                throw new ArgumentException("Endurance level cannot exceed 20 power points.");
            }
        }
    }
}
