using _3.Raiding.Core;
using _3.Raiding.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace _3.Raiding
{
    public class StartUp
    {
        static void Main(string[] args)
        {

            IEngine engine = new Engine();
            engine.Start();

        }
    }
}
