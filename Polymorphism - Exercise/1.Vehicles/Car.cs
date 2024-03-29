﻿using System;
using System.Collections.Generic;
using System.Text;

namespace _1.Vehicles
{
    public class Car : Vehicle
    {
        private const double fuelConsumptionBonus = 0.9;

        public Car(double fuelQuantity, double fuelConspumtionInLitersPerKilometer) 
            : base(fuelQuantity, fuelConspumtionInLitersPerKilometer)
        {
            this.FuelConspumtionInLitersPerKilometer += fuelConsumptionBonus;
        }

    }
}
