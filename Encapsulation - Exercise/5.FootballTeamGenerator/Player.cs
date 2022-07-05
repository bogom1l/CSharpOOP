using System;
using System.Collections.Generic;
using System.Text;

namespace _5.FootballTeamGenerator
{
    public class Player
    {
        private string name;

        public Player(string name, Stats stats)
        {
            this.Name = name;
            this.Stats = stats;
        }

        public string Name 
        {
            get => this.name;

            private set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ErrorMessages.NullOrWhitespaceName);
                }

                this.name = value;
            }
        }

        public Stats Stats { get; private set; }

    }
}
