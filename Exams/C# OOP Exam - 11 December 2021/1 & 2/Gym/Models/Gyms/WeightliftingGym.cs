namespace Gym.Models.Gyms
{
    using global::Gym.Models.Athletes.Contracts;
    using System;

    public class WeightliftingGym : Gym
    {
        public WeightliftingGym(string name) : base(name, 20)
        {
        }

        public override void AddAthlete(IAthlete athlete)
        {
            if (this.Athletes.Count >= this.Capacity)
            {
                throw new InvalidOperationException("Not enough space in the gym.");
            }

            base.AddAthlete(athlete);
        }
    }
}
