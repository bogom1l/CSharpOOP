using _1.Vehicles_v2.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace _1.Vehicles_v2.Factoring
{
    public class VehicleFactory : IVehicleFactory
    {
        public Vehicle CreateVehicle(string vehicleType, double fuelQty, double fuelCons)
        {
            Vehicle vehicle;

            if (vehicleType == "Car")
            {
                vehicle = new Car(fuelQty, fuelCons);
            }
            else if (vehicleType == "Truck")
            {
                vehicle = new Truck(fuelQty, fuelCons);
            }
            else
            {
                throw new Exception("Invalid vehicle type!");
            }

            return vehicle;
        }
    }
}
