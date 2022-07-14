using System;
using System.Collections.Generic;
using System.Text;

namespace _2.VehiclesExtension.Models
{
    public class Car : Vehicle
    {
        private const double CarFuelConsModifier = 0.9;
        public Car(double fuelQuantity, double fuelConsumption) : base(fuelQuantity, fuelConsumption) 
        {
        }
        protected override double FuelConsumptionModifier => CarFuelConsModifier;

    }
}
