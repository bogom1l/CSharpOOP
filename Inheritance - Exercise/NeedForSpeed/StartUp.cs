namespace NeedForSpeed
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var v = new Vehicle(1, 2);
            System.Console.WriteLine(v.FuelConsumption);

            var c = new Car(1, 2);
            System.Console.WriteLine(c.FuelConsumption);

            var CM = new CrossMotorcycle(1, 2);
            System.Console.WriteLine(CM.FuelConsumption);

            var RM = new RaceMotorcycle(1, 2);
            System.Console.WriteLine(RM.FuelConsumption);

            var FC = new FamilyCar(1, 2);
            System.Console.WriteLine(FC.FuelConsumption);

            var SC = new SportCar(1, 2);
            System.Console.WriteLine(SC.FuelConsumption);

            var MC = new Motorcycle(1, 2);
            System.Console.WriteLine(MC.FuelConsumption);

        }
    }
}
