using System;
using System.Collections.Generic;
using System.Text;

namespace _1.Vehicles
{
    public class Truck : IDrivable
    {
        private double fuelQty;
        private double fuelCons;

        public Truck(double fQ, double fC)
        {
            this.fuelCons = fC;
            this.fuelQty = fQ;

            this.fuelCons *= 1.6;
        }

        public double FuelQty
        {
            get => fuelQty;
            set => this.fuelQty = value;
        }
        public double FuelCons
        {
            get => this.fuelCons;
            set => this.fuelCons = value;
        }

        public void Drive(double km)
        {
            throw new NotImplementedException();
        }

        public void Refuel(double liters)
        {
            throw new NotImplementedException();
        }
    }
}
