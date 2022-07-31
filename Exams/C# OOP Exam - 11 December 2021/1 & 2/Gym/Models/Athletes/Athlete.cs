namespace Gym.Models.Athletes
{
    using Gym.Models.Athletes.Contracts;
    using System;

    public abstract class Athlete : IAthlete
    {
        private string fullName;
        private string motivation;
        private int stamina;
        private int numberOfMedals;

        protected Athlete(string fullName, string motivation, int numberOfMedals, int stamina)
        {
            this.FullName = fullName;
            this.Motivation = motivation;
            this.Stamina = stamina;
            this.NumberOfMedals = numberOfMedals;
        }

        public string FullName
        {
            get => this.fullName;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Athlete name cannot be null or empty.");
                }
                this.fullName = value;
            }
        }

        public string Motivation
        {
            get => this.motivation;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("The motivation cannot be null or empty.");
                }
                this.motivation = value;
            }
        }

        public int Stamina
        {
            get => this.stamina;
            protected set
            {
                this.stamina = value;
            }
        }

        public int NumberOfMedals
        {
            get => this.numberOfMedals;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Athlete's number of medals cannot be below 0.");
                }
                this.numberOfMedals = value;
            }
        }

        public abstract void Exercise();
    }
}
