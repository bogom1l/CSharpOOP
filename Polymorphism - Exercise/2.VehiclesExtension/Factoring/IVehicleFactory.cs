using _2.VehiclesExtension.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace _2.VehiclesExtension.Factoring
{
    public interface IVehicleFactory
    {
        Vehicle CreateVehicle(string vehicleType, double fuelQty, double fuelCons);
    }
}
