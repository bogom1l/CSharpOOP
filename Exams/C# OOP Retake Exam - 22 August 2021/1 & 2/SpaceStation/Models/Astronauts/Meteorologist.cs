namespace SpaceStation.Models.Astronauts
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Meteorologist : Astronaut
    {
        public Meteorologist(string name) 
            : base(name, 90)
        {
        }
    }
}
