using System;
using System.Collections.Generic;
using System.Text;

namespace _1.Vehicles_v2.Models
{
    public class Bus : Vehicle
    {
        public Bus(double fuelQuantity, double fuelConsumption) : base(fuelQuantity, fuelConsumption)
        {
        }

        public override double TankCapacity { get ; set; }
    }
}
