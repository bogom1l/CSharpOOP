using System;
using System.Collections.Generic;
using System.Text;

namespace _2.VehiclesExtension_17072022try
{
    public abstract class Vehicle
    {
        public double FuelQuantity { get; protected set; }

        public virtual double FuelConspumtionInLitersPerKilometer { get; protected set; }

        public double TankCapacity { get; protected set; }

        protected Vehicle(double fuelQuantity, double fuelConspumtionInLitersPerKilometer, double tankCapacity) 
        {
            this.FuelQuantity = fuelQuantity;
            this.FuelConspumtionInLitersPerKilometer = fuelConspumtionInLitersPerKilometer;
            if (fuelQuantity > tankCapacity)
            {
                this.FuelQuantity = 0;
            }
            this.TankCapacity = tankCapacity;
        }

        public virtual string Drive(double distance)
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
            if (liters <= 0)
            {
                throw new ArgumentException("Fuel must be a positive number");
            }
            if (this.TankCapacity < liters)
            {
                throw new ArgumentException($"Cannot fit {liters} fuel in the tank");
            }
            this.FuelQuantity += liters;
        }

        public virtual string DriveEmpty(double distance)
        {
            return this.Drive(distance);
        }

    }
}
