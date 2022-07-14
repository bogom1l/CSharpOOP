using System;
using System.Collections.Generic;
using System.Text;

namespace _3.Raiding.Models
{
    public class Druid : BaseHero
    {
        private const int CurrentPower = 80;
        public Druid(string name) 
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
