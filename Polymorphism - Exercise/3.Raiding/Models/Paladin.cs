using System;
using System.Collections.Generic;
using System.Text;

namespace _3.Raiding.Models
{
    public class Paladin : BaseHero
    {
        private const int CurrentPower = 100;
        public Paladin(string name) 
            : base(name)
        {
        }

        public override int Power => CurrentPower;

        public override string CastAbility()
        {
            return $"{this.GetType().Name} - {this.Name} healed for {this.Power}";
        }
    }
}
