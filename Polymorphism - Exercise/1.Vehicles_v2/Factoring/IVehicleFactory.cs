using _1.Vehicles_v2.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace _1.Vehicles_v2.Factoring
{
    public interface IVehicleFactory
    {
        Vehicle CreateVehicle(string vehicleType, double fuelQty, double fuelCons);
    }
}
