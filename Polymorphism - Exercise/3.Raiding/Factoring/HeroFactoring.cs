using _3.Raiding.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace _3.Raiding.Factoring
{
    public class HeroFactoring : IHeroFactoring
    {
        public BaseHero CreateHero(string heroType, string heroName)
        {
            BaseHero hero = null;

            if (heroType == "Druid")
            {
                hero = new Druid(heroName);
            }
            else if (heroType == "Paladin")
            {
                hero = new Paladin(heroName);
            }
            else if (heroType == "Rogue")
            {
                hero = new Rogue(heroName);
            }
            else if (heroType == "Warrior")
            {
                hero = new Warrior(heroName);
            }

            return hero;
        }
    }
}
