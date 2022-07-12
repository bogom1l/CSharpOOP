using System;
using System.Collections.Generic;
using System.Text;

namespace _1.Vehicles_v2.Models
{
    public class Truck : Vehicle
    {
        private const double TruckFuelConsModifier = 1.6;
        private const double TruckRefuelModifier = 0.95;
        public Truck(double fuelQuantity, double fuelConsumption) : base(fuelQuantity, fuelConsumption)
        {
        }
        protected override double FuelConsumptionModifier => TruckFuelConsModifier;

        public override void Refuel(double liters)
        {
            base.Refuel(liters * TruckRefuelModifier);
        }

    }
}
