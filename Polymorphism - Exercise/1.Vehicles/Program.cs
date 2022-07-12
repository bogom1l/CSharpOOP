using System;

namespace _1.Vehicles
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] tokens1 = Console.ReadLine().Split();
            IDrivable car = new Car(double.Parse(tokens1[1]), double.Parse(tokens1[2]));

            string[] tokens2 = Console.ReadLine().Split();
            IDrivable truck = new Truck(double.Parse(tokens1[1]), double.Parse(tokens1[2]));

            int N = int.Parse(Console.ReadLine());

            for (int i = 0; i < N; i++)
            {
                string[] tokens = Console.ReadLine().Split();
                string action = tokens[0];
                string vehicle = tokens[1];

                if (action == "Drive")
                {
                    if (vehicle == "Car")
                    {
                        int distance = int.Parse(tokens[2]);


                    }
                    else if(vehicle == "Truck")
                    {
                        int distance = int.Parse(tokens[2]);


                    }
                }
                else if(action == "Refuel")
                {
                    if (vehicle == "Car")
                    {
                        int liters = int.Parse(tokens[2]);


                    }
                    else if (vehicle == "Truck")
                    {
                        int liters = int.Parse(tokens[2]);


                    }
                }

            }

            Console.WriteLine("Car: {liters:f2}");
            Console.WriteLine("Truck: {liters:f2}");

        }
    }
}
