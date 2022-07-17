using System;
using System.Collections.Generic;
using System.Text;

namespace _2.VehiclesExtension_17072022try
{
    public class Bus : Vehicle
    {
        public Bus(double fuelQuantity, double fuelConspumtionInLitersPerKilometer, double tankCapacity)
            : base(fuelQuantity, fuelConspumtionInLitersPerKilometer, tankCapacity)
        {
        }

        public override string Drive(double distance)
        {
            double fuelNeeded = distance * (this.FuelConspumtionInLitersPerKilometer + 1.4);

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

        public override string DriveEmpty(double distance)
        {
            return base.Drive(distance);
        }
    }
}
