using _2.VehiclesExtension.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace _2.VehiclesExtension.Core
{
    public class Engine : IEngine
    {
        private readonly Vehicle car;
        private readonly Vehicle truck;

        public Engine(Vehicle car, Vehicle truck)
        {
            this.car = car;
            this.truck = truck;
        }

        public void Start()
        {
            int N = int.Parse(Console.ReadLine());

            for (int i = 0; i < N; i++)
            {
                string[] tokens = Console.ReadLine().Split();
                string action = tokens[0];
                string vehicleType = tokens[1];
                double distance = double.Parse(tokens[2]);

                if (action == "Drive")
                {
                    if (vehicleType == "Car")
                    {
                        Console.WriteLine(this.car.Drive(distance));
                    }
                    else if (vehicleType == "Truck")
                    {
                        Console.WriteLine(this.truck.Drive(distance));
                    }
                }
                else if (action == "Refuel")
                {
                    double liters = double.Parse(tokens[2]);
                    if (vehicleType == "Car")
                    {
                        this.car.Refuel(liters);
                    }
                    else if (vehicleType == "Truck")
                    {
                        this.truck.Refuel(liters);
                    }
                }

            }

            Console.WriteLine($"{this.car}");
            Console.WriteLine($"{this.truck}");
        }


    }
}
