using System;
using System.Collections.Generic;
using System.Text;

namespace _1.Vehicles
{
    public interface IDrivable
    {
        double FuelQty { get; set; }
        double FuelCons { get; set; }
        void Drive(double km);
        void Refuel(double liters);

    }
}
