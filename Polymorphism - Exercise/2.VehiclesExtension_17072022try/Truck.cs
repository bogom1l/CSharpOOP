using System;
using System.Collections.Generic;
using System.Text;

namespace _2.VehiclesExtension_17072022try
{
    public class Truck : Vehicle
    {
        private const double fuelConsumptionBonus = 1.6;
        public Truck(double fuelQuantity, double fuelConspumtionInLitersPerKilometer, double tankCapacity)
            : base(fuelQuantity, fuelConspumtionInLitersPerKilometer, tankCapacity)
        {
            this.FuelConspumtionInLitersPerKilometer += fuelConsumptionBonus;
        }

        public override void Refuel(double liters)
        {
            if (liters <= 0)
            {
                throw new ArgumentException("Fuel must be a positive number");
            }
            if (this.TankCapacity < liters)
            {
                throw new ArgumentException($"Cannot fit {liters} fuel in the tank");
            }
            this.FuelQuantity += (liters * 0.95);
        }
    }
}
