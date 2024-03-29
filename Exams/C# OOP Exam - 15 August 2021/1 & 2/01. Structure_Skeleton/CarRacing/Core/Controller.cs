﻿namespace CarRacing.Core
{
    using CarRacing.Core.Contracts;
    using CarRacing.Models.Cars;
    using CarRacing.Models.Cars.Contracts;
    using CarRacing.Models.Maps;
    using CarRacing.Models.Maps.Contracts;
    using CarRacing.Models.Racers;
    using CarRacing.Models.Racers.Contracts;
    using CarRacing.Repositories;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Controller : IController
    {
        private CarRepository cars;
        private RacerRepository racers;
        private IMap map;

        public Controller()
        {
            this.cars = new CarRepository();
            this.racers = new RacerRepository();
            this.map = new Map();
        }
        public string AddCar(string type, string make, string model, string VIN, int horsePower)
        {
            ICar car = null;

            if (type == nameof(SuperCar))
            {
                car = new SuperCar(make, model, VIN, horsePower);
            }
            else if(type == nameof(TunedCar))
            {
                car = new TunedCar(make, model, VIN, horsePower);
            }
            else
            {
                throw new ArgumentException("Invalid car type!");
            }

            this.cars.Add(car);
            return $"Successfully added car {make} {model} ({VIN}).";
        }

        public string AddRacer(string type, string username, string carVIN)
        {
            IRacer racer = null;
            ICar car = cars.FindBy(carVIN);
            if (car == null)
            {
                throw new ArgumentException("Car cannot be found!");
            }

            if (type == nameof(ProfessionalRacer))
            {
                racer = new ProfessionalRacer(username, car);
            }
            else if (type == nameof(StreetRacer))
            {
                racer = new StreetRacer(username, car);
            }
            else
            {
                throw new ArgumentException("Invalid racer type!");
            }

            this.racers.Add(racer);
            return $"Successfully added racer {username}.";
        }

        public string BeginRace(string racerOneUsername, string racerTwoUsername)
        {
            IRacer racer1 = racers.FindBy(racerOneUsername);
            IRacer racer2 = racers.FindBy(racerTwoUsername);

            if (racer1 == null)
            {
                throw new ArgumentException($"Racer {racerOneUsername} cannot be found!");
            }
            if (racer2 == null)
            {
                throw new ArgumentException($"Racer {racerTwoUsername} cannot be found!");
            }

            return this.map.StartRace(racer1, racer2);
        }

        public string Report()
        {
            var sb = new StringBuilder();

            foreach (var racer in racers.Models.OrderByDescending(x => x.DrivingExperience).ThenBy(x => x.Username)) //ThenByDescending?
            {
                sb.AppendLine($"{racer.GetType().Name}: {racer.Username}");
                sb.AppendLine($"--Driving behavior: {racer.RacingBehavior}");
                sb.AppendLine($"--Driving experience: {racer.DrivingExperience}");
                sb.AppendLine($"--Car: {racer.Car.Make} {racer.Car.Model} ({racer.Car.VIN})");
            }

            return sb.ToString().Trim();
        }
    }
}
