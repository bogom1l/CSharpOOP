namespace Formula1.Core
{
    using Formula1.Core.Contracts;
    using Formula1.Models;
    using Formula1.Models.Contracts;
    using Formula1.Repositories;
    using System;
    using System.Linq;
    using System.Text;

    public class Controller : IController
    {
        private PilotRepository pilotRepository;
        private RaceRepository raceRepository;
        private FormulaOneCarRepository carRepository;

        public Controller()
        {
            this.raceRepository = new RaceRepository();
            this.pilotRepository = new PilotRepository();
            this.carRepository = new FormulaOneCarRepository();
        }

        public string AddCarToPilot(string pilotName, string carModel)
        {
            IFormulaOneCar car = carRepository.FindByName(carModel);
            IPilot pilot = pilotRepository.FindByName(pilotName);

            if (pilot == null || pilot.Car != null)
            {
                throw new InvalidOperationException($"Pilot {pilotName} does not exist or has a car.");
            }
            if (car == null)
            {
                throw new NullReferenceException($"Car {carModel} does not exist.");
            }

            pilot.AddCar(car);
            carRepository.Remove(car);
            return $"Pilot {pilot.FullName} will drive a {car.GetType().Name} {car.Model} car.";
        }

        public string AddPilotToRace(string raceName, string pilotFullName)
        {
            IPilot pilot = pilotRepository.FindByName(pilotFullName);
            IRace race = raceRepository.FindByName(raceName);

            if (race == null)
            {
                throw new NullReferenceException($"Race {raceName} does not exist.");
            }
            if (pilot == null || !pilot.CanRace || race.Pilots.Contains(pilot))  
            {
                throw new InvalidOperationException($"Can not add pilot {pilotFullName} to the race.");
            }

            race.AddPilot(pilot);

            return $"Pilot {pilot.FullName} is added to the {race.RaceName} race.";
        }

        public string CreateCar(string type, string model, int horsepower, double engineDisplacement)
        {
            IFormulaOneCar carToAdd = null;

            if (carRepository.FindByName(model) != null)
            {
                throw new InvalidOperationException($"Formula one car {model} is already created.");
            }

            if (type == nameof(Ferrari))
            {
                carToAdd = new Ferrari(model, horsepower, engineDisplacement);
            }
            else if (type == nameof(Williams))
            {
                carToAdd = new Williams(model, horsepower, engineDisplacement);
            }
            else
            {
                throw new InvalidOperationException($"Formula one car type {type} is not valid.");
            }

            carRepository.Add(carToAdd);
            return $"Car {carToAdd.GetType().Name}, model {carToAdd.Model} is created.";
        }

        public string CreatePilot(string fullName)
        {
            if (pilotRepository.FindByName(fullName) != null)
            {
                throw new InvalidOperationException($"Pilot {fullName} is already created.");
            }

            IPilot pilotToAdd = new Pilot(fullName);
            this.pilotRepository.Add(pilotToAdd);

            return $"Pilot {pilotToAdd.FullName} is created.";
        }

        public string CreateRace(string raceName, int numberOfLaps)
        {
            if (this.raceRepository.FindByName(raceName) != null)
            {
                throw new InvalidOperationException($"Race {raceName} is already created.");
            }

            IRace raceToAdd = new Race(raceName, numberOfLaps);
            this.raceRepository.Add(raceToAdd);
            return $"Race {raceToAdd.RaceName} is created.";
        }

        public string PilotReport()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var pilot in pilotRepository.Models.OrderByDescending(x => x.NumberOfWins))
            {
                sb.AppendLine(pilot.ToString());
            }
            return sb.ToString().Trim();
        }

        public string RaceReport()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var race in raceRepository.Models.Where(x => x.TookPlace))
            {
                sb.AppendLine(race.RaceInfo());
            }

            return sb.ToString().Trim();
        }

        public string StartRace(string raceName)
        {
            IRace race = raceRepository.FindByName(raceName);

            if (race == null)
            {
                throw new NullReferenceException($"Race {raceName} does not exist.");
            }

            if (race.Pilots.Count < 3)
            {
                throw new InvalidOperationException($"Race {raceName} cannot start with less than three participants.");
            }

            if (race.TookPlace)
            {
                throw new InvalidOperationException($"Can not execute race {raceName}.");
            }

            IPilot winner = race.Pilots.OrderByDescending(x => x.Car.RaceScoreCalculator(race.NumberOfLaps)).First();
            IPilot secondPlace = race.Pilots.OrderByDescending(x => x.Car.RaceScoreCalculator(race.NumberOfLaps)).Skip(1).First();
            IPilot thirdPlace = race.Pilots.OrderByDescending(x => x.Car.RaceScoreCalculator(race.NumberOfLaps)).Skip(2).First();

            winner.WinRace();
            
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Pilot {winner.FullName} wins the {race.RaceName} race.");
            sb.AppendLine($"Pilot {secondPlace.FullName} is second in the {race.RaceName} race.");
            sb.AppendLine($"Pilot {thirdPlace.FullName} is third in the {race.RaceName} race.");

            race.TookPlace = true;

            return sb.ToString().Trim();
        }
    }
}
