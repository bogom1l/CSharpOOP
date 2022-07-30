using NUnit.Framework;
using System;

namespace SmartphoneShop.Tests
{
    [TestFixture]
    public class SmartphoneShopTests
    {

        [Test]
        public void ConstructorWithCorrectDataShouldReturnCorrectCapacity()
        {
            Shop shop = new Shop(5);

            Assert.AreEqual(5, shop.Capacity);
            Assert.AreEqual(0, shop.Count);
        }

        [Test]
        public void NegativeCapacityShouldThrowArgExc()
        {
            Assert.Throws<ArgumentException>(() => new Shop(-5));
        }

        [Test]
        public void AddPhoneAlreadyExistsIOExc()
        {
            Smartphone smartphone = new Smartphone("Samsung", 10);
            Shop shop = new Shop(5);

            shop.Add(smartphone);
            Assert.Throws<InvalidOperationException>(() => shop.Add(smartphone));
        }

        [Test]
        public void AddPhoneFullIOExc()
        {
            Shop shop = new Shop(2);
            shop.Add(new Smartphone("a", 15));
            shop.Add(new Smartphone("b", 25));

            Assert.Throws<InvalidOperationException>(() => shop.Add(new Smartphone("c", 123)));
        }

        [Test]
        public void AddPhoneCorrectReturn()
        {
            Shop shop = new Shop(2);
            shop.Add(new Smartphone("a", 1));
            Assert.AreEqual(1, shop.Count);
        }

        [Test]
        public void RemovePhoneNonExistentIOExc()
        {
            Shop shop = new Shop(1);
            Assert.Throws<InvalidOperationException>(() => shop.Remove("someName"));
        }

        [Test]
        public void RemovePhoneCorrectReturn()
        {
            Shop shop = new Shop(2);

            shop.Add(new Smartphone("Nokia", 10));
            shop.Add(new Smartphone("Kia", 15));

            shop.Remove("Nokia");

            Assert.AreEqual(1, shop.Count);
        }

        [Test]
        public void TestPhoneNonExistentOIExc()
        {
            Shop shop = new Shop(2);

            Assert.Throws<InvalidOperationException>(() => shop.TestPhone("asd", 10));
        }

        [TestCase(20)]
        public void TestPhoneLowBatteryOIExc(int battery)
        {
            Shop shop = new Shop(5);

            Assert.Throws<InvalidOperationException>(() => shop.TestPhone("asd", 10));
        }

        [TestCase(10)]
        public void TestPhoneCorrectReturn(int batteryUsage)
        {
            Shop shop = new Shop(5);
            Smartphone smartphone = new Smartphone("asd", 50);
            shop.Add(smartphone);

            shop.TestPhone("asd", 10);

            Assert.AreEqual(50 - 10, smartphone.CurrentBateryCharge);
        }

        [Test]
        public void ChargePhoneNonExistenIOExc()
        {
            Shop shop = new Shop(2);
            Smartphone smartphone = new Smartphone("asd", 50);
            shop.Add(smartphone);

            Assert.Throws<InvalidOperationException>(() => shop.ChargePhone("qwe"));
        }

        [Test]
        public void ChargePhoneCorrectReturn()
        {
            var shop = new Shop(2);

            shop.Add(new Smartphone("Samsung", 78));
            shop.Add(new Smartphone("Iphone", 38));

            shop.TestPhone("Samsung", 45);

            shop.ChargePhone("Samsung");

            shop.TestPhone("Samsung", 77);

            Assert.Throws<InvalidOperationException>(() => shop.TestPhone("Samsung", 2));
        }






    }
}