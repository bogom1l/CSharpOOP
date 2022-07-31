﻿namespace Gym.Models.Athletes
{
    using System;

    public class Weightlifter : Athlete
    {
        private const int InitialStamina = 50;
        //Can train only in a WeightliftingGym.

        public Weightlifter(string fullName, string motivation, int numberOfMedals)
            : base(fullName, motivation, numberOfMedals, InitialStamina)
        {
        }

        public override void Exercise()
        {
            this.Stamina += 10;
            if (this.Stamina > 100)
            {
                this.Stamina = 100;
                throw new ArgumentException("Stamina cannot exceed 100 points.");
            }
        }
    }
}
