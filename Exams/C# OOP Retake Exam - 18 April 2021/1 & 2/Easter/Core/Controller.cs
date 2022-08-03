namespace Easter.Core
{
    using Easter.Core.Contracts;
    using Easter.Models.Bunnies;
    using Easter.Models.Bunnies.Contracts;
    using Easter.Models.Dyes;
    using Easter.Models.Eggs;
    using Easter.Models.Eggs.Contracts;
    using Easter.Models.Workshops;
    using Easter.Models.Workshops.Contracts;
    using Easter.Repositories;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Controller : IController
    {
        private BunnyRepository bunnies;
        private EggRepository eggs;
        private IWorkshop workshop;
        public Controller()
        {
            this.bunnies = new BunnyRepository();
            this.eggs = new EggRepository();
            this.workshop = new Workshop();
        }

        public string AddBunny(string bunnyType, string bunnyName)
        {
            IBunny bunny = null;

            if (bunnyType == nameof(SleepyBunny))
            {
                bunny = new SleepyBunny(bunnyName);
            }
            else if (bunnyType == nameof(HappyBunny))
            {
                bunny = new HappyBunny(bunnyName);
            }
            else
            {
                throw new InvalidOperationException("Invalid bunny type.");
            }

            this.bunnies.Add(bunny);
            return $"Successfully added {bunnyType} named {bunnyName}.";
        }

        public string AddDyeToBunny(string bunnyName, int power)
        {
            IBunny bunny = bunnies.FindByName(bunnyName);

            if (bunny == null)
            {
                throw new InvalidOperationException("The bunny you want to add a dye to doesn't exist!");
            }

            bunny.AddDye(new Dye(power));
            return $"Successfully added dye with power {power} to bunny {bunnyName}!";
        }

        public string AddEgg(string eggName, int energyRequired)
        {
            IEgg egg = new Egg(eggName, energyRequired);

            this.eggs.Add(egg);
            return $"Successfully added egg: {eggName}!";
        }

        public string ColorEgg(string eggName)
        {
            IBunny bunny = null;
            IEgg egg = this.eggs.FindByName(eggName);
            List<IBunny> selectedBunnies = this.bunnies.Models.Where(x => x.Energy >= 50 && x.Dyes.Count > 0).OrderByDescending(x => x.Energy).ToList();

            if (!selectedBunnies.Any())
            {
                throw new InvalidOperationException("There is no bunny ready to start coloring!");
            }
            //


            while (selectedBunnies.Count > 0 && !egg.IsDone())
            {
                bunny = selectedBunnies.First();
                this.workshop.Color(egg, bunny);

                if (bunny.Energy == 0)
                {
                    this.bunnies.Remove(bunny);
                    selectedBunnies = this.bunnies.Models.Where(x => x.Energy >= 50 && x.Dyes.Count > 0).OrderByDescending(x => x.Energy).ToList();
                }
                else if (bunny.Dyes.Count == 0)
                {
                    selectedBunnies = this.bunnies.Models.Where(x => x.Energy >= 50 && x.Dyes.Count > 0).OrderByDescending(x => x.Energy).ToList();
                }
            }


            //
            if (egg.IsDone())
            {
                return $"Egg {eggName} is done.";
            }
            return $"Egg {eggName} is not done.";
        }

        public string Report()
        {
            var sb = new StringBuilder();

            List<IEgg> eggsReady = this.eggs.Models.Where(x => x.IsDone()).ToList();

            sb.AppendLine($"{eggsReady.Count} eggs are done!");
            sb.AppendLine("Bunnies info:");

            foreach (IBunny bunny in this.bunnies.Models)
            {
                sb.AppendLine($"Name: {bunny.Name}");
                sb.AppendLine($"Energy: {bunny.Energy}");
                sb.AppendLine($"Dyes: {bunny.Dyes.Count} not finished");
            }

            return sb.ToString().Trim();
        }
    }
}
