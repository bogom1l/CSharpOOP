namespace CarRacing.Models.Cars
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class TunedCar : Car
    {
        public TunedCar(string make, string model, string vin, int horsepower) 
            : base(make, model, vin, horsepower, 65, 7.5)
        {
        }

        public override void Drive()
        {
            base.Drive();
            this.HorsePower = (int)(this.HorsePower * 0.97); //Math.Round()?
        }
    }
}
