namespace Heroes.Models.Map
{
    using global::Heroes.Models.Contracts;
    using global::Heroes.Models.Heroes;
    using global::Heroes.Utilities;
    using System.Collections.Generic;
    using System.Linq;

    public class Map : IMap
    {
        public string Fight(ICollection<IHero> players)
        {
            List<Barbarian> barbarians = new List<Barbarian>();
            List<Knight> knights = new List<Knight>();

            foreach (IHero hero in players)
            {
                if (hero is Knight && hero.Weapon != null && hero.IsAlive)
                {
                    knights.Add(hero as Knight);
                }
                else if (hero is Barbarian && hero.Weapon != null && hero.IsAlive)
                {
                    barbarians.Add(hero as Barbarian);
                }
            }

            var knight = knights.FirstOrDefault(k => k.IsAlive == true);
            var barbarian = barbarians.FirstOrDefault(b => b.IsAlive == true);

            while (true)
            {
                foreach (Knight currKnight in knights)
                {
                    foreach (var currBarbarian in barbarians)
                    {
                        if (currKnight.IsAlive && currBarbarian.IsAlive)
                        {
                            currBarbarian.TakeDamage(currKnight.Weapon.DoDamage());
                        }
                    }
                }

                foreach (Barbarian currBarbarian in barbarians)
                {
                    foreach (var currKnight in knights)
                    {
                        if (currBarbarian.IsAlive && currKnight.IsAlive)
                        {
                            currKnight.TakeDamage(currBarbarian.Weapon.DoDamage());
                        }
                    }
                }

                if (knights.TrueForAll(k => k.IsAlive == false))
                {
                    int deadBarbarians = barbarians.Where(x => !x.IsAlive).ToList().Count;
                    return string.Format(OutputMessages.BarbariansCasulties, deadBarbarians);
                }
                else if (barbarians.TrueForAll(b => b.IsAlive == false))
                {
                    int deadKnights = knights.Where(x => !x.IsAlive).ToList().Count;
                    return string.Format(OutputMessages.KnightsCasulties, deadKnights);
                }

            }

        }
    }
}
