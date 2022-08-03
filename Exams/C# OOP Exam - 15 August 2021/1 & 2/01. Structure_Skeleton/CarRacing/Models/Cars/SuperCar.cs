namespace CarRacing.Models.Cars
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class SuperCar : Car
    {
        public SuperCar(string make, string model, string vin, int horsepower) 
            : base(make, model, vin, horsepower, 80, 10)
        {
        }
    }
}
