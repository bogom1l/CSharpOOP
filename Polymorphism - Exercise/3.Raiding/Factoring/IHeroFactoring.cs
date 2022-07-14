using _3.Raiding.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace _3.Raiding.Factoring
{
    public interface IHeroFactoring
    {
        BaseHero CreateHero(string heroType, string heroName);
    }
}
