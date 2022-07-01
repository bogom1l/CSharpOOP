using System;
using System.Collections.Generic;
using System.Text;

namespace NeedForSpeed
{
    public class RaceMotorcycle : MotorCycle
    {
        public RaceMotorcycle(int horsePower, double fuel) : base(horsePower,fuel)
        {
                
        }

        private double DefaultFuelConsumption = 8;

        public override double FuelConsumption
        {
            get
            {
                return this.DefaultFuelConsumption;
            }
        }
    }
}
