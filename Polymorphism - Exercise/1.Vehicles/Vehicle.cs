using System;
using System.Collections.Generic;
using System.Text;

namespace _1.Vehicles
{
    public abstract class Vehicle
    {
        public double FuelQuantity { get; set; }

        public virtual double FuelConspumtionInLitersPerKilometer { get; set; }

        public Vehicle(double fuelQuantity, double fuelConspumtionInLitersPerKilometer)
        {
            this.FuelQuantity = fuelQuantity;
            this.FuelConspumtionInLitersPerKilometer = fuelConspumtionInLitersPerKilometer;
        }

        public string Drive(double distance)
        {
            double fuelNeeded = distance * this.FuelConspumtionInLitersPerKilometer;

            if (fuelNeeded > this.FuelQuantity)
            {
                return $"{this.GetType().Name} needs refueling";
            }
            else
            {
                this.FuelQuantity -= fuelNeeded;
                return $"{this.GetType().Name} travelled {distance} km";
            }
        }
        public virtual void Refuel(double liters)
        {
            this.FuelQuantity += liters;
        }

    }
}
