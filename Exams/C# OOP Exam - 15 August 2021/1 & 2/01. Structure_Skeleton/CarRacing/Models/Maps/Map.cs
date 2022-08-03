namespace CarRacing.Models.Maps
{
    using CarRacing.Models.Maps.Contracts;
    using CarRacing.Models.Racers.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Map : IMap
    {
        public string StartRace(IRacer racerOne, IRacer racerTwo)
        {
            if (!racerOne.IsAvailable() && !racerTwo.IsAvailable())
            {
                return "Race cannot be completed because both racers are not available!";
            }
            if (!racerOne.IsAvailable() && racerTwo.IsAvailable())
            {
                return $"{racerTwo.Username} wins the race! {racerOne.Username} was not available to race!";
            }
            if (!racerTwo.IsAvailable() && racerOne.IsAvailable())
            {
                return $"{racerOne.Username} wins the race! {racerTwo.Username} was not available to race!";
            }


            double RACER_ONE_RacingBehaviorMultiplier = 0;
            if (racerOne.RacingBehavior == "strict")
            {
                RACER_ONE_RacingBehaviorMultiplier = 1.2;
            }
            else if (racerOne.RacingBehavior == "aggressive")
            {
                RACER_ONE_RacingBehaviorMultiplier = 1.1;
            }
            double RACER_ONE_chanceOfWinning = racerOne.Car.HorsePower * racerOne.DrivingExperience * RACER_ONE_RacingBehaviorMultiplier;


            double RACER_TWO_RacingBehaviorMultiplier = 0;
            if (racerTwo.RacingBehavior == "strict")
            {
                RACER_TWO_RacingBehaviorMultiplier = 1.2;
            }
            else if (racerTwo.RacingBehavior == "aggressive")
            {
                RACER_TWO_RacingBehaviorMultiplier = 1.1;
            }
            double RACER_TWO_chanceOfWinning = racerTwo.Car.HorsePower * racerTwo.DrivingExperience * RACER_TWO_RacingBehaviorMultiplier;


            racerOne.Race();
            racerTwo.Race();

            if (RACER_ONE_chanceOfWinning > RACER_TWO_chanceOfWinning)
            {
                return $"{racerOne.Username} has just raced against {racerTwo.Username}! {racerOne.Username} is the winner!";
            }
            return $"{racerTwo.Username} has just raced against {racerOne.Username}! {racerTwo.Username} is the winner!";
        }
    }
}
