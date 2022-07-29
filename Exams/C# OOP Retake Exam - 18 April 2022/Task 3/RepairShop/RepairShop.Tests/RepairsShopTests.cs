using NUnit.Framework;
using System;

namespace RepairShop.Tests
{
    public class Tests
    {
        public class RepairsShopTests
        {

            [Test]

            public void ConstructorValidateData()
            {
                Garage garage = new Garage("RosenGacov", 123);

                Assert.AreEqual("RosenGacov", garage.Name);
                Assert.AreEqual(123, garage.MechanicsAvailable);
                Assert.AreEqual(0, garage.CarsInGarage);
            }

            [Test]
            public void ConstructorWithInvalidName()
            {
                Assert.Throws<ArgumentNullException>(() => new Garage("", 123));
                Assert.Throws<ArgumentNullException>(() => new Garage(null, 123));
            }

            [Test]
            public void ConstructorWithInvalidMechanics()
            {
                Assert.Throws<ArgumentException>(() => new Garage("SomeName", 0));
                Assert.Throws<ArgumentException>(() => new Garage("SomeName", -5));
            }

            [Test]
            public void AddCarTest()
            {
                Car car = new Car("TestModel", 5);
                Garage garage = new Garage("TestGarage", 1);
                garage.AddCar(car);

                Assert.AreEqual(1, garage.CarsInGarage);
            }

            [Test]
            public void AddCarTestException()
            {
                Car car = new Car("TestModel", 5);
                Garage garage = new Garage("TestGarage", 1);

                garage.AddCar(car);

                Car carToMakeTestThrowException = new Car("asd", 123);

                Assert.Throws<InvalidOperationException>(() => garage.AddCar(carToMakeTestThrowException) );
            }


            [Test]
            public void FixCarInvalidOperationException()
            {
                Car car = new Car("BMW", 1);
                Garage garage = new Garage("PriPesho", 5);

                garage.AddCar(car);

                Assert.Throws<InvalidOperationException>(() => garage.FixCar("Volvo"));
            }


            [Test]
            public void FixCarReturnZeroProblems()
            {
                Car car1 = new Car("BMW", 123);
                Garage garage = new Garage("PriPesho", 3);

                garage.AddCar(car1);
                garage.FixCar("BMW");

                Assert.AreEqual(1, garage.CarsInGarage);
                //garage.RemoveFixedCar();
                //Assert.AreEqual(0, garage.CarsInGarage);
            }

            [Test]
            public void RemoveFixedCarInvalidOperationException()
            {
                Car car1 = new Car("BMW", 123);
                Garage garage = new Garage("PriPesho", 3);

                garage.AddCar(car1);

                Assert.Throws<InvalidOperationException>(() => garage.RemoveFixedCar());
            }


            [Test]
            public void ReportTest()
            {
                Garage garage = new Garage("GarageName", 6);
                garage.AddCar(new Car("Opel", 1));
                garage.AddCar(new Car("Volvo", 2));

                var report = $"There are 2 which are not fixed: Opel, Volvo.";

                Assert.AreEqual(report, garage.Report());
            }

        }
    }
}