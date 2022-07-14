using System;
using System.Collections.Generic;
using System.Text;

namespace _3.Raiding.Models
{
    public abstract class BaseHero
    {
        public BaseHero(string name)
        {
            this.Name = name;
        }

        public string Name { get; private set; }

        public abstract int Power { get; }

        public abstract string CastAbility();

    }
}
