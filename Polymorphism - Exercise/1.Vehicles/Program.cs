using System;

namespace _1.Vehicles
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] carData = Console.ReadLine().Split();
            double carFuelQuantity = double.Parse(carData[1]);
            double carLitersPerKilometer = double.Parse(carData[2]);
            Vehicle car = new Car(carFuelQuantity, carLitersPerKilometer);

            string[] truckData = Console.ReadLine().Split();
            double truckFuelQuantity = double.Parse(truckData[1]);
            double truckLitersPerKilometer = double.Parse(truckData[2]);
            Vehicle truck = new Truck(truckFuelQuantity, truckLitersPerKilometer);

            int N = int.Parse(Console.ReadLine());

            for (int i = 0; i < N; i++)
            {
                string[] tokens = Console.ReadLine().Split();
                string action = tokens[0]; //Drive/Refuel
                string currVehicle = tokens[1];
                double thirdParam = double.Parse(tokens[2]);

                if (action == "Drive")
                {
                    if (currVehicle == "Car")
                    {
                        if (car.FuelQuantity >= thirdParam * car.FuelConspumtionInLitersPerKilometer)
                        {
                            car.Drive(thirdParam);
                            Console.WriteLine($"{currVehicle} travelled {thirdParam} km");
                        }
                        else
                        {
                            Console.WriteLine($"{currVehicle} needs refueling");
                        }
                    }
                    else if (currVehicle == "Truck")
                    {
                        if (truck.FuelQuantity >= thirdParam * truck.FuelConspumtionInLitersPerKilometer)
                        {
                            truck.Drive(thirdParam);
                            Console.WriteLine($"{currVehicle} travelled {thirdParam} km");
                        }
                        else
                        {
                            Console.WriteLine($"{currVehicle} needs refueling");
                        }
                    }

                }
                else if (action == "Refuel")
                {
                    if (currVehicle == "Car")
                    {
                        car.Refuel(thirdParam);
                    }
                    else if (currVehicle == "Truck")
                    {
                        truck.Refuel(thirdParam);
                    }
                }

            }

            Console.WriteLine($"Car: {car.FuelQuantity:f2}");
            Console.WriteLine($"Truck: {truck.FuelQuantity:f2}");


        }
    }
}
