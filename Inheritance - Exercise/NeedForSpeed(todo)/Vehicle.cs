using System;
using System.Collections.Generic;
using System.Text;

namespace NeedForSpeed
{
    public class Vehicle
    {
        public double Fuel { get; set; }
        public int HorsePower { get; set; }

        public Vehicle(int horsePower, double fuel)
        {
            this.HorsePower = horsePower;
            this.Fuel = fuel;
        }
        
        private double DefaultFuelConsumption = 1.25;

        public virtual double FuelConsumption
        {
            get
            {
                return this.DefaultFuelConsumption;
            }
        }

        public virtual void Drive(double kilometers)
        {
            this.Fuel -= kilometers * FuelConsumption;
        }

    }
}
