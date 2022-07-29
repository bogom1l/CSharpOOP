namespace Heroes.Models.Weapons
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Mace : Weapon
    {
        public Mace(string name, int durability) 
            : base(name, durability)
        {
        }

        public override int DoDamage()
        {
            if (this.Durability > 0)
            {
                this.Durability--;
                return 25;
            }

            return 0;
        }
    }
}
