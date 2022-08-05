namespace AquaShop.Models.Fish
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class FreshwaterFish : Fish
    {
        public FreshwaterFish(string name, string species, decimal price) 
            : base(name, species, price)
        {
            this.Size = 3;
        }

        public override void Eat()
        {
            this.Size += 3;
        }
    }
}
