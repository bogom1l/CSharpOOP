using System;

namespace _2.VehiclesExtension_17072022try
{
    public class Program
    {
        static void Main(string[] args)
        {
            //"Vehicle {initial fuel quantity} {liters per km} {tank capacity}"
            Vehicle car = null;
            Vehicle truck = null;
            Vehicle bus = null;

            string[] vehicle1Data = Console.ReadLine().Split();
            double vehicle1FuelQuantity = double.Parse(vehicle1Data[1]);
            double vehicle1LitersPerKilometer = double.Parse(vehicle1Data[2]);
            double vehicle1TankCapacity = double.Parse(vehicle1Data[3]);

            if (vehicle1Data[0].ToLower() == "car")
            {
                car = new Car(vehicle1FuelQuantity, vehicle1LitersPerKilometer, vehicle1TankCapacity);
            }
            else if (vehicle1Data[0].ToLower() == "truck")
            {
                truck = new Truck(vehicle1FuelQuantity, vehicle1LitersPerKilometer, vehicle1TankCapacity);
            }
            else if (vehicle1Data[0].ToLower() == "bus")
            {
                bus = new Bus(vehicle1FuelQuantity, vehicle1LitersPerKilometer, vehicle1TankCapacity);
            }


            string[] vehicle2Data = Console.ReadLine().Split();
            double vehicle2FuelQuantity = double.Parse(vehicle2Data[1]);
            double vehicle2LitersPerKilometer = double.Parse(vehicle2Data[2]);
            double vehicle2TankCapacity = double.Parse(vehicle2Data[3]);

            if (vehicle2Data[0].ToLower() == "car")
            {
                car = new Car(vehicle2FuelQuantity, vehicle2LitersPerKilometer, vehicle2TankCapacity);
            }
            else if (vehicle2Data[0].ToLower() == "truck")
            {
                truck = new Truck(vehicle2FuelQuantity, vehicle2LitersPerKilometer, vehicle2TankCapacity);
            }
            else if (vehicle2Data[0].ToLower() == "bus")
            {
                bus = new Bus(vehicle2FuelQuantity, vehicle2LitersPerKilometer, vehicle2TankCapacity);
            }


            string[] vehicle3Data = Console.ReadLine().Split();
            double vehicle3FuelQuantity = double.Parse(vehicle3Data[1]);
            double vehicle3LitersPerKilometer = double.Parse(vehicle3Data[2]);
            double vehicle3TankCapacity = double.Parse(vehicle3Data[3]);

            if (vehicle3Data[0].ToLower() == "car")
            {
                car = new Car(vehicle3FuelQuantity, vehicle3LitersPerKilometer, vehicle3TankCapacity);
            }
            else if (vehicle3Data[0].ToLower() == "truck")
            {
                truck = new Truck(vehicle3FuelQuantity, vehicle3LitersPerKilometer, vehicle3TankCapacity);
            }
            else if (vehicle3Data[0].ToLower() == "bus")
            {
                bus = new Bus(vehicle3FuelQuantity, vehicle3LitersPerKilometer, vehicle3TankCapacity);
            }


            int N = int.Parse(Console.ReadLine());

            for (int i = 0; i < N; i++)
            {
                string[] tokens = Console.ReadLine().Split();
                string action = tokens[0]; //Drive/Refuel
                string currVehicle = tokens[1];
                double thirdParam = double.Parse(tokens[2]);
                try
                {
                    if (action == "Drive")
                    {
                        if (currVehicle == "Car")
                        {
                            Console.WriteLine(car.Drive(thirdParam));
                        }
                        else if (currVehicle == "Truck")
                        {
                            Console.WriteLine(truck.Drive(thirdParam));
                        }
                        else if (currVehicle == "Bus")
                        {
                            Console.WriteLine(bus.Drive(thirdParam));
                        }

                    }
                    else if (action == "DriveEmpty")
                    {
                        Console.WriteLine(bus.DriveEmpty(thirdParam));
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
                        else if (currVehicle == "Bus")
                        {
                            bus.Refuel(thirdParam);
                        }

                    }
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }
            }

            Console.WriteLine($"Car: {car.FuelQuantity:f2}");
            Console.WriteLine($"Truck: {truck.FuelQuantity:f2}");
            Console.WriteLine($"Bus: {bus.FuelQuantity:f2}");
        }
    }
}
