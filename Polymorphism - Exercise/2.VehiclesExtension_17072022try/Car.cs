using System;
using System.Collections.Generic;
using System.Text;

namespace _2.VehiclesExtension_17072022try
{
    public class Car : Vehicle
    {
        private const double fuelConsumptionBonus = 0.9;

        public Car(double fuelQuantity, double fuelConspumtionInLitersPerKilometer, double tankCapacity) 
            : base(fuelQuantity, fuelConspumtionInLitersPerKilometer, tankCapacity)
        {
            this.FuelConspumtionInLitersPerKilometer += fuelConsumptionBonus;
        }

    }
}
