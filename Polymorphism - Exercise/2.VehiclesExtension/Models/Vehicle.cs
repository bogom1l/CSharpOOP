using _2.VehiclesExtension.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace _2.VehiclesExtension.Models
{
    public abstract class Vehicle : IVehicle
    {
        private double fuelQuantity;
        private double fuelConsumption;

        protected Vehicle(double fuelQuantity, double fuelConsumption)
        {
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumption = fuelConsumption;
        }

        public double FuelQuantity 
        { 
            get => this.fuelQuantity;
            private set => this.fuelQuantity = value;
        }

        public virtual double FuelConsumption
        {
            get => this.fuelConsumption;
            protected set => this.fuelConsumption = value + this.FuelConsumptionModifier;
        }

        protected virtual double FuelConsumptionModifier { get; }



        public string Drive(double distance)
        {
            double fuelNeeded = distance * this.FuelConsumption;

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

        public override string ToString()
        {
            return $"{this.GetType().Name}: {this.FuelQuantity:f2}";
        }

    }
}
