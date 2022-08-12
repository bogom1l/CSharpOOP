namespace NavalVessels.Core
{
    using Contracts;
    using Models;
    using NavalVessels.Models.Contracts;
    using Repositories;

    using System.Collections.Generic;
    using System.Linq;

    public class Controller : IController
    {
        private readonly VesselRepository vesselRepository;
        private readonly List<ICaptain> captains;

        public Controller()
        {
            this.vesselRepository = new VesselRepository();
            this.captains = new List<ICaptain>();
        }

        public string HireCaptain(string fullName)
        {
            if (this.captains.Any(x => x.FullName == fullName))
            {
                return $"Captain {fullName} is already hired.";
            }

            ICaptain captain = new Captain(fullName);
            this.captains.Add(captain);

            return $"Captain {fullName} is hired.";
        }

        public string ProduceVessel(string name, string vesselType, double mainWeaponCaliber, double speed)
        {
            if (this.vesselRepository.Models.Any(x => x.Name == name))
            {
                return $"{vesselType} vessel {name} is already manufactured.";
            }

            IVessel vessel;

            if (vesselType == nameof(Submarine))
            {
                vessel = new Submarine(name, mainWeaponCaliber, speed);
            }
            else if (vesselType == nameof(Battleship))
            {
                vessel = new Battleship(name, mainWeaponCaliber, speed);
            }
            else
            {
                return "Invalid vessel type.";
            }

            this.vesselRepository.Add(vessel);

            return
                $"{vesselType} {name} is manufactured with the main weapon caliber of {mainWeaponCaliber} inches and a maximum speed of {speed} knots.";
        }

        public string AssignCaptain(string selectedCaptainName, string selectedVesselName)
        {
            ICaptain captain = this.captains.FirstOrDefault(x => x.FullName == selectedCaptainName);
            IVessel vessel = this.vesselRepository.FindByName(selectedVesselName);

            if (captain == null)
            {
                return $"Captain {selectedCaptainName} could not be found.";
            }

            if (vessel == null)
            {
                return $"Vessel {selectedVesselName} could not be found.";
            }

            if (vessel.Captain != null)
            {
                return $"Vessel {selectedVesselName} is already occupied.";
            }

            vessel.Captain = captain;
            captain.AddVessel(vessel);

            return $"Captain {selectedCaptainName} command vessel {selectedVesselName}.";
        }

        public string CaptainReport(string captainFullName)
        {
            ICaptain captain = this.captains.FirstOrDefault(x => x.FullName == captainFullName);

            return captain.Report();
        }

        public string VesselReport(string vesselName)
        {
            IVessel vessel = this.vesselRepository.FindByName(vesselName);

            return vessel.ToString();
        }

        public string ToggleSpecialMode(string vesselName)
        {
            IVessel vessel = this.vesselRepository.FindByName(vesselName);

            if (vessel is Submarine submarine)
            {
                submarine.ToggleSubmergeMode();
                return $"Submarine {vesselName} toggled submerge mode.";
            }

            if (vessel is Battleship battleship)
            {
                battleship.ToggleSonarMode();
                return $"Battleship {vesselName} toggled sonar mode.";
            }

            return $"Vessel {vesselName} could not be found.";
        }


        public string AttackVessels(string attackingVesselName, string defendingVesselName)
        {
            IVessel ATTACKER = this.vesselRepository.FindByName(attackingVesselName);
            IVessel DEFENDER = this.vesselRepository.FindByName(defendingVesselName);

            if (ATTACKER == null)
            {
                return $"Vessel {attackingVesselName} could not be found.";
            }

            if (DEFENDER == null)
            {
                return $"Vessel {defendingVesselName} could not be found.";
            }

            if (ATTACKER.ArmorThickness == 0)
            {
                return $"Unarmored vessel {attackingVesselName} cannot attack or be attacked.";
            }

            if (DEFENDER.ArmorThickness == 0)
            {
                return $"Unarmored vessel {defendingVesselName} cannot attack or be attacked.";
            }

            ATTACKER.Attack(DEFENDER);

            ATTACKER.Captain.IncreaseCombatExperience();
            DEFENDER.Captain.IncreaseCombatExperience();

            return
                $"Vessel {defendingVesselName} was attacked by vessel {attackingVesselName} - current armor thickness: {DEFENDER.ArmorThickness}.";
        }

        public string ServiceVessel(string vesselName)
        {
            IVessel vessel = this.vesselRepository.FindByName(vesselName);

            if (vessel == null)
            {
                return $"Vessel {vesselName} could not be found.";
            }

            vessel.RepairVessel();

            return $"Vessel {vesselName} was repaired.";
        }
    }
}
