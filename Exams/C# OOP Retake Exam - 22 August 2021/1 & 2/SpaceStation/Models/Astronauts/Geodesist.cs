namespace SpaceStation.Models.Astronauts
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Geodesist : Astronaut
    {
        public Geodesist(string name) 
            : base(name, 50)
        {
        }
    }
}
