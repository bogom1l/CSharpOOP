namespace Gym.Models.Gyms
{
    using global::Gym.Models.Athletes.Contracts;
    using System;

    public class BoxingGym : Gym
    {
        public BoxingGym(string name) : base(name, 15)
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
