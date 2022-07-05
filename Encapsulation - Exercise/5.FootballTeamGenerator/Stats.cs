using System;
using System.Collections.Generic;
using System.Text;

namespace _5.FootballTeamGenerator
{
    public class Stats
    {
        private const int StatMinValue = 0;
        private const int StatMaxValue = 100;

        private int endurance;
        private int sprint;
        private int dribble;
        private int passing;
        private int shooting;

        public Stats(int endurance, int sprint, int dribble, int passing, int shooting)
        {
            this.Endurance = endurance;
            this.Sprint = sprint;
            this.Dribble = dribble;
            this.Passing = passing;
            this.Shooting = shooting;
        }

        public int Endurance 
        {
            get => this.endurance;
            private set
            {
                if (value < StatMinValue || value > StatMaxValue)
                {
                    throw new ArgumentException(String.Format(ErrorMessages.StatInvalidValue, nameof(this.Endurance)));
                }
                this.endurance = value;
            }
        }
        public int Sprint 
        {
            get => this.sprint;
            private set
            {
                if (value < StatMinValue || value > StatMaxValue)
                {
                    throw new ArgumentException(String.Format(ErrorMessages.StatInvalidValue, nameof(this.Sprint)));
                }
                this.sprint = value;
            }
        }
        public int Dribble 
        {
            get => this.dribble;
            private set
            {
                if (value < StatMinValue || value > StatMaxValue)
                {
                    throw new ArgumentException(String.Format(ErrorMessages.StatInvalidValue, nameof(this.Dribble)));
                }
                this.dribble = value;
            }
        }
        public int Passing 
        {
            get => this.passing;
            private set
            {
                if (value < StatMinValue || value > StatMaxValue)
                {
                    throw new ArgumentException(String.Format(ErrorMessages.StatInvalidValue, nameof(this.Passing)));
                }
                this.passing = value;
            }
        }
        public int Shooting 
        {
            get => this.shooting;
            private set
            {
                if (value < StatMinValue || value > StatMaxValue)
                {
                    throw new ArgumentException(String.Format(ErrorMessages.StatInvalidValue, nameof(this.Shooting)));
                }
                this.shooting = value;
            }
        }

        public double GetOverAllStat()
        {
            return (this.Endurance + this.Sprint + this.Dribble + this.Passing + this.Shooting) / 5.0;
        }

    }
}
