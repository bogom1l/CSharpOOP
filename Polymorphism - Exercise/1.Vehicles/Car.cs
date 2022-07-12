using System;
using System.Collections.Generic;
using System.Text;

namespace _1.Vehicles
{
    public class Car : IDrivable
    {
        private double fuelQty;
        private double fuelCons;

        public Car(double fQ, double fC)
        {
            this.fuelCons = fC;
            this.fuelQty = fQ;

            this.fuelCons *= 0.9;
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

        //public double TotalKmLeftToDrive { get; set; } = FuelQty * FuelCons;

        public void Drive(double km)
        {
            double totalKmLeftToDrive = this.fuelQty * this.fuelCons;
            Console.WriteLine($"{this.GetType().Name} travelled {km} km");
        }


        public void Refuel(double liters)
        {
            throw new NotImplementedException();
        }
    }
}
