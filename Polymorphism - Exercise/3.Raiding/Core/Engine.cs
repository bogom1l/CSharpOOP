using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using _3.Raiding.Factoring;
using _3.Raiding.Models;

namespace _3.Raiding.Core
{
    public class Engine : IEngine
    {
        private readonly List<BaseHero> heroesList;
        private readonly IHeroFactoring heroFactory;

        public Engine()
        {
            this.heroesList = new List<BaseHero>();
            this.heroFactory = new HeroFactoring();
        }
        public void Start()
        {
            int N = int.Parse(Console.ReadLine());

            for (int i = 0; i < N; i++)
            {
                string heroName = Console.ReadLine();
                string heroType = Console.ReadLine();

                BaseHero currHero = heroFactory.CreateHero(heroType, heroName);

                if (currHero == null)
                {
                    Console.WriteLine("Invalid hero!");
                    i--;
                }
                else
                {
                    heroesList.Add(currHero);
                }

            }

            int bossPower = int.Parse(Console.ReadLine());

            int totalPowerFromAllHeros = heroesList.Sum(x => x.Power);

            foreach (BaseHero currHero in heroesList)
            {
                Console.WriteLine(currHero.CastAbility());
            }

            if (totalPowerFromAllHeros >= bossPower)
            {
                Console.WriteLine("Victory!");
            }
            else
            {
                Console.WriteLine("Defeat...");
            }

        }

    }
}
