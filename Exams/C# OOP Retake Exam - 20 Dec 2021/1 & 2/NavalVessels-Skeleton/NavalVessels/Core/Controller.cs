namespace NavalVessels.Core
{
    using NavalVessels.Core.Contracts;
    using NavalVessels.Models;
    using NavalVessels.Models.Contracts;
    using NavalVessels.Repositories;
    using System.Collections.Generic;
    using System.Linq;

    public class Controller : IController
    {
        private readonly VesselRepository vessels;
        private readonly List<ICaptain> captains;
        public Controller()
        {
            this.vessels = new VesselRepository();
            this.captains = new List<ICaptain>();
        }

        public string AssignCaptain(string selectedCaptainName, string selectedVesselName)
        {
            var vessel = this.vessels.FindByName(selectedVesselName);
            var captain = this.captains.FirstOrDefault(x => x.FullName == selectedCaptainName);

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

        public string AttackVessels(string attackingVesselName, string defendingVesselName)
        {
            var attackingVessel = this.vessels.FindByName(attackingVesselName);
            var defendingVessel = this.vessels.FindByName(defendingVesselName);

            if (attackingVessel == null)
            {
                return $"Vessel {attackingVesselName} could not be found.";
            }
            if (defendingVessel == null)
            {
                return $"Vessel {defendingVesselName} could not be found.";
            }

            if (attackingVessel.ArmorThickness == 0)
            {
                return $"Unarmored vessel {attackingVesselName} cannot attack or be attacked.";
            }
            if (defendingVessel.ArmorThickness == 0)
            {
                return $"Unarmored vessel {defendingVesselName} cannot attack or be attacked.";
            }

            attackingVessel.Attack(defendingVessel);
            return $"Vessel {defendingVesselName} was attacked by vessel {attackingVesselName} - current armor thickness: {defendingVessel.ArmorThickness}.";
        }

        public string CaptainReport(string captainFullName)
        {
            var captain = captains.FirstOrDefault(x => x.FullName == captainFullName);

            if (captain == null)
            {
                return $"Captain {captainFullName} could not be found.";
            }

            return captain.Report();
        }

        public string HireCaptain(string fullName)
        {
            if (this.captains.Any(x => x.FullName == fullName))
            {
                return $"Captain {fullName} is already hired.";
            }

            var captain = new Captain(fullName);
            this.captains.Add(captain);
            return $"Captain {fullName} is hired.";
        }

        public string ProduceVessel(string name, string vesselType, double mainWeaponCaliber, double speed)
        {
            IVessel vessel = null;

            var checkVessel = vessels.Models.FirstOrDefault(x => x.Name == name);
            if (checkVessel != null)
            {
                return $"{vessel.GetType().Name} vessel {name} is already manufactured.";
            }

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

            this.vessels.Add(vessel);
            return $"{vessel.GetType().Name} {name} is manufactured with the main weapon caliber of {mainWeaponCaliber} inches and a maximum speed of {speed} knots.";
        }

        public string ServiceVessel(string vesselName)
        {
            var vessel = vessels.FindByName(vesselName);

            if (vessel == null)
            {
                return $"Vessel {vesselName} could not be found.";
            }

            vessel.RepairVessel();
            return $"Vessel {vesselName} was repaired.";
        }

        public string ToggleSpecialMode(string vesselName)
        {
            var vessel = vessels.FindByName(vesselName);

            if (vessel != null && vessel is Submarine)
            {
                (vessel as Submarine).ToggleSubmergeMode();
                return $"Submarine {vesselName} toggled submerge mode.";
            }
            else if (vessel != null && vessel is Battleship)
            {
                (vessel as Battleship).ToggleSonarMode();
                return $"Battleship {vesselName} toggled sonar mode.";
            }
            else
            {
                return $"Vessel {vesselName} could not be found.";
            }
        }

        public string VesselReport(string vesselName)
        {
            var vessel = vessels.FindByName(vesselName);

            if (vessel == null)
            {
                return $"Vessel {vesselName} could not be found.";
            }

            return vessel.ToString();
        }
    }
}
