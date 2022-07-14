using System;
using System.Collections.Generic;
using System.Text;

namespace _2.VehiclesExtension.Models.Interfaces
{
    //this interface will not be used for this task for now
    //its made in case i decide to use it later to implement Dependancy Injection
    public interface IVehicle
    {
        double FuelQuantity { get; }

        double FuelConsumption { get; }

        string Drive(double distance);

        void Refuel(double liters);

    }
}
