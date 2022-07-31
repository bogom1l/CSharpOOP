namespace Gym.Core
{
    using Gym.Core.Contracts;
    using Gym.Models.Athletes;
    using Gym.Models.Athletes.Contracts;
    using Gym.Models.Equipment;
    using Gym.Models.Equipment.Contracts;
    using Gym.Models.Gyms;
    using Gym.Models.Gyms.Contracts;
    using Gym.Repositories;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Controller : IController
    {
        private readonly EquipmentRepository equipment; //readonly?
        private readonly List<IGym> gyms;

        public Controller()
        {
            this.gyms = new List<IGym>();
            this.equipment = new EquipmentRepository();
        }

        public string AddAthlete(string gymName, string athleteType, string athleteName, string motivation, int numberOfMedals)
        {
            IAthlete currAthlete = null;
            IGym currGym = gyms.FirstOrDefault(g => g.Name == gymName);

            //if (currGym == null)
            //{
            //    throw new InvalidOperationException("Invalid gym type.");
            //}

            if (athleteType == nameof(Boxer))
            {
                currAthlete = new Boxer(athleteName, motivation, numberOfMedals);
                if (currGym.GetType().Name == nameof(BoxingGym)) // typeof ?
                {
                    currGym.AddAthlete(currAthlete);
                }
                else
                {
                    return $"The gym is not appropriate.";
                }
            }
            else if (athleteType == nameof(Weightlifter))
            {
                currAthlete = new Weightlifter(athleteName, motivation, numberOfMedals);
                if (currGym.GetType().Name == nameof(WeightliftingGym)) // typeof ?
                {
                    currGym.AddAthlete(currAthlete);
                }
                else
                {
                    return $"The gym is not appropriate.";
                }
            }
            else
            {
                throw new InvalidOperationException("Invalid athlete type.");
            }

            return $"Successfully added {athleteType} to {gymName}.";
        }

        public string AddEquipment(string equipmentType)
        {
            IEquipment equipmentToAdd = null;

            if (equipmentType == nameof(BoxingGloves))
            {
                equipmentToAdd = new BoxingGloves();
            }
            else if (equipmentType == nameof(Kettlebell))
            {
                equipmentToAdd = new Kettlebell();
            }
            else
            {
                throw new InvalidOperationException("Invalid equipment type.");
            }

            equipment.Add(equipmentToAdd);
            return $"Successfully added {equipmentType}.";
        }

        public string AddGym(string gymType, string gymName)
        {
            IGym gym = null;

            if (gymType == nameof(BoxingGym))
            {
                gym = new BoxingGym(gymName);
            }
            else if (gymType == nameof(WeightliftingGym))
            {
                gym = new WeightliftingGym(gymName);
            }
            else
            {
                throw new InvalidOperationException("Invalid gym type.");
            }

            gyms.Add(gym);
            return $"Successfully added {gymType}.";
        }

        public string EquipmentWeight(string gymName)
        {
            IGym gym = gyms.FirstOrDefault(g => g.Name == gymName);

            //if (currGym == null)
            //{
            //    throw new InvalidOperationException("Invalid gym type.");
            //}

            return $"The total weight of the equipment in the gym {gymName} is {gym.EquipmentWeight:f2} grams.";
        }

        public string InsertEquipment(string gymName, string equipmentType)
        {
            IGym currGym = gyms.FirstOrDefault(g => g.Name == gymName);
            IEquipment currEquipment = equipment.FindByType(equipmentType);

            if (currEquipment == null)
            {
                throw new InvalidOperationException($"There isn’t equipment of type {equipmentType}.");
            }

            //if (currGym == null)
            //{
            //    throw new InvalidOperationException("Invalid gym type.");
            //}

            currGym.AddEquipment(currEquipment);
            equipment.Remove(currEquipment);

            return $"Successfully added {equipmentType} to {gymName}.";
        }

        public string Report()
        {
            var sb = new StringBuilder();
            foreach (var gym in gyms)
            {
                sb.AppendLine(gym.GymInfo());
            }

            return sb.ToString().Trim();
        }

        public string TrainAthletes(string gymName)
        {
            IGym gym = gyms.FirstOrDefault(g => g.Name == gymName);

            //if (currGym == null)
            //{
            //    throw new InvalidOperationException("Invalid gym type.");
            //}

            foreach (IAthlete athlete in gym.Athletes)  //gym.Athletes.ToList().ForEach(a => a.Exercise());
            {
                athlete.Exercise();
            }

            return $"Exercise athletes: {gym.Athletes.Count}.";
        }
    }
}
