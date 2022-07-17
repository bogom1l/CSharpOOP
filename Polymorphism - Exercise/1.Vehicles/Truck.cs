using System;
using System.Collections.Generic;
using System.Text;

namespace _1.Vehicles
{
    public class Truck : Vehicle
    {
        private const double fuelConsumptionBonus = 1.6;
        public Truck(double fuelQuantity, double fuelConspumtionInLitersPerKilometer)
            : base(fuelQuantity, fuelConspumtionInLitersPerKilometer)
        {
            this.FuelConspumtionInLitersPerKilometer += fuelConsumptionBonus;
        }

        public override void Refuel(double liters)
        {
            this.FuelQuantity += (liters * 0.95);
        }
    }
}
